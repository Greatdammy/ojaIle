﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ojaIle.abstraction;
using ojaIle.core;
using ojaIle.webapi.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ojaile.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailservice;

        public AccountController( IConfiguration configuration, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger, 
            RoleManager<IdentityRole> roleManager, IEmailService emailservice)
        {
            _configuration = configuration;
            _userManager = userManager;
            //_logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailservice = emailservice;
        }

        public List<RegisterViewModel> register = new List<RegisterViewModel>()
        {
            new RegisterViewModel{FirstName = "Obiora", LastName = "Igwilo", Email = "Igwiloobiora@20", phoneNumber = "003737389", UserName = "Obi", Password = "Management"},
            new RegisterViewModel{FirstName = "Bisi", LastName = "Olaoye", Email = "Bisiolaoye", phoneNumber = "12345", UserName = "Bisi", Password = "Manager"},
            new RegisterViewModel{FirstName = "Moyo", LastName = "Sore", Email = "Moyo@gmail", phoneNumber = "001122", UserName = "Obi", Password = "Management"},
        };

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model, bool isPersistent)
        {
            //Log.Information("Call login action");

            // _logger.LogInformation("call login action");
            //isPersistent = false;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var user = AuthenticateUser(model);
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, 
                isPersistent, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                var stringtoken = GenerateAuthenticatedUserToken(user);
                return Ok(new { token = stringtoken });
            }
            return BadRequest(ModelState);
        }

        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<IActionResult> Regitser([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var roleExist = await _roleManager.RoleExistsAsync("Customer");
            if (!roleExist)
            {
                var role = new IdentityRole();
                role.NormalizedName = "Customer";
                role.Name = "Customer";
                await _roleManager.CreateAsync(role);
            }
            var user = new ApplicationUser();
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.phoneNumber;
            user.UserName = model.UserName;
            user.Created = DateTime.Now;
            user.Institution = 1;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                await _emailservice.SendEmailAsync(new MailRequest
                {
                    Body = "Registration successful," +
                    "welcome to Petify",

                    Subject = "Registration Email",
                    ToEmail = model.Email,
                    Attachments = null
                });
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        [Route("Register/{roleName}")]

        public async Task<IActionResult> Regitser([FromBody] RegisterViewModel model, string roleName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var roleExist = await _roleManager.RoleExistsAsync(roleName.Trim());
            if (!roleExist)
            {
                var role = new IdentityRole();
                role.NormalizedName = roleName;
                role.Name = roleName;
                await _roleManager .CreateAsync(role);
            }
            var user = new ApplicationUser();
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.phoneNumber;
            user.UserName = model.UserName;
            user.Created = DateTime.Now;
            user.Institution = 1;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName.Trim());
                return Ok(result);
            }
               
            return BadRequest(ModelState);
        }

        private string GenerateAuthenticatedUserToken(ApplicationUser user)
        {
            var signkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));

            var credential = new SigningCredentials(signkey, SecurityAlgorithms.HmacSha256);
            var claim = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"], claim, notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(5), credential);
            return new JwtSecurityTokenHandler().WriteToken(token);


        }

        [HttpGet("allUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = _userManager.Users;
            return Ok(user);
        }

        private RegisterViewModel AuthenticateUser(LoginViewModel model)
        {
            //throw new NotImplementedException();
            var user = register.Where(m => m.UserName == model.UserName && m.Password == model.Password).FirstOrDefault();
            if (user != null)
                return user;
            return null;
        }
    }
}