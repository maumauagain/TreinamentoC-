using System;
using Activity.ObjectModel;
using System.Collections.Generic;

namespace Activity.ConUl
{
    class Program
    {

        static void Main(string[] args)
        {
            Project[] BusinessProject = new Project[10];

             void Menu()
            {
                Console.WriteLine("1- Criar Projeto");
                Console.WriteLine("2- Listar Projeto");
                Console.WriteLine("3- Atualizar Projeto");
                Console.WriteLine("4- Deletar Projeto");
                Console.WriteLine("0- Finalizar Programa!!!");

                int opcao = Int16.Parse(Console.ReadLine());
                int qtdProj;
                int qtdUser;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Quantidade de projetos!");
                        qtdProj = Int16.Parse(Console.ReadLine());
                        
                        for(int p = 0; p < qtdProj; p++)
                        {
                            criaProjeto(p);

                            Console.Clear();

                            //USUARIOS DO PROJETO

                            Console.WriteLine("Quantidade de Usuarios: ");
                            qtdUser = Int16.Parse(Console.ReadLine());

                            criaUsuario(p, qtdUser);

                            // TAREFAS DO PROJETO

                            //var person = new Person();
                            //var tasks = new List<Tasks>();

                            //person.Title = Console.ReadLine();
                            //var task = new Tasks
                            //{
                            //    Id = Int32.Parse(Console.ReadLine()),
                            //    Title = Console.ReadLine(),
                            //    WorkHours = Decimal.Parse(Console.ReadLine()),
                            //    TaskType = ETaskType.CasosDeTeste

                            //};

                            //tasks.Add(task);

                            //BusinessProject[p].Tasks.Add(person, tasks);

                            createTask(p);
                        }
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Não tem!!!");
                        break;
                }



            }

            void criaProjeto(int p)
            {
                BusinessProject[p] = new Project();

                Console.WriteLine("ID do projeto: ");
                BusinessProject[p].Id = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Nome do projeto: ");
                BusinessProject[p].Title = Console.ReadLine();

                Console.WriteLine("Código do projeto: ");
                BusinessProject[p].Code = Console.ReadLine();

                Console.WriteLine("Data de inicio do projeto: ");
                BusinessProject[p].StartDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Data estimada do projeto: ");
                BusinessProject[p].EstimatedEndDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Data de conclusao do projeto: ");
                BusinessProject[p].RealEndDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Responsável pelo projeto: ");
                BusinessProject[p].Responsible.Title = Console.ReadLine();
            }

            void criaUsuario(int p, int qtdUser)
            {

                for (int u = 0; u < qtdUser; u++)    
                {
                    Console.WriteLine("1- ID\n2- Nome\n3- Data Nasc\n4- Email\n");
                    BusinessProject[p].members.Add(new Person()
                    {
                        Id = Int32.Parse(Console.ReadLine()),
                        Title = Console.ReadLine(),
                        BirthDate = DateTime.Parse(Console.ReadLine()),
                        Email = Console.ReadLine()

                    });
                    Console.Clear();
                }
                
            }

            void createTask(int p)
            {
                var person = new Person();
                var tasks = new List<Tasks>();

                Console.WriteLine("Name of the responsible: ");
                string personName = Console.ReadLine();

                Console.WriteLine("ID of the Task: ");
                int id = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Name of the Task");
                string taskName = Console.ReadLine();

                Console.WriteLine("Scheduled Time: ");
                decimal workHour = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Task type: ");
                Console.WriteLine("1- Code Task");
                Console.WriteLine("2- Test Case Task");
                Console.WriteLine("3- Correction Task");

                int type = Int16.Parse(Console.ReadLine());
                ETaskType opcao = (ETaskType)type;

                //switch (type)
                //{
                //    case 1:
                //        opcao = ETaskType.Codificação;
                //        break;
                //    case 2:
                //        opcao = ETaskType.CasosDeTeste;
                //        break;
                //    case 3:
                //        opcao = ETaskType.Defeito;
                //        break;
                //    default:
                //        Console.WriteLine("Invalid option");
                //        break;
                //}

                person.Title = personName;

                var task = new Tasks
                {
                    Id = id,
                    Title = taskName,
                    WorkHours = workHour,
                    TaskType = opcao

                };

                tasks.Add(task);

                BusinessProject[p].Tasks.Add(person, tasks);


            }

            Menu();

        }


           
    }
}
