using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    public class Patient
    {
        public int idNumber { get; set; }
        public string name { get; set; }
        public double balanceOwed { get; set; }

        public Patient()
        {

        }
        public Patient(int id, string n, float balance)
        {
            idNumber = id;
            name = n;
            balanceOwed = balance;
        }

    }
}
