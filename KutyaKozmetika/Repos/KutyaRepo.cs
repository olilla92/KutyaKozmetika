using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using KutyaKozmetika.Models;

namespace KutyaKozmetika.Repos
{
    public class KutyaRepo
    {
        private List<KutyaRecord> _kutyak;
        public KutyaRepo()
        {
            _kutyak = new List<KutyaRecord>();
        }
        public KutyaRecord? Find(string CustomerName, string DogName, int DogAge, string ServiceName, int ServicePriceHuf, DateTime AppointmentDate, int Hour, int Minute) => _kutyak.FirstOrDefault(k => k.CustomerName == CustomerName && k.DogName == DogName && k.DogAge == DogAge && k.ServiceName == ServiceName && k.ServicePriceHuf == ServicePriceHuf && k.AppointmentDate == AppointmentDate && k.Hour == Hour && k.Minute == Minute);
        public int CustomersCount => _kutyak.Select(k => k.CustomerName).Distinct().Count();
        public int DogCount => _kutyak.Select(k => k.DogName).Distinct().Count();
        
        public bool Add(KutyaRecord kutya)
        {
            if(kutya == null)
                throw new ArgumentNullException(nameof(kutya));
            KutyaRecord? FoundItem = Find(kutya.CustomerName, kutya.DogName, kutya.DogAge, kutya.ServiceName, kutya.ServicePriceHuf, kutya.AppointmentDate, kutya.Hour, kutya.Minute);
            if (FoundItem != null)
                return false;
            _kutyak.Add(kutya);
            return true;
        }

        public IReadOnlyList<KutyaRecord> AllCustomers()
        {
            return _kutyak.Select(k => k).ToList();
        }
        public IReadOnlyList<string> Dogs()
        {
            return _kutyak.Select(k => k.DogName).Distinct().ToList();
        }

        //groupBy(k => k.ServiceName)  adatok kiszűrése, hogy mindegyikből csak egy jelenjen meg, Distict() nem működik ez esetben
        public IReadOnlyList<KutyaRecord> ServicesAndPrices()
        {
            return _kutyak.GroupBy(k => k.ServiceName).Select(k => k.First()).ToList();
        }

        public IReadOnlyList<KutyaRecord> CertainDay(int day)
        {
            return _kutyak.Where(k => k.AppointmentDate.Day == day).Select(k => k).ToList();
        }
    }
}
