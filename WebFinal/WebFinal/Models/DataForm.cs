using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    public class DataForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Duration { get; set; }
        public int City { get; set; }

        public string NameC { get; set; }
        public City NameCity { get; set; }
        public string iconURL { get; set; }
        public string DescriptionforCloud { get; set; }

    }
}