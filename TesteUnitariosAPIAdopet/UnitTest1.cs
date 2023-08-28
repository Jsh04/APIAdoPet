using APIAdoPet.Infraestrutura.Data;

namespace TesteUnitariosAPIAdopet;

public class UnitTest1
{
    [Fact]
    public void TesteDeConexaoDoBancoDeDados()
    {
        var context = new APIAdopetContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIAdopetContext>());
        var resultado = context.Database.CanConnect();
        Assert.True(resultado);
       
    }
}