using Csv;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    //clasa Categorii
    class Categories
    {
        // dictionarul ce contine categoriile parinti
        public ConcurrentDictionary<int, Category> list = new ConcurrentDictionary<int, Category>();

        //data de start si sfirsit a comenzilor
        public string startDateString;
        public string endDateString;


        //adaugarea elementelor
        public void AddValidElement(ICsvLine line)
        {
            //parsarea categoriilor din CSV
            try
            {
                if (String.IsNullOrWhiteSpace(line["name"])
                || String.IsNullOrWhiteSpace(line["id"]))
                {
                    return;
                }

                Category cat = new Category(line);
                list[Int32.Parse(line["id"])] = cat;
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
}
