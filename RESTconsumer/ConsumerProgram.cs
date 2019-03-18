using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTconsumer;

namespace HotelDBREST
{
    public class ConsumerProgram
    {
        static void Main(string[] args)
        {

            Console.WriteLine("( ͡° ͜ʖ ͡°)\n" +
                              "Press any key to begin");
            Console.ReadKey();


            bool ProgramRunning = true;

            while (ProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("***************");
                Console.WriteLine("\tLars Truelsen presents:");
                Console.WriteLine("\t \t REST Consumer 2: The RESTening");
                Console.WriteLine("****************");

                Console.WriteLine("1) Hent alle faciliteter");
                Console.WriteLine("2) Opret en ny facilitet");
                Console.WriteLine("3) Luk programmet");
                int userInput = Int32.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        //hej
                        RESTmethods.HentAlleFaciliteter();
                        break;

                    case 2:
                        RESTmethods.OpretFacilitet();
                        break;

                    default:
                        ProgramRunning = false;
                        break;
                }

            }


            Console.WriteLine("Exiting program");
            Console.ReadKey();
        }


        
    }
}
