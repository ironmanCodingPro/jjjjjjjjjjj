using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{

    [Owned]      
    public class Adresse
    {
        public String City { get; set; }

        public String StreetAddress { get; set; }
    }
}
