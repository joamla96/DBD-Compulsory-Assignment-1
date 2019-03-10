using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Depatment : Entity
    {
        public string Name { get; set; }
        public int MgrSSN { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " MgrSSN: " + MgrSSN;
        }
    }
}
