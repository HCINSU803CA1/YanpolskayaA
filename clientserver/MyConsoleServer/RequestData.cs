using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleServer
{
    class RequestData
    {
        public int PageIndex { get; set; }
        public int CountOfRecords { get; set; }
        public string Command { get; set; }
    }
}
