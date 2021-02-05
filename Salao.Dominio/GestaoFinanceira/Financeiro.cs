using Salao.Dominio.Agendamentos;
using Salao.Dominio.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao.Dominio.GestaoFinanceira
{
    public class Financeiro
    {
        public List<Agendamento> AgendamentosFinalizados { get; set; }
        public List<Agendamento> AgendamentosCancelados { get; set; }

        public Financeiro() 
        {
            AgendamentosFinalizados = new List<Agendamento>();
            AgendamentosCancelados = new List<Agendamento>();
        }

        public double LucroDiario(DateTime data)
        {
            var servicosDiarios = AgendamentosFinalizados.FindAll(a => a.Data.Value.Date == data.Date);

            double lucro = (double)servicosDiarios.Sum(s => s.Servico.Servico.Preco);
            return lucro * 0.70;
        }

        public double LucroMensal(DateTime data)
        {
            var servicosMensal = AgendamentosFinalizados.FindAll(a => 
            a.Data.Value.Date.Month == data.Date.Month &&
            a.Data.Value.Date.Year == data.Date.Year);

            double lucro = (double)servicosMensal.Sum(s => s.Servico.Servico.Preco);
            return lucro * 0.70;
        }

        public double LucroAnual(DateTime data)
        {
            var servicosAnual = AgendamentosFinalizados.FindAll(a =>
            a.Data.Value.Date.Year == data.Date.Year );

            double lucro = (double)servicosAnual.Sum(s => s.Servico.Servico.Preco);
            return lucro * 0.70;
        }

        public double PagarSalario(DateTime data, string nome)
        {
            var funcionario = AgendamentosFinalizados
                .FindAll(f => f.Servico.Funcionario.Nome == nome &&
                f.Data.Value.Date.Month == data.Date.Month &&
                f.Data.Value.Date.Year == data.Date.Year);

            double salarioMensal = (double)funcionario.Sum(s => s.Servico.Servico.Preco);
            
            return salarioMensal * 0.30;
        }

    }
}
