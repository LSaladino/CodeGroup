﻿namespace PP.Core.Domain
{
    public class Projeto
    {
        public int ProjetoId { get; set; }      
        public string? Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevisaoFim { get; set; }
        public DateTime DataFim { get; set; }
        public string? Descricao { get; set; }
        public string? Status { get; set; }
        public double Orcamento { get; set; }
        public string? Risco { get; set; }
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public Membro? Membro { get; set; }
    }
}
