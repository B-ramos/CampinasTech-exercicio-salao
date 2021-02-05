using Salao.Dominio.Clientes;
using Salao.Dominio.GestaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao.Dominio.Agendamentos
{
    public class Agendamento
    {
        static int IdAutoIncremente = 1;
        private int Id { get; }
        public Cliente Cliente { get; set; }
        public DateTime? Data { get; set; }
        public string Anotacao { get; set; }
        public ServicoSolicitado Servico { get; set; }
        public StatusAgendamento Status { get; set; }
        public enum StatusAgendamento
        {
            Pendente,
            Realizado,
            Reagendado,
            CanceladoPeloCliente,
            NaoCompareceu,
            CanceladoPeloSalao,
        }

        public Agendamento()
        {
            Id = IdAutoIncremente;
            IdAutoIncremente ++;
        }

        public int RetornaId(Agendamento agendamento)
        {
            return agendamento.Id;
        }
        public bool Incluir(Cliente cliente, ServicoSolicitado servico, DateTime data,
            List<Agendamento> agenda, string anotacao = "")
        {
            if (PermiteAgendar(agenda, servico, data))
            {
                return false;
            }
            else
            {
                Cliente = cliente;
                Servico = servico;
                Data = data;
                Anotacao = anotacao;
                return true;
            }
        }

        public bool AlterarAgendamento(Cliente cliente, ServicoSolicitado novoServico,
            DateTime novaData, List<Agendamento> agenda, string novaAnotacao = "")
        {
            if (PermiteAgendar(agenda, novoServico, novaData))
            {
                return false;
            }
            else
            {
                novoServico.Status = ServicoSolicitado.StatusServico.Reagendado;
                Cliente = cliente;
                Servico = novoServico;
                Data = novaData;
                Anotacao = novaAnotacao;

                return true;
            }
        }

        private bool PermiteAgendar(List<Agendamento> agenda, ServicoSolicitado servicoParaAgendar, DateTime dataAgendamento)
        {
            DateTime dataTerminoParaAgendar = dataAgendamento.AddMinutes(servicoParaAgendar.Servico.MinutosParaExecucao);

            return (agenda.Any(a => a.Data >= dataAgendamento &&  
                    (a.Servico.Funcionario.CargoFuncionario == servicoParaAgendar.Funcionario.CargoFuncionario) &&
                    (a.Status != StatusAgendamento.CanceladoPeloSalao || a.Status != StatusAgendamento.CanceladoPeloCliente)) &&
                agenda.Any(a => a.Data <= dataTerminoParaAgendar &&
                    (a.Status != StatusAgendamento.CanceladoPeloSalao || a.Status != StatusAgendamento.CanceladoPeloCliente)) ||
                    dataAgendamento < DateTime.Now);

        }

        public void AlterarStatus(Agendamento agendamento, Agendamento.StatusAgendamento novoStatus, Financeiro financeiro)
        {
            
            if (agendamento == null)
                 return;

            if(novoStatus == StatusAgendamento.Realizado)
            {
                agendamento.Status = novoStatus;
                financeiro.AgendamentosFinalizados.Add(agendamento);
            }
            else if (novoStatus == StatusAgendamento.CanceladoPeloCliente ||
                novoStatus == StatusAgendamento.CanceladoPeloSalao ||
                novoStatus == StatusAgendamento.NaoCompareceu)
            {
                agendamento.Status = novoStatus;
                agendamento.Data = null;
                financeiro.AgendamentosCancelados.Add(agendamento);
            }
            else
            {
                agendamento.Status = novoStatus;
            }  
        }

    }
}
