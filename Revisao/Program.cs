using System;
using System.Collections.Generic;
namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Aluno> alunos = new List<Aluno>();
            Console.Clear();
            string opcaoSelecionada = ObterOpcaousuario();
            while(opcaoSelecionada.ToUpper() != "X")
            {
                Console.Clear();
                switch (opcaoSelecionada)
                {
                    case "1":
                        Aluno aluno = InserirNovoAluno(new Aluno());
                        alunos.Add(aluno);
                        break;
                    case "2":
                        ExibirAlunos(alunos);
                        break;
                    case "3":
                        SomarMediaNotasAlunos(alunos);
                        break;
                    default:
                        Console.WriteLine("Opção invalida, digite alguma tecla para retornar ao menu");
                        Console.ReadKey();
                        break;
                }
                
                opcaoSelecionada = ObterOpcaousuario();
            }


        }
        private static string ObterOpcaousuario() {
            Console.WriteLine("\n######## MENU ########\n");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno:");
            Console.WriteLine("2 - Listar alunos:");
            Console.WriteLine("3 - Calcular média geral:");
            Console.WriteLine("X - Sair:\n");
            
            string opcaoSelecionada = Console.ReadLine();
            return opcaoSelecionada;
        }

        private static Aluno InserirNovoAluno(Aluno aluno){

            Console.WriteLine("Cadastro de alunos:\n");
            Console.WriteLine("Informe o nome do aluno:");
            aluno.nome = Console.ReadLine();

            Console.WriteLine("Informe a nota do aluno:");
            if(decimal.TryParse(Console.ReadLine(), out decimal nota)) {
                aluno.nota =  nota;
            }
            Console.Clear();
            return aluno;
        }
        private static void ExibirAlunos(List<Aluno>  alunos){
            Console.WriteLine("Lista de alunos cadastrados:\n");
            foreach (Aluno aluno in alunos)
            {
                Console.WriteLine("Nome: {0}\t\t Nota: {1}", aluno.nome, aluno.nota);
            }

        }

        private static void SomarMediaNotasAlunos(List<Aluno>  alunos){
            decimal media = 0;
            if(alunos.Count > 0) {
                decimal totalNotas = 0;
                foreach (Aluno aluno in alunos)
                {
                    totalNotas+= aluno.nota;
                }
                
                media = totalNotas/alunos.Count;
            }

            Console.WriteLine("Média das notas dos alunos: {0}", media);
        }

    }
}
