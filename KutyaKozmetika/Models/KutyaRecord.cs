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
            KutyaRecord kutyaRec = new KutyaRecord();

            kutyaRec.CustomerName = l[0];
            kutyaRec.DogName = l[1];
            int dogAge = 0;
            bool success = int.TryParse(l[3], out dogAge);
            if(!success ||  dogAge < 0) 
                throw new ArgumentOutOfRangeException(nameof(dogAge), "A kutya életkorának pozitív számnak kell lennie.");
            kutyaRec.DogAge = dogAge;
            kutyaRec.ServiceName = l[3];
            int servicePriceHuf = 0;
            bool success2 = int.TryParse(l[4], out servicePriceHuf);
            if (!success2 || servicePriceHuf < 0)
                throw new ArgumentOutOfRangeException(nameof(servicePriceHuf), "A szolgáltatás ára nem lehet negatív szám.");
            kutyaRec.ServicePriceHuf = servicePriceHuf;
            kutyaRec.AppointmentDate = Convert.ToDateTime(l[5]);
            int Hour = 0;
            bool success3 = int.TryParse(l[6], out  Hour);
            if (!success || Hour < 0)
                throw new ArgumentOutOfRangeException(nameof(Hour), "Az óra nem lehet negatív szám.");
            kutyaRec.Hour = Hour;
            int Minute = 0;
            bool success4 = int.TryParse(l[7], out Minute);
            if (!success4 || Minute < 0)
                throw new ArgumentOutOfRangeException(nameof(Minute), "A perc nem lehet negatív szám.");
            kutyaRec.Minute = Minute;

            return kutyaRec;
        }

        public override string ToString()
        {
            return $"{CustomerName} - {DogName} - {DogAge} - {ServiceName} - {ServicePriceHuf} - {AppointmentDate.Year}-{AppointmentDate.Month}-{AppointmentDate.Day} - {Hour} - {Minute}";
        }
    }
}
