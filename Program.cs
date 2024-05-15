using AngularBetShop.DBContext;
using AngularBetShop.Interfaces;
using AngularBetShop.Models;
using AngularBetShop.Repository;
using AngularBetShop.Services;
using AngularBetShop.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AngularBetShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<WFContext>(options => options.
                                UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {


                o.AddSecurityDefinition(
                   "Bearer", new OpenApiSecurityScheme
                   {
                       Name = "Authorization",
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer",
                       BearerFormat = "JWT",
                       In = ParameterLocation.Header,
                       Description = "Enter your JWT API KEY"
                   });

                // For Authorize the End Points such as GET,POST 

                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            }
                );


            builder.Services.AddScoped<IRepository<Product>, GRepository<Product>>();
            builder.Services.AddScoped<IUnitOfWork<Product>, UnitOfWork<Product>>();
            builder.Services.AddScoped<ProductService, ProductService>();

            builder.Services.AddScoped<IRepository<Category>, GRepository<Category>>();
            builder.Services.AddScoped<IUnitOfWork<Category>, UnitOfWork<Category>>();
            builder.Services.AddScoped<CategoryService, CategoryService>();

            builder.Services.AddScoped<IRepository<Order>, GRepository<Order>>();
            builder.Services.AddScoped<IUnitOfWork<Order>, UnitOfWork<Order>>();
            builder.Services.AddScoped<OrderService, OrderService>();

            builder.Services.AddScoped<IRepository<Cart>, GRepository<Cart>>();
            builder.Services.AddScoped<IUnitOfWork<Cart>, UnitOfWork<Cart>>();
            builder.Services.AddScoped<CartService, CartService>();

            builder.Services.AddScoped<IRepository<Favorites>, GRepository<Favorites>>();
            builder.Services.AddScoped<IUnitOfWork<Favorites>, UnitOfWork<Favorites>>();
            builder.Services.AddScoped<FavoritesSevice, FavoritesSevice>();



            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<WFContext>();
            builder.Services.AddAuthentication(options =>
                    options.DefaultAuthenticateScheme = "myschema")
                    .AddJwtBearer("myschema",
                        option =>
                        {
                            string key = "welcome to my secret shop Key Khalid Wahid";
                            var secretkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                            option.TokenValidationParameters = new TokenValidationParameters()
                            {
                                IssuerSigningKey = secretkey,
                                ValidateIssuer = false,
                                ValidateAudience = false,
                            };
                        }

                    );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
