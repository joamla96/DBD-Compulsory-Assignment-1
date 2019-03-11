using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Depatment : Entity
    {
        public string Name { get; set; }
        public int MgrSSN { get; set; }
        public string MgrStartDate { get; set; }
        public int NumOfEmployee { get; set; }

        public Depatment()
        {
            Name = "Error";
            MgrSSN = -1;
            MgrStartDate = "Error";
            NumOfEmployee = -1;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " MgrSSN: " + MgrSSN +
                    " MgrStartDate: " + MgrStartDate + " numOfEmpoyee: " + NumOfEmployee;
        }
    }
}