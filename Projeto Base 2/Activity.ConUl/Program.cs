using System;
using Activity.ObjectModel;
namespace Activity.ConUl
{
    class Program
    {

        static void Main(string[] args)
        {
            Project[] BusinessProject = new Project[10];
            int qtd;
            int qtdUser;
            int qtdTasks;


            void Menu()
            {
                Console.WriteLine("\n\n1 - Criar Lista");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("0 - Sair");
                int opcao = Convert.ToInt16(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quantidade de Projetos: ");
                        qtd = Int16.Parse(Console.ReadLine());

                        for (int i = 0; i < qtd; i++)
                        {

                            BusinessProject[i] = new Project();

                            Console.WriteLine("id do " + (i + 1) + "º projeto");
                            BusinessProject[i].Id = Int32.Parse(Console.ReadLine());

                            Console.WriteLine("Nome do " + (i + 1) + "º projeto");
                            BusinessProject[i].Title = Console.ReadLine();

                            Console.WriteLine("Codigo do " + (i + 1) + "º projeto");
                            BusinessProject[i].Code = Console.ReadLine();

                            Console.WriteLine("Data de inicio do " + (i + 1) + "º projeto");
                            BusinessProject[i].StartDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Data estimada para o fim do " + (i + 1) + "º projeto");
                            BusinessProject[i].EstimatedEndDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Data de conclusão do " + (i + 1) + "º projeto");
                            BusinessProject[i].RealEndDate = DateTime.Parse(Console.ReadLine());

                            Console.WriteLine("Responsável do " + (i + 1) + "º projeto");
                            BusinessProject[i].Responsible.Title = Console.ReadLine();

                            Console.Clear();

                            //USUARIOS POAR

                            Console.WriteLine("Quantidade de Usuários: ");
                            qtdUser = Int16.Parse(Console.ReadLine());

                            for (int j = 0; j < qtdUser; j++)
                            {

                                BusinessProject[i].userList[j] = new Person();

                                Console.WriteLine("id do " + (j + 1) + "º usuario");
                                BusinessProject[i].userList[j].Id = Int32.Parse(Console.ReadLine());

                                Console.WriteLine("Nome do " + (j + 1) + "º usuario");
                                BusinessProject[i].userList[j].Title = Console.ReadLine();

                                Console.WriteLine("Data de nascimento do " + (j + 1) + "º usuario");
                                BusinessProject[i].userList[j].BirthDate = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Email do " + (j + 1) + "º usuario");
                                BusinessProject[i].userList[j].Email = Console.ReadLine();

                                Console.Clear();
                            }


                            //TASKS POARR

                            Console.WriteLine("Quantidade de Tarefas: ");
                            qtdTasks = Int16.Parse(Console.ReadLine());

                            for (int t = 0; t < qtdTasks; t++)
                            {
                                BusinessProject[i].taskList[t] = new Tasks();

                                Console.WriteLine("ID da tarefa: ");
                                BusinessProject[i].taskList[t].Id = Int32.Parse(Console.ReadLine());

                                Console.WriteLine("Nome da tarefa: ");
                                BusinessProject[i].taskList[t].Title = Console.ReadLine();

                                Console.WriteLine("Nome da Responsavel: ");
                                BusinessProject[i].taskList[t].Responsible.Title = Console.ReadLine();

                                Console.WriteLine("Tempo da tarefa: ");
                                BusinessProject[i].taskList[t].WorkHours = Decimal.Parse(Console.ReadLine());

                                Console.WriteLine("Tipo da tarefa:\n1-Codificação\n2-CasosDeTeste\n3-Defeito ");
                                Int16 type = Int16.Parse(Console.ReadLine());

                                switch (type)
                                {
                                    case 1:
                                        BusinessProject[i].taskList[t].TaskType = (ETaskType)ETaskType.Codificação;
                                        break;
                                    case 2:
                                        BusinessProject[i].taskList[t].TaskType = (ETaskType)ETaskType.CasosDeTeste;
                                        break;
                                    case 3:
                                        BusinessProject[i].taskList[t].TaskType = (ETaskType)ETaskType.Defeito;
                                        break;
                                }

                                Console.Clear();
                            }
                        }
                        Menu();
                        break;
                    case 2:
                        for (int p = 0; p < BusinessProject.Length && BusinessProject[p] != null; p++)
                        {

                            Console.WriteLine("\n\nID: " + BusinessProject[p].Id);
                            Console.WriteLine("Nome: " + BusinessProject[p].Title);
                            Console.WriteLine("Codigo: " + BusinessProject[p].Code);
                            Console.WriteLine("Data de Inicio: " + BusinessProject[p].StartDate);
                            Console.WriteLine("Data Estimada: " + BusinessProject[p].EstimatedEndDate);
                            Console.WriteLine("Data de Conclusao: " + BusinessProject[p].RealEndDate);
                            Console.WriteLine("Responsável: " + BusinessProject[p].Responsible.Title);

                            for (int i = 0; i < BusinessProject[p].userList.Length && BusinessProject[p].userList[i] != null; i++)
                            {

                                Console.WriteLine("Id do Usuario: " + BusinessProject[p].userList[i].Id);
                                Console.WriteLine("Nome do Usuario: " + BusinessProject[p].userList[i].Title);
                                Console.WriteLine("Data de Nascimento: " + BusinessProject[p].userList[i].BirthDate);
                                Console.WriteLine("Email do Usuario: " + BusinessProject[p].userList[i].Email);
                            }
                            for (int t = 0; t < BusinessProject[p].taskList.Length && BusinessProject[p].taskList[t] != null; t++)
                            {

                                Console.WriteLine("Id da Tarefa: " + BusinessProject[p].taskList[t].Id);
                                Console.WriteLine("Nome da Tarefa: " + BusinessProject[p].taskList[t].Title);
                                Console.WriteLine("Responsavel pela Tarefa: " + BusinessProject[p].taskList[t].Responsible.Title);
                                Console.WriteLine("Horas Gastas da Tarefa: " + BusinessProject[p].taskList[t].WorkHours);
                                Console.WriteLine("Tipo da tarefa da Tarefa: " + BusinessProject[p].taskList[t].TaskType);
                            }

                            //Console.ReadKey();
                        }

                        Menu();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No one");
                        break;

                }
            }

            Menu();

        }
    }
}
