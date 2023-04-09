using CCT.RegrasOutrasAplicacoes.App.Application.Inputs;
using CCT.RegrasOutrasAplicacoes.App.Domain;

namespace CCT.RegrasOutrasAplicacoes.App.Application.UseCases
{
    public class AcompanharPedidoUseCase
    {
        private IClienteApi CliApi { get; }

        public AcompanharPedidoUseCase(IClienteApi cliApi)
        {
            CliApi = cliApi;
        }

        public string Executar(Pedido pedido)
        {
            var msg = "";
            if (pedido.EstaPendente())
            {
                var cliente = CliApi.ObterCliente(pedido.CpfCliente);
                if (cliente.EstaConfirmado)
                {
                    msg = "O pedido ainda não foi processado.";
                }
                else
                {
                    msg = "O cadastro não foi confirmado, verifique seu e-mail.";
                }
            }
            else if (pedido.EstaProntoParaEntrega())
            {
                msg = "O pedido foi enviado para a transportadora.";
            }
            else if (pedido.FoiEntregue())
            {
                msg = "O pedido foi entregue.";
            }
            return msg;
        }
    }
}
