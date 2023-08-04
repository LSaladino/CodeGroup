namespace PP.Core.Domain
{
    public class Membro
    {
        public int Id { get; set; }
        public int PessoaId  { get; set;}
        public virtual Pessoa? Pessoa { get; set; }
    }
}
