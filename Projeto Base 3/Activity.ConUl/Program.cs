using System;
using Activity.ObjectModel;
using System.Collections.Generic;
using System.Linq;

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
                int qtdTask;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("How many Projects: ");
                        qtdProj = Int16.Parse(Console.ReadLine());
                        
                        for(int p = 0; p < qtdProj; p++)
                        {
                            CreateProject(p);

                            Console.Clear();

                            //USUARIOS DO PROJETO

                            Console.WriteLine("How many Users: ");
                            qtdUser = Int16.Parse(Console.ReadLine());

                            CreateUser(p, qtdUser);

                            Console.Clear();

                            // TAREFAS DO PROJETO

                            Console.WriteLine("How many Tasks: ");
                            qtdTask = Int16.Parse(Console.ReadLine());

                            CreateTask(p, qtdTask);

                            Console.Clear();
                        }
                        Menu();
                        break;

                    case 2:
                        ListProject();
                       
                        Menu();
                        break;

                    case 3:
                        Console.Clear();
                        AlteraProj();

                        Menu();
                        break;

                    case 4:
                        Console.Clear();
                        int id;
                        Console.WriteLine("Project ID");
                        id = int.Parse(Console.ReadLine());

                        DeleteProject(id);

                        Menu();
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Não tem!!!");
                        break;
                }



            }

            void CreateProject(int p)
            {
                BusinessProject[p] = new Project();

                Console.WriteLine("ID do projeto: ");
                BusinessProject[p].Id = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Nome do projeto: ");
                BusinessProject[p].Title = Console.ReadLine();

                Console.WriteLine("Código do projeto: ");
                BusinessProject[p].Code = Console.ReadLine();

                //Console.WriteLine("Data de inicio do projeto: ");
                //BusinessProject[p].StartDate = DateTime.Parse(Console.ReadLine());

                //Console.WriteLine("Data estimada do projeto: ");
                //BusinessProject[p].EstimatedEndDate = DateTime.Parse(Console.ReadLine());

                //Console.WriteLine("Data de conclusao do projeto: ");
                //BusinessProject[p].RealEndDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Responsável pelo projeto: ");
                BusinessProject[p].Responsible.Title = Console.ReadLine();

                BusinessProject[p].Removed = 0;
            }

            void CreateUser(int p, int qtdUser)
            {

                for (int u = 0; u < qtdUser; u++)    
                {
                    Console.WriteLine("User ID: ");
                    int id = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("User Name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("User Birth Date: ");
                    DateTime birth = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("User Email: ");
                    string email = Console.ReadLine();

                    BusinessProject[p].members.Add(new Person()
                    {
                        Id = id,
                        Title = name,
                        BirthDate = birth,
                        Email = email

                    });
                    Console.Clear();
                }
                
            }

            void CreateTask(int p, int qtdTask)
            {
                for(int t = 0; t < qtdTask; t++)
                {
                    var person = new Person();
                    var tasks = new List<Tasks>();

                    Console.WriteLine("Name of the responsible: ");
                    string personName = Console.ReadLine();

                    var resp = "yes";

                    while(resp == "yes")
                    {
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

                        Console.Clear();

                        var task = new Tasks
                        {
                            Id = id,
                            Title = taskName,
                            WorkHours = workHour,
                            TaskType = opcao

                        };

                        tasks.Add(task);

                        person.Title = personName;

                        Console.WriteLine("Do you want to create more tasks, mr: " + personName + " (yes / no)");
                        resp = Console.ReadLine();
                        resp = resp.ToLower();
                    }
                   
                        BusinessProject[p].Tasks.Add(person, tasks);
                }
                


            }

            bool ListProject()
            {
                int countRemoved = 0;
                int p;

                for (p = 0; p < BusinessProject.Length && BusinessProject[p] != null; p++)
                {
                    if(BusinessProject[p].Removed == 0)
                    {
                        Console.WriteLine("\n----------Project " + (p + 1) + " ----------");
                        Console.WriteLine("\nId of the Project................: " + BusinessProject[p].Id);
                        Console.WriteLine("Name of the Project................: " + BusinessProject[p].Title);
                        foreach (var user in BusinessProject[p].members)
                        {
                            Console.WriteLine("Id of the User of the Project......: " + user.Id);
                            Console.WriteLine("Name of the User of the Project....: " + user.Title);

                        }
                        foreach (KeyValuePair<Person, List<Tasks>> pair in BusinessProject[p].Tasks)
                        {
                            Console.WriteLine("\nTask Responsible...................: " + pair.Key.Title);
                            foreach (var task in pair.Value)
                            {
                                Console.WriteLine("Task Name..........................: " + task.Title);
                            }
                        }

                    }

                    else if(BusinessProject[p].Removed == 1)
                    {
                        countRemoved++;
                        
                    }
                   
                }
                    if(countRemoved == p)
                    {
                        Console.WriteLine("\nThere isn't projects registered\n");
                        return false;
                    }

                return true;

            }

            bool DeleteProject(int id)
            {
                for (int p = 0; p < BusinessProject.Length && BusinessProject[p] != null; p++)
                {
                    if (id == BusinessProject[p].Id)
                    {

                        BusinessProject[p].Removed = 1;
                        Console.WriteLine("Projeto Removido com sucesso!");
                        return true;
                    }
                  
                }

                Console.WriteLine("\nProjeto nao encontrado!\n");
                return false;
                
            }

            bool AlteraProj()
            {
                int id;

                Console.WriteLine("Id do projeto que deseja alterar: ");
                id = Int32.Parse(Console.ReadLine());

                for(int p = 0; p < BusinessProject.Length && BusinessProject[p] != null; p++)
                {
                    if(BusinessProject[p].Id == id)
                    {
                        Console.WriteLine("Campos para alterar: \n1- Nome\n2- Código");
                        int op = int.Parse(Console.ReadLine());

                        if(op == 1)
                        {
                            Console.WriteLine("Digite o novo nome: ");
                            BusinessProject[p].Title = Console.ReadLine();

                            Console.WriteLine("Nome do projeto alterado com sucesso! ");

                        }

                        else if(op == 2)
                        {
                            Console.WriteLine("Digite o novo codigo: ");
                            BusinessProject[p].Code = Console.ReadLine();

                            Console.WriteLine("Código do projeto alterado com sucesso! ");
                        }

                        else
                        {
                            Console.WriteLine("Opcao nao encontrada");
                            return false;
                        }

                        return true;
                    }
                }
                Console.WriteLine("Projeto com este Id não encontrado");
                return false;
            }

            Menu();

        }


           
    }
}
