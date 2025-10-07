using KutyaKozmetika.Models;

namespace KutyaKozmetika.Repos
{
    public class KutyaRepo
    {
        private List<KutyaRecord> _kutyak = new List<KutyaRecord>();
        public void ReadDataFrom(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                Console.WriteLine($"{lines.Length} sor van a fájlban.");
                foreach(string line in lines.Skip(1))
                {
                    KutyaRecord kutya = KutyaRecord.FromLine(line, new char[] { ';' });
                    _kutyak.Add(kutya);
                    Console.WriteLine(kutya);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Üzleti logika
        public int GetNumberOfDogs()
        {
            return _kutyak.Select(k => k.DogName).Distinct().Count();
        }
        public int GetNumberOfDogNames()
        {
            return _kutyak.Select(k => k.DogName).Distinct().Count();
        }
        public List<string> GetCustomerNames()
        {
            return _kutyak.Select(k => k.CustomerName).Distinct().ToList();
        }

        public List<string> Dogs()
        {
            return _kutyak.Select(k => k.DogName).Distinct().ToList();
        }
        public IReadOnlyList<KutyaRecord> ServicesAndPrices()
        {
            return _kutyak.GroupBy(k => k.ServiceName).Select(k => k.First()).ToList();
        }
        public IReadOnlyList<KutyaRecord> CertainDay(int day)
        {
            return _kutyak.Where(k => k.AppointmentDate.Day == day).GroupBy(k => k.CustomerName).Select(k => k.First()).ToList();
        }

    }
}
