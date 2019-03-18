using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using HotelDBREST;
using HotelDBREST.DBUtil;
using ModelLib.model;


namespace RESTconsumer
{
    static class RESTmethods
    {
        public static void HentAlleFaciliteter()
        {
            ManageFacility MF = new ManageFacility();
            List<Facility> liste = new List<Facility>();

            IEnumerable<Facility> IEliste = new List<Facility>();

            liste = IEliste.ToList();
            

            Console.WriteLine("Alle faciliteter i databasen:");
            foreach (var elem in liste)
            {
                Console.WriteLine(elem.ToString());
            }

            Console.WriteLine("Slutningen af listen");
            Console.ReadKey();




        }


        public static void OpretFacilitet()
        {
            Console.Clear();

            ManageFacility MF = new ManageFacility();
            IEnumerable<IEnumerable<Facility>> liste = new List<IEnumerable<Facility>>();

            liste = new[] { MF.Get() };

            Facility elem = new Facility();

            elem.FacilityId = liste.Count() + 1;
            Console.WriteLine("Skriv navnet på din facilitet:");
            elem.FacilityName = Console.ReadLine();

            Console.WriteLine("Beskrive din facilitet med en linje:");
            elem.FacilityDesc = Console.ReadLine();

            Console.WriteLine("Tilføjer din facilitet");

            MF.Post(elem);
            
            Console.ReadKey();
        }
    }
}
