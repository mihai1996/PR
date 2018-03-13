using Csv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab
{

    //clasa de baza - Raport
    class Raport
    {
        public string startDate;
        public string endDate;
        private Categories categories = new Categories();
        private Orders orders = new Orders();

        // CountdownEnvent se foloseste pentru a face join la threaduri
        private CountdownEvent countEventObject = new CountdownEvent(2);


        private Categories parents = new Categories();

        public Raport()
        {
        }

        //metoda de download a datelor de pe server
        public void Download()
        {
            //introducerea datei pentru comenzi
            EnterDate();

            //get la categorii si comenzi
            GetCategoriesOrders();

            //asteptarea firelor de executie de la GetCategories
            countEventObject.Wait();

            //Gasirea nodurilor parinti
            GetParents();

            countEventObject = new CountdownEvent(1);

            //construirea arborelui de comenzi
            foreach (var p in parents.list)
            {
                countEventObject.AddCount();
                Task.Run(() => Build(p.Value));
            }
            countEventObject.Signal();
            countEventObject.Wait();
            
            // pornirea metodei de cache
            Task.Run(() => Cache());
        }

        // incarcarea Cache
        public void LoadCache()
        {
                using (StreamReader file = File.OpenText(@"E:\cache.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    parents = (Categories)serializer.Deserialize(file, typeof(Categories));
                }
        }

        public void Afisare()
        {

            Console.WriteLine($"\nLista de la  {parents.startDateString} pina la {parents.endDateString}", ConsoleColor.White);

            foreach (var e in parents.list)
            {
                Afisare(e.Value);
            }
        }

        private void Afisare(Category c)
        {
            if (c.childNr == 0)
            {
                Console.WriteLine();
            }

            for (int i = 0; i < c.childNr; ++i)
            {
                Console.Write("\t", ConsoleColor.White);
            }
            Console.Write($"+{c.name}", ConsoleColor.White);
            Console.WriteLine($"  {c.total}", ConsoleColor.White);

            foreach (var subCat in c.children.Values)
            {
                Afisare(subCat);
            }
        }

        // pastrarea datelor sub forma de fisier.json
        private void Cache()
        {
            string data = JsonConvert.SerializeObject(parents);
            string path = @"C:\";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter writetext = new StreamWriter(@"E:\cache.json"))
                {
                    writetext.Write(data);
                }
            
        }

        //construirea recursiva a arborelui
        private void Build(object obj)
        {
            Category p = (Category)obj;
            foreach (var el in categories.list)
            {
                if (!el.Value.marked && el.Value.parent_id == p.id)
                {
                    el.Value.marked = true;
                    if (orders.list.ContainsKey(el.Value.id))
                    {
                        el.Value.total = orders.list[(el.Value.id)].total;
                    }
                    el.Value.childNr = p.childNr + 1;
                    p.children.TryAdd(el.Key, el.Value);
                    Build(el.Value);
                }
            }

            //daca este parinte, atunci construirea a luat sfirsit
            if (p.parent_id == 0)
            {
                countEventObject.Signal();
            }
        }


        //gasirea parintilor
        private void GetParents()
        {
            foreach (var x in categories.list)
            {
                if (x.Value.parent_id == 0)
                {
                    x.Value.marked = true;
                    if (orders.list.ContainsKey(x.Value.id))
                    {
                        x.Value.total = orders.list[(x.Value.id)].total;
                    }
                    parents.list[x.Key] = x.Value;
                }
            }
        }

        private void EnterDate()
        {
            Console.WriteLine("Enter orders date (yyyy-mm-dd) :");
            startDate = Console.ReadLine();
            Console.WriteLine("Enter categories date (yyyy-mm-dd) :");
            endDate = Console.ReadLine();
        }

        
        // Requesturile GET
        private void GetCategoriesOrders()
        {
            Task.Run(() => MakeRequest(@"https://evil-legacy-service.herokuapp.com/api/v101/orders/?" + $"start={startDate}&end={endDate}", "orders"));
            Task.Run(() => MakeRequest(@"https://evil-legacy-service.herokuapp.com/api/v101/categories/", "categories"));
        }

        //Efectuarea requestului
        private void MakeRequest(string url, string type)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 60 * 1000; // one minute
            request.Headers.Add("X-API-Key", "55193451-1409-4729-9cd4-7c65d63b8e76");
            request.Accept = "text/csv";
            HttpStatusCode responseCode;
            string result = "";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    responseCode = response.StatusCode;

                    result = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    response.Close();
                }
            }
            catch (WebException webException)
            {
                throw webException;
            }

            if (responseCode != HttpStatusCode.OK)
                throw new Exception("Invalid respone");

            if (type == "categories")
            {
                foreach (ICsvLine line in CsvReader.ReadFromText(result))
                {
                    categories.AddValidElement(line);
                }
            }
            else if (type == "orders")
            {
                foreach (ICsvLine line in CsvReader.ReadFromText(result))
                {
                    orders.AddValidElement(line);
                }
            }

            countEventObject.Signal();
        }
    }
}
