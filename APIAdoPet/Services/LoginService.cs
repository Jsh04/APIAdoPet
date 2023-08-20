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
        private readonly ITokenService _tokenService;

        public LoginService(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager, ITokenService tokenService) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginUsuarioDTO loginUsuarioDTO)
        {
            var usuario = await _userManager.FindByEmailAsync(loginUsuarioDTO.Email);
            var resultado = await _signInManager.PasswordSignInAsync(usuario, loginUsuarioDTO.Senha, false, false);
            
            if (!resultado.Succeeded) 
            {
                throw new HttpResponseException(400, "Login Inválido" );
            }
            var token = await _tokenService.GerarTokenJWT(usuario);
            return token;
        }

         
    }
}
