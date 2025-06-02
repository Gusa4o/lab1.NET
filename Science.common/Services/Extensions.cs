using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Science.Common
{
    public static class Extensions
    {
        public static double CalculateTotalPrice(this List<Enrollment> enrollment)
        {
            return enrollment.Sum(t => t.Price);
        }
    }
}