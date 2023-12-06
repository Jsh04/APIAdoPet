using APIAdoPet.Domains;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Infraestrutura.Repository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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

    [Theory(DisplayName = "Cadastrar Tutores no banco de dados")]
    [InlineData("Vitor alberto", "vitor@gamil.com", "12345")]
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

    [Theory(Skip = "Teste passando")]
    [InlineData(1)]
    [InlineData(2)]
    public void TestaDeletarTutor(int id)
    {
        _repository.DeletarTutor(id);
        var tutorDeletado = _repository.PegarTutorPorId(id);

        Assert.Null(tutorDeletado);
    }

    [Fact]
    public void TestaAtualizaTutorPeloId() 
    {
        int id = 4;
        var tutor = _repository.PegarTutorPorId(id);
        string telefone = "16523235";
        tutor.Telefone = telefone;
        var tutorAtualizado  = _repository.AtualizarTutor(id, tutor);
        Assert.Equal(telefone, tutorAtualizado.Telefone);

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