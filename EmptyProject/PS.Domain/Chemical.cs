using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Chemical:Product
    {

        public String LabName { get; set; }

        public Adresse adresse { get; set; }
        public override void GetMyType()
        {
            Console.WriteLine("CHEMICAL");
        }
    }
}
