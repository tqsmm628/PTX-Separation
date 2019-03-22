﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Separation.Services;
using Separation.ServiceValues;

namespace Separation {
    class Program {
        static void Main(string[] args) {
            Dump("insert", ApplicationService.Insert());
        }

        private static void Dump(string filename, IEnumerable<string> msg) => File.WriteAllText(
            $"Output/{filename}.sql",
            string.Join(Environment.NewLine, msg));
    }
}
