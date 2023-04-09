namespace CCT.RegrasOutrasAplicacoes.App.Domain
{
    public class Pedido
    {
        public int Codigo { get; set; }
        public short Status { get; set; }
        public long CpfCliente { get; set; }

        public bool EstaPendente() => Status == 1 || Status == 4;
        public bool EstaProntoParaEntrega() => Status == 2;
        public bool FoiEntregue() => Status == 3;
    }

    public enum StatusPedido
    {
        Pendente = 1,
        ProntoParaEntrega = 2,
        Entregue = 3
    }
}
