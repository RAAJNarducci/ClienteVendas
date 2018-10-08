using ClienteVendas.Infra.CrossCutting.Identity.Data;
using ClienteVendas.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using static ClienteVendas.Data.CrossCutting.Constants.Constants;

namespace ClienteVendas.Infra.CrossCutting.Identity.Initializer
{
    public class IdentityInitializer
    {
        private readonly ApplicationIdentityContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            ApplicationIdentityContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (!_roleManager.RoleExistsAsync(Roles.ROLE_API_ADMIN).Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole(Roles.ROLE_API_ADMIN)).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role {Roles.ROLE_API_ADMIN}.");
                }
            }
        }
    }
}
