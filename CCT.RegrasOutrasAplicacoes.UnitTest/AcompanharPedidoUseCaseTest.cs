using CCT.RegrasOutrasAplicacoes.App.Application.Inputs;
using CCT.RegrasOutrasAplicacoes.App.Application.UseCases;
using CCT.RegrasOutrasAplicacoes.App.Domain;
using Moq;

namespace CCT.RegrasOutrasAplicacoes.UnitTest
{
    [TestClass]
    public class AcompanharPedidoUseCaseTest
    {
        [TestMethod]
        public void DeveriaRetornarPedidoNaoProcessadoParaStatusPendenteEClienteConfirmado()
        {
            var mockCliApi = new Mock<IClienteApi>();
            mockCliApi.Setup(x => x.ObterCliente(It.IsAny<long>())).Returns(new ClienteDto { SituacaoCadastro = 2 });
            var pedido = new Pedido { Status = 1 };
            var acompanharPedidoUseCase = new AcompanharPedidoUseCase(mockCliApi.Object);

            var result = acompanharPedidoUseCase.Executar(pedido);

            Assert.AreEqual("O pedido ainda não foi processado.", result);
        }

        [TestMethod]
        public void DeveriaRetornarCadastroNaoConfirmadoParaStatusPendenteEClienteNaoConfirmado()
        {
            var mockCliApi = new Mock<IClienteApi>();
            mockCliApi.Setup(x => x.ObterCliente(It.IsAny<long>())).Returns(new ClienteDto { SituacaoCadastro = 1 });
            var pedido = new Pedido { Status = 1 };
            var acompanharPedidoUseCase = new AcompanharPedidoUseCase(mockCliApi.Object);

            var result = acompanharPedidoUseCase.Executar(pedido);

            Assert.AreEqual("O cadastro não foi confirmado, verifique seu e-mail.", result);
        }

        [TestMethod]
        public void DeveriaRetornarPedidoEnviadoParaStatus2()
        {
            var mockCliApi = new Mock<IClienteApi>();
            var pedido = new Pedido { Status = 2 };
            var acompanharPedidoUseCase = new AcompanharPedidoUseCase(mockCliApi.Object);

            var result = acompanharPedidoUseCase.Executar(pedido);

            Assert.AreEqual("O pedido foi enviado para a transportadora.", result);
        }

        [TestMethod]
        public void DeveriaRetornarPedidoEntregueParaStatus3()
        {
            var mockCliApi = new Mock<IClienteApi>();
            var pedido = new Pedido { Status = 3 };
            var acompanharPedidoUseCase = new AcompanharPedidoUseCase(mockCliApi.Object);

            var result = acompanharPedidoUseCase.Executar(pedido);

            Assert.AreEqual("O pedido foi entregue.", result);
        }
    }
}