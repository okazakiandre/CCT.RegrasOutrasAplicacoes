using CCT.RegrasOutrasAplicacoes.App.Application.Inputs;

namespace CCT.RegrasOutrasAplicacoes.UnitTest
{
    [TestClass]
    public class ClienteDtoTest
    {
        [TestMethod]
        public void DeveriaIndicarQueOCadastroFoiConfirmado()
        {
            var clienteDto = new ClienteDto { SituacaoCadastro = 2 };
            var result = clienteDto.CadastroConfirmado();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NaoDeveriaIndicarQueOCadastroFoiConfirmado()
        {
            var clienteDto = new ClienteDto { SituacaoCadastro = 1 };
            var result = clienteDto.CadastroConfirmado();
            Assert.IsFalse(result);
        }
    }
}
