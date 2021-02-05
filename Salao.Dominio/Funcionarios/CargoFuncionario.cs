using Salao.Dominio.BaseDeDados;
using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.Funcionarios
{
    public class CargoFuncionario
    {
        public CargosFuncionarios Cargos { get; set; }
        public List<Servico> Servicos { get; set; }

        public enum CargosFuncionarios
        {
            Cabelereiro,
            Manicure,
            Esteticista,
            Barbeiro
        }

        public void Incluir(CargoFuncionario.CargosFuncionarios cargo, List<Servico> servicos)
        {
            Cargos = cargo;   
            if(cargo == CargosFuncionarios.Cabelereiro)
            {
                Servicos = servicos.FindAll(s => s.Nome.Equals("Corte de cabelo") ||
                s.Nome.Equals("Escova de cabelo"));
            }
            else if(cargo == CargosFuncionarios.Barbeiro)
            {
                Servicos = servicos.FindAll(s => s.Nome.Equals("Cabelo e barba"));
            }
            else if (cargo == CargosFuncionarios.Esteticista)
            {
                Servicos = servicos.FindAll(s => s.Nome.Equals("Limpeza de pele"));
            }
            else
            {
                Servicos = servicos.FindAll(s => s.Nome.Equals("Manicure") ||
                s.Nome.Equals("Pedicure"));
            }
        }
    }
}
