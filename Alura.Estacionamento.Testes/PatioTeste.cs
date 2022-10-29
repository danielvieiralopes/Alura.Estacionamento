using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            //  var veiculo = new Veiculo();
            veiculo.Proprietario = "Daniel";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Mercedes";
            veiculo.Placa = "ABC-9192";

            //  var estacionamento = new Patio();
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Daniel Alves", "ASD-1353", "Preto", "Fusca")]
        [InlineData("Julio Alves", "GFD-3215", "Branco", "Gol")]
        [InlineData("André Alves", "GHS-7543", "Cinza", "Corsa")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario,
                                                                       string placa,
                                                                       string cor,
                                                                       string modelo)
        {
            //Arrange
            //     var estacionamento = new Patio();

            // var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Act
            double faturamento = estacionamento.TotalFaturado();
            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Daniel Vieira", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario,
                                                         string placa,
                                                         string cor,
                                                         string modelo)
        {

            //Arrange
            //    Patio estacionamento = new Patio();
            // var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlteraDadosVeiculoDoProprioVeiculo()
        {
            //Arrange
            //  Patio estacionamento = new Patio();
            // var veiculo = new Veiculo();
            veiculo.Proprietario = "Joao Lemos";
            veiculo.Placa = "GSD-4215";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
<<<<<<< HEAD

=======
            veiculoAlterado.Proprietario = "Joao Lemos";
            veiculoAlterado.Placa = "GSD-4215";
            veiculoAlterado.Cor = "Branco"; //Alteração
            veiculoAlterado.Modelo = "Opala";
>>>>>>> b8e7743d8ae509977c8cb3428594e7fd68369cc0

            //Act
            Veiculo alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose invocado.");
        }
    }
}
