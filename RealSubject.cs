﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Pattern
{
    public class RealSubject : ISubject
    {
        public string Request(string request)
        {
            Console.WriteLine($"RealSubject: Processing request: {request}");
            return $"Processed: {request}";
        }
    }
}
