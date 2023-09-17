using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Request
{
    public class SearchProductReq
    {
        public string Keyword { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
