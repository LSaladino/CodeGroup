using PP.Core.Shared.ModelViews.Pessoa;

namespace PP.Core.Shared.ModelViews.Projeto
{
    public class NovoProjeto
    {
        public string? Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevisaoFim { get; set; }
        public DateTime DataFim { get; set; }
        public string? Descricao { get; set; }
        public string? Status { get; set; }
        public double Orcamento { get; set; }
        public string? Risco { get; set; }
        public int PessoaId { get; set; }
        public NovaPessoa? Pessoa { get; set; }
        //public NovoMembro? Membro { get; set; }
    }
}
