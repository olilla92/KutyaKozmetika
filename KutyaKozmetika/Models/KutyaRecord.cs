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
        public string CustomerName { get; set; } = string.Empty;
        public string DogName { get; set; } = string.Empty;
        public int DogAge { get; set; } = 0;
        public string ServiceName { get; set; } = string.Empty;
        public int ServicePriceHuf { get; set; } = 0;
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public int Hour { get; set; } = 0;
        public int Minute { get; set; } = 0;

        public static KutyaRecord FromLine(string line, char[]? separator)
        {
            string[] l = line.Split(separator);
            KutyaRecord kutyaRecord = new KutyaRecord();

            kutyaRecord.CustomerName = l[0];
            kutyaRecord.DogName = l[1];
            int dogAge = 0;
            bool success = int.TryParse(l[2], out dogAge);
            if(!success ||  dogAge < 0) 
                throw new ArgumentOutOfRangeException(nameof(dogAge), "A kutya életkorának pozitív számnak kell lennie.");
            kutyaRecord.DogAge = dogAge;
            kutyaRecord.ServiceName = l[3];
            int servicePriceHuf = 0;
            bool success2 = int.TryParse(l[4], out servicePriceHuf);
            if (!success2 || servicePriceHuf < 0)
                throw new ArgumentOutOfRangeException(nameof(servicePriceHuf), "A szolgáltatás ára nem lehet negatív szám.");
            kutyaRecord.ServicePriceHuf = servicePriceHuf;
            kutyaRecord.AppointmentDate = Convert.ToDateTime(l[5]);
            int Hour = 0;
            bool success3 = int.TryParse(l[6], out  Hour);
            if (!success3 || Hour < 0)
                throw new ArgumentOutOfRangeException(nameof(Hour), "Az óra nem lehet negatív szám.");
            kutyaRecord.Hour = Hour;
            int Minute = 0;
            bool success4 = int.TryParse(l[7], out Minute);
            if (!success4 || Minute < 0)
                throw new ArgumentOutOfRangeException(nameof(Minute), "A perc nem lehet negatív szám.");
            kutyaRecord.Minute = Minute;

            return kutyaRecord;
        }

        public override string ToString()
        {
            return $"\t{CustomerName} - {DogName} - {DogAge} - {ServiceName} - {ServicePriceHuf} Ft - {AppointmentDate.Year}-{AppointmentDate.Month}-{AppointmentDate.Day} - {Hour} - {Minute}";
        }
    }
}
