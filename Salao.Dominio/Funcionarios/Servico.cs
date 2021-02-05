using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.Funcionarios
{
    public class Servico
    {
        static int IdAutoIncremente = 1;
        private int Id { get; }
        public string Nome { get; set; }
        public int MinutosParaExecucao { get; set; }
        public decimal Preco { get; set; }
        public CategoriaServico Categotia { get; set; }

        public enum CategoriaServico
        {
            Cabelereiro,
            Manicure,
            Esteticista,
            Barbeiro
        }

        public Servico(string nome, int minutosParaExecucao, decimal preco, CategoriaServico categoria)
        {
            Id = IdAutoIncremente;
            IdAutoIncremente ++;
            Nome = nome;
            MinutosParaExecucao = minutosParaExecucao;
            Preco = preco;
            Categotia = categoria;
        }
        public int RetornaId(Servico servico)
        {
            return servico.Id;
        }

    }
}
