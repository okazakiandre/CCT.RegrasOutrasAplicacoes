using CCT.RegrasOutrasAplicacoes.App.Application.Inputs;

namespace CCT.RegrasOutrasAplicacoes.App.Infra
{
    internal class ClienteApi : IClienteApi
    {
        public ClienteDto ObterCliente(long numeroCpf)
        {
            return new ClienteDto
            {
                NumeroCpf = numeroCpf,
                Nome = "Cliente 1",
                SituacaoCadastro = 2 
            };

            //Situação do cliente:
            //1 = Pendente de confirmação
            //2 = Confirmado
        }
    }
}
