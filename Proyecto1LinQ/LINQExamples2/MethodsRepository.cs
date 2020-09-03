using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Proyecto1LinQ.DataContext;

namespace Proyecto1LinQ
{
    public class MethodsRepository
    {
        public delegate void myDelegateControler();

        public Dictionary<int, myDelegateControler> addedMethods = new Dictionary<int, myDelegateControler>();

        public DBDataContext dataContext = new DBDataContext();

        public MethodsRepository()
        {
            addedMethods.Add(1, ShowInternetPackageAboveEightMB);
            addedMethods.Add(2, ShowAllClientsPackage);
            addedMethods.Add(3, ShowAllClientsWithIdAbove22And27);
            addedMethods.Add(4, ShowAllPackageAndSectors);
            addedMethods.Add(5, ShowAllPackagesAndSectorsOfCustomers);
            addedMethods.Add(6, ShowAllPackagesOfCustomersBySector);
            addedMethods.Add(7, ShowJoinedCustomers);
        }

        public void ExecuteMethod(int index)
        {
            if (index <= addedMethods.Count)
            {
                addedMethods[index].Invoke();
            }
            else if (index == 8)
            {

                new MethodsRepository().ShowJoinedCustomerByDateInCustomRange();
            }
            else if (index == 9)
            {
                new MethodsRepository().CountLettersInString();
            }
            else 
            {
                Environment.Exit(0);
            }

        }

        public void ShowInternetPackageAboveEightMB()
        {

            var internetPackagesQuery =
                from package in dataContext.GetPackage()
                where Convert.ToDouble(string.Join("", package.speed.ToCharArray().Where(Char.IsDigit))) > 8
                && !(package.speed.Contains("Kbps"))
                select new
                {
                    speed = Convert.ToDouble(string.Join("", package.speed.ToCharArray().Where(Char.IsDigit))),
                    package_id = package.pack_id,
                };

            foreach (var package in internetPackagesQuery)
            {
                Console.WriteLine($"Speed: {package.speed} ,  Package Id: {package.package_id}");
                

            }

        }

        public void ShowAllClientsPackage()
        {
            var listOfCustomers =
                from customer in dataContext.GetCostumers()
                join package in dataContext.GetPackage() on new { customer.pack_id } equals new { package.pack_id }
                select new
                {
                    name = customer.First_Name,
                    last_name = customer.Last_Name,
                    package_id = customer.pack_id,
                    internet_speed = package.speed
                };

            foreach (var customer in listOfCustomers)
            {
                Console.WriteLine($"Name: {customer.name} \n Last Name: {customer.last_name} \n Package Id: {customer.package_id} \n Internet Speed: {customer.internet_speed} \n ---------------------------");
            }
        }

        public void ShowAllClientsWithIdAbove22And27()
        {
            var customerQuery =
                from customer in dataContext.GetCostumers()
                join package in dataContext.GetPackage() on customer.pack_id equals package.pack_id
                where package.pack_id == 22 || package.pack_id == 27//Aqui podemos remplazar select new { custormer.pack_id = 22} haciendo un join
                orderby customer.pack_id ascending
                select new
                {
                    name = customer.First_Name,
                    last_name = customer.Last_Name,
                    package_id = package.pack_id,
                    internet_speed = package.speed
                };
            foreach (var customer in customerQuery)
            {
                Console.WriteLine($"Name: {customer.name} \n Last Name: {customer.last_name} \n " +
                                  $"Package Id: {customer.package_id} \n Internet Speed: {customer.internet_speed} " +
                                  $"\n ---------------------------");
            }
        }
        
        public void ShowAllPackageAndSectors()
        {
            var packageQuery =
                from package in dataContext.GetPackage()
                join sector in dataContext.GetSectors() on package.sector_id equals sector.sector_id
                select new
                {
                    pack_id = package.pack_id,
                    internet_speed = package.speed,
                    monthly_payment = package.monthly_payment,
                    sector_name = sector.sector_name
                };

            foreach (var package in packageQuery)
            {
                Console.WriteLine($" Id: {package.pack_id} \n Speed: {package.internet_speed} \n You pay this monthly: {package.monthly_payment} \n Sector Name: {package.sector_name} \n ---------------------------");
            }

        }

