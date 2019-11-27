using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roastie
{
    class SPN
    {
        public string fullSPN { get; }
        public string host { get; }
        public string service { get; }

        public SPN(string input)
        {
            fullSPN = input;
            host = input.Split('/')[1];
            service = input.Split('/')[0];
        }
    }
}
