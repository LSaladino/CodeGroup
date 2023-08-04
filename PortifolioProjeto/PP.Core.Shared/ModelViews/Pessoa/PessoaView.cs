namespace PP.Core.Shared.ModelViews.Pessoa
{
    public class PessoaView
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public bool IsFuncionario { get; set; }
    }
}
