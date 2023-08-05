namespace PP.Core.Domain
{
    public class Pessoa
    {
        public int PessoaId { get; set; }   
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public bool IsFuncionario { get; set; }
        public virtual ICollection<Projeto>? Projetos { get; set; }
        public Membro? Membro { get; set; }
    }
}
