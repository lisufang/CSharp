using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticProgram
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Print print = new Print("国考_原题", "国考_标准答案1");
            Print print1 = new Print("国考_原题", "国考_标准答案2");
            Print print2 = new Print("国考_原题", "国考_标准答案3");
            Print print3 = new Print("国考_原题", "国考_原题");
            Console.ReadKey();
        }
    }
}
