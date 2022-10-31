using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            this.SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }
        
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100,veiculo.VelocidadeAtual);
            //teste
        }

      
        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
           // var veiculo = new Veiculo();

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
           // var veiculo = new Veiculo();

            //Act
            veiculo.Modelo = "BMW";
            //Assert
            Assert.Equal("BMW", veiculo.Modelo);
        }

        [Fact(DisplayName="Teste nº3",Skip = "Teste ainda nao implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();

            veiculo.Proprietario = "Jose alves";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "FGA-2314";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Ferrari";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaractereres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF9999";

            //Assert
            var mensagem = Assert.Throws<System.FormatException>(
                //Act
                () => new Veiculo().Placa = placa
                
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }
    }
}