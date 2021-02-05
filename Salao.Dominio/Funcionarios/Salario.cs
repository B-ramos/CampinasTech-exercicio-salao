using System;
using System.Collections.Generic;
using System.Text;

namespace Salao.Dominio.Funcionarios
{
    public class Salario
    {
        public DateTime Data { get; set; }
        public double SalarioMensal { get; set; }

        public void incluir(DateTime data, double salario)
        {
            Data = Data;
            SalarioMensal = salario;
        }
    }
}
