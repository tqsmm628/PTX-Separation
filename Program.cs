using System;
using System.Collections.Generic;
using System.IO;
using Separation.ServiceValues;

namespace Separation
{
    class Program {
        static void Main(string[] args) {
            Dump("insert", HistoricalService.Insert());
        }

        private static void Dump(string filename, IEnumerable<string> msg) => 
            File.WriteAllText($"Output/{filename}.sql", string.Join(Environment.NewLine, msg));
    }
}
