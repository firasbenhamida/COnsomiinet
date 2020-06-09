using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Consomi.Domain.Entities
{
    public class Livreur
    {
        public int id { get; set; }
        public string Mail { get; set; }
        public string adresse { get; set; }
        public int etat { get; set; }
        public int idU { get; set; }

        public int activite { get; set; }

    }
}
