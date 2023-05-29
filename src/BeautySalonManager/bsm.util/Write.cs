using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.util
{
    public class Write
    {
        public static void LineToCenter(string msg)
        {
            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
            Console.WriteLine(msg);
        }

        public static void ToCenter(string msg)
        {
            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
            Console.Write(msg);
        }
    }
}
