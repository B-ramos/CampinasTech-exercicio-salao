using Salao.Dominio.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.BaseDeDados
{
    public class DB_Funcionarios
    {
        public List<Funcionario> BaseFuncionarios { get; set; }

        public DB_Funcionarios()
        {
            BaseFuncionarios = new List<Funcionario>();
        }

        public void Incluir(Funcionario funcionario)
        {
            BaseFuncionarios.Add(funcionario);
        }
    }
}
