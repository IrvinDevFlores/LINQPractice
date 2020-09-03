using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
   
    public class Menu
    {
        delegate void controlaMetodos();
        static MethodsRepository repository = new MethodsRepository();
        private string str_input;


        Dictionary<int, string> opciones = new Dictionary<int, string>();
        string yes_no = "";
        public Menu()
        {
            AddedOptions();
        }

        public void AddedOptions()
        {
            opciones.Add(1, $"Estudiante con puntuacion mayor ");
            opciones.Add(2, $"Estudiante puntuacion mayor a 90 e inferior a 80 ");
            opciones.Add(3, $"Apellidos de forma ascendente  ");
            opciones.Add(4, $"Apellidos de forma descendente ");
            opciones.Add(5, $"Estudiantes agrupados segun su key ");
            opciones.Add(6, $"Sumatoria de todos los examenes ");
            opciones.Add(7, $"Promedio de toda la clase ");
            opciones.Add(8, $"Consulta con apellido ");
            opciones.Add(9, $"Estudiantes con promedio mayor a 321.5 ");
            opciones.Add(10, $"Crear nueva lista de calificaciones ");
            opciones.Add(11, $"Devolver nuevo listado de alumnos con informacion de curso ");
            opciones.Add(12, $"Devolver una lista de curso segun su idCurso ");
            opciones.Add(13, "Salir");

        }

        public void AddOption(int index, string history)
        {
            opciones.Add(index, history);
        }
         public   void EjecutarMenu()
         {
 
            bool seguir = false;
            do
            {
                bool yesConverted = true;
                do
                {
                    int input;
                    foreach(var opcion in opciones)
                    {
                        Console.WriteLine($"{opcion.Key}. {opcion.Value}");
                    }

                    str_input = Console.ReadLine();
                    yesConverted = Int32.TryParse(str_input, out input);
                    Console.Clear();
                    if (input > 0 && input < 13)
                    {
                        InvokeMethod(input);
                    }else if(input == 13)
                    {
                        Environment.Exit(0);
                    }
                } while (yesConverted);
                
                Console.WriteLine("Desea continuar?: y/n ---> ");
                yes_no = Console.ReadLine();
                seguir = (string.Equals(yes_no, "Y", StringComparison.OrdinalIgnoreCase)) ? true:false;
                Console.Clear();
            } while (seguir && !yes_no.Equals("n"));
        }
        
         public  void InvokeMethod(int index)
        {
              repository.addedRepositoryMethods[index].Invoke();
        }

    }
}
