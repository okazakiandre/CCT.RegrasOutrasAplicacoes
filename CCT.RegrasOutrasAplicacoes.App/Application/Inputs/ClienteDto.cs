namespace CCT.RegrasOutrasAplicacoes.App.Application.Inputs
{
    public class ClienteDto
    {
        public long NumeroCpf { get; set; }
        public string Nome { get; set; } = "";
        public short SituacaoCadastro { get; set; }
        public bool EstaConfirmado { get; set; }

        public bool CadastroConfirmado() => SituacaoCadastro == 2;
    }
}
