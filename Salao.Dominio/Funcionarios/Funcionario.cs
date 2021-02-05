using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.Funcionarios
{
    public class Funcionario
    {
        static int matriculaAutoIncremente = 1;
        private int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        
        public Endereco Endereco { get; set; }
        public List<CargoFuncionario> CargoFuncionario { get; set; }

        public Funcionario(string nome, string telefone, Endereco endereco)
        {
            CargoFuncionario = new List<CargoFuncionario>();

            Matricula = matriculaAutoIncremente;
            matriculaAutoIncremente++;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }

        public int RetornaMatricula(Funcionario funcionario)
        {
            return funcionario.Matricula;
        }

        public void IncluirCargo(CargoFuncionario cargo)
        {
            CargoFuncionario.Add(cargo);
        }      

    }
}
