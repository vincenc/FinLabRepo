using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FinLabLibs
{
    public class Portfolio
    {
        private HashSet<string> stockCache { get; set; }
        public List<string> Stocks { get; private set; }
        public string Path { get; private set; }

        public Portfolio(string path)
        {
            if (path.IsNullOrEmpty() == false && File.Exists(path))
            {
                Path = path;
                string[] lines = File.ReadAllLines(path);
                stockCache = lines.Select(n => n.Trim().Trim('"')).ToHashSet();
                Stocks = stockCache.ToList();
            }
        }

        public void Add(string stock)
        {
            if (stockCache.Contains(stock))
                return;

            stockCache.Add(stock);
            Stocks.Add(stock);
        }

        public void Save()
        {
            File.WriteAllLines(Path, Stocks.OrderBy(n => n));
        }


    }
}
