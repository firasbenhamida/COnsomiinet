using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consomi.Domain.Entities
{
    public class Livraison
    {
        public int id { get; set; }
        public int idCommande { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public int idLivreur { get; set; }
        public int idClient { get; set; }
    }
}
