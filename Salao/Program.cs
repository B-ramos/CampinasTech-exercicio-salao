using Salao.Dominio;
using Salao.Dominio.Agendamentos;
using Salao.Dominio.BaseDeDados;
using Salao.Dominio.Clientes;
using Salao.Dominio.Funcionarios;
using Salao.Dominio.GestaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Salao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var financeiro = new Financeiro();
                var meusClientes = IncluirCliente();
                var servicosSalao = IncluirServico();
                var meusFuncionarios = IncluirFuncionario();
                var agenda = IncluirAgendamento(meusFuncionarios.BaseFuncionarios, servicosSalao.BaseServico, meusClientes.BaseClientes, financeiro);
                //Alterar um cliente.
                //meusClientes.AlterarCliente("11111111111", "Carlos", "333333333");
                //Excluir um cliente.
                //meusClientes.ExcluirUmCliente("11111111111");

                //Console.WriteLine("Clientes cadastrados:");
                //foreach (var cliente in meusClientes.BaseClientes)
                //{
                //    Console.WriteLine($"    ID: {cliente.RetornaId(cliente)}");
                //    Console.WriteLine($"    Nome: {cliente.Nome}");
                //    Console.WriteLine($"    Telefone: {cliente.Telefone}");
                //    Console.WriteLine($"    CPF: {cliente.CPF}");
                //    Console.WriteLine("");
                //}

                //Console.WriteLine("Servicos do Salao:");
                //foreach (var servico in servicosSalao.BaseServico)
                //{
                //    Console.WriteLine($"    ID: {servico.RetornaId(servico)}");
                //    Console.WriteLine($"    Nome: {servico.Nome}");
                //    Console.WriteLine($"    Tempo de execução: {servico.MinutosParaExecucao}");
                //    Console.WriteLine($"    Preço R$:{servico.Preco}");
                //    Console.WriteLine("");
                //}

                //Console.WriteLine("Funcionarios do Salao:");
                //foreach (var funcionario in meusFuncionarios.BaseFuncionarios)
                //{
                //    Console.WriteLine($"    Matricula: {funcionario.RetornaMatricula(funcionario)}");
                //    Console.WriteLine($"    Nome: {funcionario.Nome}");
                //    Console.WriteLine($"    Telefone: {funcionario.Telefone}");
                //    foreach (var cargo in funcionario.CargoFuncionario)
                //    {
                //        Console.WriteLine($"    Cargo: {cargo.Cargos}");
                //        foreach (var servico in cargo.Servicos)
                //        {
                //            Console.WriteLine($"    - Serviço: {servico.Nome}");                            
                //        }
                //    }
                //    Console.WriteLine("");
                //}

                //foreach (var ag in agenda.Agenda)
                //{
                //    Console.WriteLine($"Cliente: {ag.Cliente.Nome}");                    
                //    Console.WriteLine($"Data: {ag.Data}");
                //    Console.WriteLine($"    Servico Solicitado: {ag.Servico.Servico.Nome}");
                //    Console.WriteLine($"    R$:{ag.Servico.Servico.Preco}");
                //    Console.WriteLine($"    Tempo de servicço: {ag.Servico.Servico.MinutosParaExecucao}");
                //    Console.WriteLine($"Funcionário");
                //    Console.WriteLine($"    Nome: {ag.Servico.Funcionario.Nome}");
                //    Console.WriteLine($"    Status: {ag.Status}");

                //    Console.WriteLine();                    
                //}

                GestaoFinanceira(financeiro, meusFuncionarios.BaseFuncionarios);

            }
            catch (Exception)
            {
                Console.WriteLine("Deu ruim!!!");
            }
        }

        static DB_Clientes IncluirCliente()
        {
            Cliente c1 = new Cliente("Bruno", "111111111", "11111111111");
            Cliente c2 = new Cliente("Karina", "22222222", "222222222");
            Cliente c3 = new Cliente("João", "333333333", "333333333");

            DB_Clientes db_clientes = new DB_Clientes();

            db_clientes.Incluir(c1);
            db_clientes.Incluir(c2);
            db_clientes.Incluir(c3);

            return db_clientes;
        }

        static DB_Servicos IncluirServico()
        {
            Servico s1 = new Servico("Corte de cabelo", 59, 80, Servico.CategoriaServico.Cabelereiro); 
            Servico s2 = new Servico("Escova de cabelo", 59, 60, Servico.CategoriaServico.Cabelereiro); 
            Servico s3 = new Servico("Manicure", 29, 20, Servico.CategoriaServico.Manicure); 
            Servico s4 = new Servico("Pedicure", 29, 40, Servico.CategoriaServico.Manicure);
            Servico s5 = new Servico("Limpeza de pele", 29, 80, Servico.CategoriaServico.Esteticista);
            Servico s6 = new Servico("Cabelo e barba", 59, 70, Servico.CategoriaServico.Barbeiro);

            DB_Servicos db_servico = new DB_Servicos();

            db_servico.Incluir(s1);
            db_servico.Incluir(s2);
            db_servico.Incluir(s3);
            db_servico.Incluir(s4);
            db_servico.Incluir(s5);
            db_servico.Incluir(s6);

            return db_servico;
        }               

        static DB_Funcionarios IncluirFuncionario()
        {
            Endereco enderco = new Endereco("Av Paulista", "09999-030","Vila", "São Paulo", "SP", "1000", "");

            Funcionario f1 = new Funcionario("Paulo", "111111111", enderco );
            Funcionario f2 = new Funcionario("Maria", "222222222", enderco );
            Funcionario f3 = new Funcionario("Luiza", "333333333", enderco );
            Funcionario f4 = new Funcionario("Cleber", "444444444", enderco );

            CargoFuncionario cargo1 = new CargoFuncionario();
            CargoFuncionario cargo2 = new CargoFuncionario();
            CargoFuncionario cargo3 = new CargoFuncionario();
            CargoFuncionario cargo4 = new CargoFuncionario();

            cargo1.Incluir(CargoFuncionario.CargosFuncionarios.Cabelereiro, IncluirServico().BaseServico);
            cargo2.Incluir(CargoFuncionario.CargosFuncionarios.Manicure, IncluirServico().BaseServico);
            cargo3.Incluir(CargoFuncionario.CargosFuncionarios.Esteticista, IncluirServico().BaseServico);
            cargo4.Incluir(CargoFuncionario.CargosFuncionarios.Barbeiro, IncluirServico().BaseServico);

            f1.IncluirCargo(cargo1);            
            f2.IncluirCargo(cargo2);
            f3.IncluirCargo(cargo3);
            f4.IncluirCargo(cargo4);

            DB_Funcionarios db_funcionario = new DB_Funcionarios();
            db_funcionario.Incluir(f1);
            db_funcionario.Incluir(f2);
            db_funcionario.Incluir(f3);
            db_funcionario.Incluir(f4);

            return db_funcionario;
        }

        static DB_Agendamento IncluirAgendamento(List<Funcionario> funcionarios, List<Servico> servicos, List<Cliente> cliente, Financeiro financeiro)
        {
            DB_Agendamento db_agenda = new DB_Agendamento();

            ServicoSolicitado s1 = new ServicoSolicitado();            
            s1.Incluir(servicos.FirstOrDefault(s => s.Categotia.Equals(Servico.CategoriaServico.Barbeiro)), funcionarios);

            ServicoSolicitado s2 = new ServicoSolicitado();
            s2.Incluir(servicos.FirstOrDefault(s => s.Categotia.Equals(Servico.CategoriaServico.Cabelereiro)), funcionarios);

            ServicoSolicitado s3 = new ServicoSolicitado();
            s3.Incluir(servicos.FirstOrDefault(s => s.Categotia.Equals(Servico.CategoriaServico.Esteticista)), funcionarios);

            Agendamento ag1 = new Agendamento();
            bool resposta = ag1.Incluir(cliente[0], s1, new DateTime(2021, 2, 5, 20, 0, 0), db_agenda.Agenda, "");
            VerificaHorario(resposta, db_agenda, ag1);

            Agendamento ag2 = new Agendamento();
            bool resposta2 = ag2.Incluir(cliente[1], s2, new DateTime(2021, 2, 5, 20, 0, 0), db_agenda.Agenda, "");
            VerificaHorario(resposta2, db_agenda, ag2);

            Agendamento ag3 = new Agendamento();
            bool resposta3 = ag3.Incluir(cliente[2], s3, new DateTime(2021, 2, 5, 20, 0, 0), db_agenda.Agenda, "");
            VerificaHorario(resposta3, db_agenda, ag3);

            Agendamento ag4 = new Agendamento();
            bool resposta4 = ag4.Incluir(cliente[2], s3, new DateTime(2021, 2, 5, 20, 0, 0), db_agenda.Agenda, "");
            VerificaHorario(resposta4, db_agenda, ag4);

            bool respostaReagendamento = ag1.AlterarAgendamento(ag1.Cliente, s1, new DateTime(2021, 2, 5, 21, 0, 0), db_agenda.Agenda, "");
            FazerReagendamento(respostaReagendamento);

            ag1.AlterarStatus(ag2, Agendamento.StatusAgendamento.Realizado, financeiro);
            ag2.AlterarStatus(ag1, Agendamento.StatusAgendamento.Realizado, financeiro);
            ag2.AlterarStatus(ag3, Agendamento.StatusAgendamento.CanceladoPeloSalao, financeiro);

            return db_agenda;
        }

        static void VerificaHorario(bool resposta, DB_Agendamento db_agenda, Agendamento ag)
        {
            if (resposta)
            {
                db_agenda.Incluir(ag);
                Console.WriteLine("Agendado com sucesso.");
            }
            else
                Console.WriteLine("Horário indisponível.");
        }

        static void FazerReagendamento(bool respota)
        {
            if(respota)
                Console.WriteLine("Reagendado com sucesso.");
            else
                Console.WriteLine("Horário para reagendar indisponível.");
        }

        static void GestaoFinanceira(Financeiro financeiro, List<Funcionario> funcionario)
        {
            Console.WriteLine("Agenda de servços finalizados:");
            foreach(var agendamento in financeiro.AgendamentosFinalizados)
            {
                Console.WriteLine($"Serviço: {agendamento.RetornaId(agendamento)}");
                Console.WriteLine($"    Nome: {agendamento.Cliente.Nome}");
                Console.WriteLine($"    Serviço: {agendamento.Servico.Servico.Nome}");
                Console.WriteLine($"    Status: {agendamento.Status}");
                Console.WriteLine($"    Preço R$: {agendamento.Servico.Servico.Preco}");
                Console.WriteLine($"    Preço R$: {agendamento.Data}");
                Console.WriteLine($"    Funcionario: {agendamento.Servico.Funcionario.Nome}");
            }
            Console.WriteLine("");

            Console.WriteLine("Agenda de serviços Cancelados:");
            foreach (var agendamento in financeiro.AgendamentosCancelados)
            {
                Console.WriteLine($"Serviço: {agendamento.RetornaId(agendamento)}");
                Console.WriteLine($"    Nome: {agendamento.Cliente.Nome}");
                Console.WriteLine($"    Serviço: {agendamento.Servico.Servico.Nome}");
                Console.WriteLine($"    Status: {agendamento.Status}");
                Console.WriteLine($"    Funcionario: {agendamento.Servico.Funcionario.Nome}");

            }
            Console.WriteLine("");

            double lucroDoDia = financeiro.LucroDiario(new DateTime(2021, 2, 5, 20, 0, 0));
            Console.WriteLine($"O lucro do dia foi de R$:{lucroDoDia}");

            double lucroDoMes = financeiro.LucroMensal(new DateTime(2021, 2, 5, 20, 0, 0));
            Console.WriteLine($"O lucro do Mês foi de R$:{lucroDoMes}");

            double lucroAnual = financeiro.LucroAnual(new DateTime(2021, 2, 5, 20, 0, 0));
            Console.WriteLine($"O lucro Anual foi de R$:{lucroAnual}");

            double salarioFuncionario = financeiro
                .PagarSalario(new DateTime(2021, 2, 5, 20, 0, 0), "Paulo");           
            Console.WriteLine($"O Salario Paulo  R$:{salarioFuncionario}");

            double salarioFuncionario2 = financeiro
                .PagarSalario(new DateTime(2021, 2, 5, 20, 0, 0), "Cleber");
            Console.WriteLine($"O Salario Cleber R$:{salarioFuncionario2}");


        }
    }

}