        public void ShowAllPackagesAndSectorsOfCustomers()
        {
            var packageQuery =
                from sector in dataContext.GetSectors()
                join package in dataContext.GetPackage() on sector.sector_id equals package.sector_id
                from customer in dataContext.GetCostumers()//Falta dificar esta consulta
                select new
                {
                    customer_name = customer.First_Name,
                    package_id = package.pack_id,
                    speed = package.speed,
                    monthly_payment = package.monthly_payment,
                    sector_name = sector.sector_name
                };

            foreach (var package in packageQuery)
            {
                Console.WriteLine($" Customer Name: {package.customer_name} \n Package Id: {package.package_id} \n" +
                      $"Speed: {package.speed} \n Monthly payment:{package.monthly_payment} \n Sector Name: {package.sector_name} \n ---------------------------");
            }
        }

        public void ShowAllPackagesOfCustomersBySector()
        {
            var packageQuery =
                from package in dataContext.GetPackage()
                from customer in dataContext.GetCostumers()
                from sector in dataContext.GetSectors()
                where sector.sector_id == 2
                select new
                {
                    customer_name = customer.First_Name,
                    package_id = package.pack_id,
                    speed = package.speed,
                    monthly_payment = package.monthly_payment,
                    sector_name = sector.sector_name
                };

            foreach (var package in packageQuery)
            {
                Console.WriteLine($" Customer Name: {package.customer_name} \n Package Id: {package.package_id} \n" +
                      $"Speed: {package.speed} \n Monthly payment:{package.monthly_payment} \n Sector Name: {package.sector_name} \n ---------------------------");
            }
        }

        public void ShowJoinedCustomers()
        {
            var packageQuery =
                from package in dataContext.GetPackage()
                from customer in dataContext.GetCostumers()
                from sector in dataContext.GetSectors()
                where customer.Join_Date.ToString().Contains("2006") && sector.sector_id == 1
                select new
                {
                    customer_name = customer.First_Name,
                    customer_lastname = customer.Last_Name,
                    package_id = package.pack_id,
                    speed = package.speed,
                    monthly_payment = package.monthly_payment,
                    sector_name = sector.sector_name,
                    join_date = customer.Join_Date.ToString()
                };

            foreach (var package in packageQuery)
            {
                Console.WriteLine($" Last Name {package.customer_lastname} \n Name: {package.customer_name} \n" +
                      $"Join Date: {package.join_date} \n Package Id:{package.package_id} \n Speed: {package.speed} " +
                      $"Sector Name: {package.sector_name}\n ---------------------------");
            }
        }

        public void ShowJoinedCustomerByDateInCustomRange()
        {
            Console.WriteLine("Input the start range of date to show up: ");
            int start_year = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Input the end range of date to show up: ");
            int end_year = Convert.ToInt32(Console.ReadLine());

            var packageQuery =
                from package in dataContext.GetPackage()
                from customer in dataContext.GetCostumers()
                from sector in dataContext.GetSectors()
                where (customer.Join_Date.Year >= start_year && customer.Join_Date.Year <= end_year) ? true : false
                      && sector.sector_id == 2
                select new
                {
                    customer_name = customer.First_Name,
                    customer_lastname = customer.Last_Name,
                    package_id = package.pack_id,
                    speed = package.speed,
                    sector_name = sector.sector_name,
                    year_counter = (customer.Join_Date.Year >= start_year && customer.Join_Date.Year <= end_year) ? true : false,
                    
                    join_date = customer.Join_Date
                };

            int elementCounter = 0;
            var cpunt = 3;
            foreach (var package in packageQuery)
            {
               if(package.year_counter)
                {
                    Console.WriteLine($"{package.join_date.Year}");
                }
                else
                {
                    Console.WriteLine("NOthing");
                }
                    
                Console.WriteLine($" Last Name {package.customer_lastname} \n Name: {package.customer_name} \n" +
                      $"Join Date: {package.join_date} \n Package Id:{package.package_id} \n Speed: {package.speed} " +
                      $"Sector Name: {package.sector_name}");
                //Console.WriteLine($"\n --------------------------- Año encontrado.>>> {package.join_date.Year} , Elementos {packageQuery.Count() - (elementCounter++)}");
            }
            cpunt = packageQuery.Count();
        }

        public void CountLettersInString()
        {
            Console.WriteLine("Input a word: >");
            string word = Console.ReadLine();
            var RepeatedWords = word.ToList().GroupBy(w => w);
            foreach (var wordrepeated in RepeatedWords)
            {
                Console.WriteLine($"{wordrepeated.Key} - Repeticiones {wordrepeated.Count()}");
            }
        }
    }
}
