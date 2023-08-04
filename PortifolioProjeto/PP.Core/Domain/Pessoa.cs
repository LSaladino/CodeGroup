﻿namespace PP.Core.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? CPF { get; set; }
        public bool IsFuncionario { get; set; } 
        public ICollection<Membro>? Membro { get; set; }
        public ICollection<Projeto>? Projeto { get; set; }
    }
}