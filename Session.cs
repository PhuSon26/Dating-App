using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIN
{
    internal class Session
    {
        public static string IdToken {  get; set; }
        public static string LocalId {  get; set; }

        public static bool IsBusy { get; set; } = false;
    }
}
