using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteVendas.Application.ViewModels;
using ClienteVendas.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static ClienteVendas.Data.CrossCutting.Constants.Constants;

namespace ClienteVendas.Services.Api.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var user = new AppUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, Roles.ROLE_API_ADMIN).Wait();
                return Ok();
            }

            return Unauthorized();
        }
    }
}