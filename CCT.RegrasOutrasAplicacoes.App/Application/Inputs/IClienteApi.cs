namespace CCT.RegrasOutrasAplicacoes.App.Application.Inputs
{
    public interface IClienteApi
    {
        ClienteDto ObterCliente(long numeroCpf);
    }
}
