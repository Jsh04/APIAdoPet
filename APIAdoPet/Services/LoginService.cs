using APIAdoPet.Domains;
using APIAdoPet.Domains.DTO.LoginDTO;
using APIAdoPet.Exception;
using APIAdoPet.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace APIAdoPet.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public LoginService(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            var usuario = await _userManager.FindByEmailAsync(loginUsuarioDTO.Email);
            var resultado = await _signInManager.PasswordSignInAsync(usuario.UserName, loginUsuarioDTO.Senha, false, false);
            if (!resultado.Succeeded) 
            {
                throw new HttpResponseException(400, new { ErroMenssage =  "Login Inválido" });
            }
            return resultado;
        }
    }
}
