using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        [Fact(DisplayName ="Teste nº1")]
        [Trait("Funcionalidade","Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100,veiculo.VelocidadeAtual);
        }

      
        [Fact(DisplayName ="Teste nº2")]
        [Trait("Funcionalidade","Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {

            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaModeloVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Modelo = "BMW";
            //Assert
            Assert.Equal("BMW", veiculo.Modelo);
        }

        [Fact(DisplayName="Teste nº3",Skip = "Teste ainda nao implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }



    }
}