using Salao.Dominio.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Salao.Dominio.Agendamentos
{
    public class ServicoSolicitado
    {
        static int IdAutoIncremente = 1;
        public int Id { get; }
        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }
        
        public StatusServico Status { get; set; }

        public enum StatusServico
        {
            Pendente,
            Reagendado,
            CanceladoPeloCliente,
            CanceladoPeloSalao,
            Realizado
        }

        public ServicoSolicitado()
        {
            Id = IdAutoIncremente;
            IdAutoIncremente++;
        }

        public void Incluir(Servico servico, List<Funcionario> funcionario)
        {
            CargoFuncionario.CargosFuncionarios cg;
            if (servico.Categotia == Servico.CategoriaServico.Barbeiro)
                cg = CargoFuncionario.CargosFuncionarios.Barbeiro;
            else if(servico.Categotia == Servico.CategoriaServico.Cabelereiro)
                cg = CargoFuncionario.CargosFuncionarios.Cabelereiro;
            else if (servico.Categotia == Servico.CategoriaServico.Esteticista)
                cg = CargoFuncionario.CargosFuncionarios.Esteticista;
            else 
                cg = CargoFuncionario.CargosFuncionarios.Manicure;            

            Funcionario = funcionario
                .Find(f => f.CargoFuncionario
                .Exists(c => c.Cargos.Equals(cg))); 

            Servico = servico;           
        }

        public void Incluir(object p, List<Funcionario> funcionarios)
        {
            throw new NotImplementedException();
        }
    }
}
