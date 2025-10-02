using KutyaKozmetika.Models;
using KutyaKozmetika.Repos;
using System;

namespace KutyaKozmetika.FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<KutyaRecord> kutyak = new List<KutyaRecord>();

            KutyaRepo kutyaKozmetikaRepo = new KutyaRepo();

            try
            {
                foreach (var rec in File.ReadAllLines("kutyakozmetika.csv").Skip(1))
                {
                    kutyak.Add(new KutyaRecord(rec));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var record in kutyak)
                kutyaKozmetikaRepo.Add(record);

            try
            {
                foreach (var record in kutyaKozmetikaRepo.AllCustomers())
                {
                    Console.WriteLine($"{record.CustomerName} - {record.DogName} - {record.DogAge} - {record.ServiceName} - {record.ServicePriceHuf} - {record.AppointmentDate.Year}-{record.AppointmentDate.Month}-{record.AppointmentDate.Day} - {record.Hour} - {record.Minute}");
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine($"Az ügyfelek száma: {kutyaKozmetikaRepo.CustomersCount}");

            Console.WriteLine();
            Console.WriteLine($"A kutyák száma: {kutyaKozmetikaRepo.DogCount}");
            Console.WriteLine("A kutyák listája: ");
            foreach(var record in kutyaKozmetikaRepo.Dogs())
                Console.WriteLine($"\t{record}");

            Console.WriteLine();
            Console.WriteLine("A szolgáltatások listája: ");
            foreach (var record in kutyaKozmetikaRepo.ServicesAndPrices())
                Console.WriteLine($"\t{record.ServiceName} -> {record.ServicePriceHuf}");

            Console.WriteLine($"\nFoglalás 2.-ra:");
            foreach(var record in kutyaKozmetikaRepo.CertainDay(2))
                Console.WriteLine($"{record.CustomerName} időpont foglalása: {record.Hour}:{record.Minute}");
        }
    }
}



