﻿using Microsoft.AspNetCore.Identity;
using TalkToApi.V1.Models;
using TalkToApi.V1.Repositories.Contracts;
using System;
using System.Text;

namespace TalkToApi.V1.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsuarioRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public ApplicationUser Obter(string email, string senha)
        {
            var usuario = _userManager.FindByEmailAsync(email).Result;
            if (_userManager.CheckPasswordAsync(usuario, senha).Result)
            {
                return usuario;
            } 
            else
            {
                /*
                 * Domain Notification
                 */
                throw new Exception("Usuário ou senha incorretos");
            }
        }
        public void Cadastrar(ApplicationUser usuario, string senha)
        {
            var result = _userManager.CreateAsync(usuario, senha).Result;
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var erro in result.Errors)
                {
                    sb.Append(erro.Description);
                }
                /*
                 * Domain Notification
                 */
                throw new Exception($"Falha ao cadastrar usuário {sb.ToString()}");
            }
        }

        public ApplicationUser Obter(string id)
        {
            return _userManager.FindByIdAsync(id).Result;
        }
    }
}
