using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Infraestrutura.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Xunit.Abstractions;

namespace TesteUnitariosAPIAdopet;

public class TutorTeste : IClassFixture<TestDatabaseFixture>
{
    public TestDatabaseFixture Fixture { get; }
    private readonly TutorRepository _repository;

    public TutorTeste(TestDatabaseFixture fixture)
    {
        Fixture = fixture;
        _repository = new TutorRepository(Fixture.CreateContext());
    }


    [Fact(DisplayName = "Retornar Objeto diferente de null com os tutores do banco de dados")]
    public void ListarTodosOsTutoresDiferenteDeNull()
    {
        var tutores = _repository.ListarTutor(0, 5);
        Assert.NotEmpty(tutores);
    }

    [Fact]
    public void ListarTutoresERetornarUm()
    {
        var tutores = _repository.ListarTutor(0,5);
        Assert.Equal(5, tutores.Count());
    }

    [Theory(DisplayName = "Cadastrar Tutores no banco de dados", Skip = "Por enquanto")]
    [InlineData("Vitor alberto", "vitor@gamil.com", "12345")]
    [InlineData("Laís Zanardi", "lais@gmail.com", "123456789")]
    [InlineData("Luke da Silva", "luke@gmail.com", "1235")]
    public void CadastrarTutorNoBanco(string nome, string email, string senha)
    {

        string passwordHash = EncoderPassword(senha);
        var tutor = new Tutor()
        {
            Nome = nome,
            Usuario = new Usuario()
            {
                Email = email,
                PasswordHash = passwordHash
            }
        };
        var tutorCriado = _repository.CadastrarTutor(tutor);
        Assert.NotNull(tutorCriado);
        
    }

    private string EncoderPassword(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        return passwordHash;
    }
}