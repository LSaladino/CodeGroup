using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Core.Domain
{
    public class Membro
    {
        public int Id { get; set; }

        public int PessoaId  { get; set;}
        [ForeignKey("PessoaId")]
        public virtual Pessoa? Pessoa { get; set;}
    }
}
