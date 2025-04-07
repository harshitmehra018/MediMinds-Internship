using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppoinmentScheduler
{
    internal class Program
    {
        static void AddAppionment()
        {
            Console.WriteLine("Client name");
            string ClientName = Console.ReadLine();
            Console.WriteLine("description: ");
            string description= Console.ReadLine();
            Console.WriteLine("Date in (yyyy-mm-dd)format");
            string Date = Console.ReadLine();
            Console.WriteLine("Time in (HH:mm) format");
            string Time=Console.ReadLine();
            Console.WriteLine("Duration : select the option below");
            Console.WriteLine("1- 30 min");
            Console.WriteLine("2- 60 min");
            Console.WriteLine("3- 90 min");
            string duration= Console.ReadLine();

            switch (duration)
            {
                case "1":
                    Console.WriteLine("your appoinment is scheduled for 30 min.");
                    break;
                case "2":
                    Console.WriteLine("your appoinment is scheduled for 60 min.");
                    break;
                case "3":
                    Console.WriteLine("your appoinment is scheduled for 90 min.");
                    break;
                default: 
                    Console.WriteLine("invalid time slot");
                    break;
            }
            Console.WriteLine("Successfully Scheduled!");
            Console.WriteLine($"name: {ClientName}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($" Date: {Date}");
            Console.WriteLine($" Time: {Time}");
            Console.WriteLine($" Duration: {duration}");
            Console.ReadLine();
        }
        static void ViewAppoinment()
        {
            Console.WriteLine("scheduled Appoinments: ");

        }
        
        
        
        
        
        
        
        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Appoinment Scheduler");
                Console.WriteLine("1- Schedule Appoinment");
                Console.WriteLine("2- View Appoinment");
                Console.WriteLine("3- Exit");
                Console.WriteLine("Choose an option");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAppionment();
                        break;
                    case "2":
                        ViewAppoinment();
                        break;
                    case "3":
                        Console.WriteLine("you exit the Appoinment Scheduler app.");
                        Console.WriteLine("Thankyou");
                        return;
                    default:
                        Console.WriteLine("invalid chhoice");
                        break;

                }
            }
            
        }
    }
}
