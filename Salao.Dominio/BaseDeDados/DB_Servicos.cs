using Salao.Dominio.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.BaseDeDados
{
    public class DB_Servicos
    {
        public List<Servico> BaseServico { get; set; }

        public DB_Servicos()
        {
            BaseServico = new List<Servico>();
        }

        public void Incluir(Servico servico)
        {
            BaseServico.Add(servico);
        }
    }
}
