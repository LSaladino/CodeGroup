using PP.Core.Shared.ModelViews.Projeto;

namespace PP.Core.Shared.ModelViews.Pessoa
{
    public class PessoaView
    {
        public int PessoaId { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public bool IsFuncionario { get; set; }
        public ICollection<ProjetoView>? Projetos { get; set; }  
    }
}
