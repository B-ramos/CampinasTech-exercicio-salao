using Salao.Dominio.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao.Dominio.BaseDeDados
{
    public class DB_Clientes
    {
        public List<Cliente> BaseClientes { get; set; }

        public DB_Clientes()
        {
            BaseClientes = new List<Cliente>();
        }

        public void Incluir(Cliente cliente)
        {
            BaseClientes.Add(cliente);
        }

        public void AlterarCliente(string cpf, string novoNome, string novoTelefone )
        {
            Cliente cliente = BaseClientes.FirstOrDefault(c => c.CPF.Equals(cpf));

            if (cliente != null)            
                cliente.AlterarCliente(novoNome, novoTelefone); 
        }
        public void ExcluirUmCliente(string cpf)
        {
            BaseClientes.RemoveAll(c => c.CPF.Equals(cpf));
        }
    }
}
