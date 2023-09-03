using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace TesteUnitariosAPIAdopet;

public class UnitTest1
{

    private readonly ITutorRepository _repository;

    private readonly ITestOutputHelper _helper;

    public UnitTest1(ITestOutputHelper helper)
    {
        var servico = new ServiceCollection();
        servico.AddTransient<ITutorRepository, TutorRepository>();
        var provedor = servico.BuildServiceProvider();
        _repository = provedor.GetService<ITutorRepository>()!;
        _helper = helper;
    }
    [Fact]
    public void ListarTodosOsTutoresDiferenteDeNull()
    {
        var options = new DbContextOptionsBuilder<APIAdopetContext>()
            .Options;
        try
        {
            var tutores = _repository.ListarTutor(0, 5);

            Assert.NotNull(tutores);
        }catch(Exception ex)
        {
            _helper.WriteLine(ex.Message);
        }
        
        
       
    }
}