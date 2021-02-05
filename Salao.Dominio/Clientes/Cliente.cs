using System;

namespace Salao.Dominio.Clientes
{
    public class Cliente
    {
        private int Id { get; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        static int IdAutoIncremente = 1;

        public Cliente(string nome, string telefone, string cpf)
        {
            Id = IdAutoIncremente;
            IdAutoIncremente++;
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
        }

        public int RetornaId(Cliente cliente)
        {
            return cliente.Id;
        }

        public void AlterarCliente(string nome, string telefone)
        {
            Nome = string.IsNullOrEmpty(nome) ? Nome : nome;
            Telefone = string.IsNullOrEmpty(telefone) ? Telefone : telefone;
        }
    }
}
