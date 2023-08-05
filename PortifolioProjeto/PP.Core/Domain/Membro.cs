using System.ComponentModel.DataAnnotations.Schema;

namespace PP.Core.Domain
{
    public class Membro
    {
        [NotMapped]
        public int MembroId { get; set; }   
        public int ProjetoId { get; set; }  
        public Projeto? Projeto { get; set; }
        public int PessoaId { get; set; }   
        public Pessoa? Pessoa { get; set; }     
        
    }
}
