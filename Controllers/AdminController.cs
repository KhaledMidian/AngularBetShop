using AngularBetShop.AddDTOs;
using AngularBetShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace AngularBetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<AppUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        // POST api/<AdminController>
        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult> AddRole(string roleName)
        {
            if (roleName == null) return BadRequest();
            else
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
                return Ok(role);
            }
        }


        [HttpPut]
        [Route("UpdateRole")]
        public async Task<ActionResult> UpdateRole(RoleDTO roleDTO)
        {
            if (roleDTO == null) return BadRequest();
            else
            {
                IdentityRole role = await _roleManager.FindByIdAsync(roleDTO.Id);
                if (role == null) return BadRequest();
                role.Name = roleDTO.name;
                await _roleManager.UpdateAsync(role);
                return Ok(role);
            }
        }



        [HttpPut]
        [Route("updateUserRole")]
        public async Task<ActionResult> updateUserRole(string userId, List<string> roles)
        {
            if (userId == null || roles == null) return BadRequest();
            else
            {
                AppUser user = await _userManager.FindByIdAsync(userId);
                if (user == null) return BadRequest();
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                await _userManager.AddToRolesAsync(user, roles);
                return Ok(user);
            }
        }




        [HttpGet]
        [Route("AllRole")]
        public ActionResult getAllRoles()
        {
            if (_roleManager.Roles.ToList() == null) return NotFound();
            else return Ok(_roleManager.Roles.ToList());
        }

        [HttpGet]
        [Route("Role")]
        public async Task<ActionResult> getRoleById(string id)
        {
            if (await _roleManager.FindByIdAsync(id) == null) return NotFound();
            else return Ok(await _roleManager.FindByIdAsync(id));
        }


        [HttpGet]
        [Route("User")]
        public async Task<ActionResult> getUserById(string id)
        {
            if (await _userManager.FindByIdAsync(id) == null) return NotFound();
            else return Ok(await _userManager.FindByIdAsync(id));
        }



        [HttpGet]
        [Route("AllUsers")]
        public ActionResult getAllUsers()
        {
            if (_userManager.Users.ToList() == null) return NotFound();
            else return Ok(_userManager.Users.ToList());
        }



        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole(string id)
        {
            if (await _roleManager.FindByIdAsync(id) == null) return NotFound();
            else
            {
                await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
                return Ok();
            }
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (await _userManager.FindByIdAsync(id) == null) return NotFound();
            else
            {
                await _userManager.DeleteAsync(await _userManager.FindByIdAsync(id));
                return Ok();
            }
        }

    }
}
