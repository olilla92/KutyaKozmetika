using KutyaKozmetika.Repos;

KutyaRepo repo = new KutyaRepo();
repo.ReadDataFrom("kutyakozmetika.csv");

int numberOfDogs = repo.GetNumberOfDogs();
Console.WriteLine($"{numberOfDogs}");

int numberOfDognames = repo.GetNumberOfDogNames();
Console.WriteLine($"{numberOfDognames}");

