using Salao.Dominio.Agendamentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.BaseDeDados
{
    public class DB_Agendamento
    {
        public List<Agendamento> Agenda { get; set; }

        public DB_Agendamento()
        {
            Agenda = new List<Agendamento>();
        }

        public void Incluir(Agendamento novoAgendamento)
        {
            Agenda.Add(novoAgendamento);
        }

    }
}
