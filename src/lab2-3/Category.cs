using Csv;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    //Clasa categorie
    class Category
    {
        public int parent_id;
        public string name;
        public int id;

        //verificarea elementului daca a fost adaugat
        public bool marked = false;

        //totatul comezni pe categorie
        public decimal total;

        //numarul copilului in arbore
        public int childNr;

        //subcategoriile categoriei de baza
        public ConcurrentDictionary<int, Category> children = new ConcurrentDictionary<int, Category>();


        public Category(ICsvLine line)
        {
            //parsarea elementului din CSV
            this.name = line["name"];
            this.id = Int32.Parse(line["id"]);

            if (!String.IsNullOrWhiteSpace(line["category_id"]))
                this.parent_id = Int32.Parse(line["category_id"]);
            else
                this.parent_id = 0;
        }

        public Category()
        {

        }
    }
}
