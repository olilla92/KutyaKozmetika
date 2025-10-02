using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutyaKozmetika.Repos;

namespace KutyaKozmetika.Models
{
    public class KutyaRecord
    {
        public string CustomerName { get; set; }
        public string DogName { get; set; }
        public int DogAge { get; set; }
        public string ServiceName { get; set; }
        public int ServicePriceHuf { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public KutyaRecord(string sor)
        {
            string[] s = sor.Split(";");
            CustomerName = s[0];
            DogName = s[1];
            DogAge = int.Parse(s[2]);
            ServiceName = s[3];
            ServicePriceHuf = int.Parse(s[4]);
            AppointmentDate = Convert.ToDateTime(s[5]);
            Hour = int.Parse(s[6]);
            Minute = int.Parse(s[7]);
        }

        public override string ToString()
        {
            return $"{CustomerName} - {DogName} - {DogAge} - {ServiceName} - {ServicePriceHuf} - {AppointmentDate.Year}-{AppointmentDate.Month}-{AppointmentDate.Day} - {Hour} - {Minute}";
        }
    }
}
