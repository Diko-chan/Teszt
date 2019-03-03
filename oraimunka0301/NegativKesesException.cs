using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oraimunka0301
{
    class NegativKesesException : Exception
    {

        public NegativKesesException(int keses) : base("Hibás késés: " + keses)
        {
        }

    }
}
