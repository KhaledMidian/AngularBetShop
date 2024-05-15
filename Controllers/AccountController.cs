using AngularBetShop.DTOs;
using AngularBetShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        IPasswordHasher<AppUser> _passwordHasher;


        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._passwordHasher = passwordHasher;
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(AppUserAddDTO appUserAddDTO)
        {
            if (ModelState.IsValid == true)
            {
                AppUser user = new AppUser()
                {
                    UserName = appUserAddDTO.userName,
                    PasswordHash = appUserAddDTO.password,
                    Email = appUserAddDTO.email,
                    PhoneNumber = appUserAddDTO.phoneNumber,
                    address = appUserAddDTO.address
                   
                };

                IdentityResult identityResult = await _userManager.CreateAsync(user, appUserAddDTO.password);

                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, false);
                    return Created();
                }
                else
                {
                    
                    return BadRequest(string.Join(", ", identityResult.Errors.Select(e=>e.Description)));
                }
            }

            else
            {
                return BadRequest(ModelState);
            }
        }



        [HttpPost]
        [Route("LogIn")]
        public async Task<ActionResult> LogIn(logInDTO logInDTO)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByNameAsync(logInDTO.userName);
                if (appUser != null)
                {
                    if (await _userManager.CheckPasswordAsync(appUser, logInDTO.password))
                    {
                        List<Claim> userclaims = new List<Claim>()
                                    {
                                          new Claim("userName",appUser.UserName),
                                          new Claim("phone",appUser.PhoneNumber),
                                          new Claim ("email",appUser.Email),
                                          new Claim("address",appUser.address)
                                    };
                                   // string key = "this is the White Fslcon secret Key";

                        string key = "welcome to my secret shop Key Khalid Wahid";

                        var secretkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                        var sigingCred = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                                claims: userclaims,
                                signingCredentials: sigingCred,
                                expires: DateTime.Now.AddDays(3)
                            );
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                        var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                        await _signInManager.SignInAsync(appUser, logInDTO.remember);
                        return Ok(tokenstring);

                    }
                    else
                    {
                        return BadRequest("Wrong Password");
                    }

                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }



        [HttpGet]
        [Route("SignOut")]
        public async Task<ActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> put(string id, AppUserAddDTO appUserAddDTO)
        {
            if (appUserAddDTO == null || id==null) { return BadRequest(ModelState); }
            else
            {
               AppUser user= await _userManager.FindByIdAsync(id);
                if (user == null) { return NotFound(); }
                else
                {
                    user.UserName = appUserAddDTO.userName;
                    user.PasswordHash = _passwordHasher.HashPassword(user, appUserAddDTO.password) ;
                    user.Email = appUserAddDTO.email;
                    user.PhoneNumber = appUserAddDTO.phoneNumber;
                    user.address = appUserAddDTO.address;
                    await _userManager.UpdateAsync(user);
                    return Ok(user);
                }
            }
        }

    }

}
