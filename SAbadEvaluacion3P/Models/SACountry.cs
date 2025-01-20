using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAbadEvaluacion3P.Models
{
    public class SACountry
    {
        public Name Name { get; set; }
        public List<string> Capital { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
    }

}
