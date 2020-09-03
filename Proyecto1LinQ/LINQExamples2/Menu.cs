using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1LinQ
{
    public class Menu
    {
        MethodsRepository repository = new MethodsRepository();
        public void ShowMenu()
        {
            bool yesConverted = false;
            int opcion;
            do
            {
                 Console.WriteLine($"1.Mostrar paquetes con velocidad superior a 8MB \n \n" +
                 $"<<Clientes y paquetes de internet>> \n 2.Mostrar informacion de paquete de cliente \n " +
                 $"3.Mostrar informacion de cliente con id = 22 y id = 27 \n \n" +
                 $"<<Paquetes de internet y sectores>> \n 4.Mostrar informacion de sector en todos los paquetes \n " +
                 $"5.Mostrar informacion de clientes en todos los sectores \n " +
                 $"6.Mostrar informacion de clientes para el sector de negocios \n \n" +
                 $"<<Filtro por fecha>> \n 7.Mostrar informacion de cliente para sector privado cuya fecha de afiliacion fue en 2006 \n " +
                 $"8.Mostrar informacion de cliente para el sector de negocios en rango definido por el usuario \n \n" +
                 $"<<Bono>> \n 9. Contar numero de letras que se repiten en una palabra \n 10.Salir");               
                yesConverted = Int32.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();
                if ( opcion < 0  || !yesConverted || opcion > 10 ) { 
                    if(yesConverted == false)
                    {
                        Console.WriteLine("Ingreso un letra \n Digite una de las opciones mostradas \n" +
                                          "Oprima cualquier tecla para continuar...");
                    }else if(opcion < 0)
                    {
                        Console.WriteLine("Ingreso un numero negativo \n Digite una de las opciones mostradas \n" +
                                          "Oprima cualquier tecla para continuar...");
                    }else if(opcion > 10)//Para que sea dinamico puede contener el numero de elementos que coontiene el diccionario
                    {
                        Console.WriteLine("Ingreso una opcion que no existe \n Oprima cuaquier tecla para continuar...");
                    }
                    Console.ReadKey();
                    
                continue;

                }
                else
                {
                    repository.ExecuteMethod(opcion);
                    Console.WriteLine("Desea continuar... y/n ?");
                    string yes_no = Console.ReadLine();
                    if(yes_no.Equals("Y") || yes_no.Equals("y"))
                    {
                        yesConverted = false;
                    }
                    else if (yes_no.Equals("N") || yes_no.Equals("n")) {
                        Console.WriteLine("Termino la ejecucion.");
                    }
      
                }
               
            } while (opcion < 0 || !yesConverted || opcion > 10);
        }
    }
}
