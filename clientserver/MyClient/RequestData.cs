using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class RequestData
    {
        public int PageIndex { get; set; }
        public int CountOfRecords { get; set; }
        public string Command { get; set; }
    }
}
