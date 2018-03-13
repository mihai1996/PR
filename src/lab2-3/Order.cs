using Csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    //clasa pentru comanda
    class Order
    {
        public int parent_id;
        public string id;
        public decimal total;
        public DateTime created;


        //parsarea elementului din CSV
        public Order(ICsvLine line)
        {
            this.id = line["id"];
            this.total = Convert.ToDecimal(line["total"], System.Globalization.CultureInfo.InvariantCulture);
            this.parent_id = Int32.Parse(line["category_id"]);
            this.created = DateTime.Parse(line["created"]);
        }
    }
}
