﻿using System.ComponentModel.DataAnnotations;

namespace APIAdoPet.Domains.DTO.LoginDTO
{
    public class LoginUsuarioDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
