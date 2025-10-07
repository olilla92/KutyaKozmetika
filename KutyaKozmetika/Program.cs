using KutyaKozmetika.Models;
using KutyaKozmetika.Repos;

KutyaRepo repo = new KutyaRepo();
repo.ReadDataFrom("kutyakozmetika.csv");

int numberOfDogs = repo.GetNumberOfDogs();
Console.WriteLine($"\nA kutyák száma: {numberOfDogs}");

Console.WriteLine("\nAz időpontot foglalók névsora: ");
foreach(string name in repo.GetCustomerNames())
{
    Console.WriteLine($"\t{name}");
}

Console.WriteLine($"\nA kutyák névsora: ");
foreach(string dogs in repo.Dogs())
{
    Console.WriteLine($"\t{dogs}");
}

Console.WriteLine($"\nSzolgáltatások és árak: ");
foreach(KutyaRecord serv in repo.ServicesAndPrices())
{
    Console.WriteLine($"\t{serv.ServiceName} - {serv.ServicePriceHuf} Ft");
}

Console.WriteLine($"\nFoglalás egy megadott napra: ");
foreach(KutyaRecord day in repo.CertainDay(6))
{
     Console.WriteLine($"\t{day.CustomerName} -> {day.Hour}:{day.Minute}");
}
