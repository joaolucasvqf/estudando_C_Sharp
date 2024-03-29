﻿using Microsoft.AspNetCore.Identity;
using TalkToApi.V1.Models;

namespace TalkToApi.V1.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        void Cadastrar(ApplicationUser usuario, string senha);
        ApplicationUser Obter(string email, string senha);
        ApplicationUser Obter(string id);
    }
}
