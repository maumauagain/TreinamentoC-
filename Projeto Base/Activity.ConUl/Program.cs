using System;
using Activity.ObjectModel;
namespace Activity.ConUl
{
    class Program
    {
        
        static void Main(string[] args)
        {
           Project BusinessProject = new Project();
            BusinessProject.Id = 1;
            BusinessProject.Removed = false;
            BusinessProject.Title = "Ola mundo";
            BusinessProject.Comments = "oi";
            BusinessProject.Code = "a56";
            BusinessProject.StartDate = new DateTime(2018, 1, 21);
            BusinessProject.EstimatedEndDate = new DateTime(2018, 1, 22);
            BusinessProject.RealEndDate = new DateTime(2018, 1, 22);
            BusinessProject.Responsible.Id = 10;
            BusinessProject.Responsible.Removed = false;
            BusinessProject.Responsible.Title = "Carlin ninja";
            BusinessProject.Responsible.Comments = "carlin ninja";
            BusinessProject.Responsible.BirthDate = new DateTime(1998, 04, 24);
            BusinessProject.Responsible.Email = "carlin@ninja.com";

            //Console.WriteLine("Titulo" + BusinessProject.Title);
            //Console.ReadKey();
            void PrintProject()
            {
                Console.WriteLine("ID: " + BusinessProject.Id + 
                    "\nTitulo: " + BusinessProject.Title + "\nComentarios: " + BusinessProject.Comments +
                    "\nCódigo: " + BusinessProject.Code + "\nData de Inicio: " + BusinessProject.StartDate +
                    "\nData Estimada: " + BusinessProject.EstimatedEndDate + "\nData Termino: " + BusinessProject.RealEndDate +
                    "\nResponsavel: " + BusinessProject.Responsible.Title + "\nFinished: " + FinishProject() + 
                    "\nRemovido: " + RemoveProject());

                Console.ReadKey();
            }

            bool FinishProject()
            {

                return BusinessProject.MarkFinished();
            }

            bool RemoveProject()
            {
                return BusinessProject.SetRemoved();
            }

            

            PrintProject();
            
        }
    }
}
