using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticProgram
{
    class Print
    {
       /// <summary>
       /// 通过获取参数获取文档名字，每两份文档内容进行比对
       /// </summary>
       /// <param name="title1">文件一名称</param>
       /// <param name="title2">文件二名称</param>
        int count = 0;
        public Print(string title1, string title2)
        {
            string path1 = @"E:\Study\studywork\test3\documents\" + title1 + ".docx";
            string path2 = @"E:\Study\studywork\test3\documents\" + title2 + ".docx";

            //读取文档内容
            ReadWord readWord1 = new ReadWord(path1);
            char[] charList1 = readWord1.strList.ToCharArray();
            ReadWord readWord2 = new ReadWord(path2);
            char[] charList2 = readWord2.strList.ToCharArray();

            //比对文档内容
            ReplaceWord replaceword1 = new ReplaceWord(charList1, charList2);
            string resStr1 = replaceword1.resStr1.Trim();
            string resStr2 = replaceword1.resStr2.Trim();

            if ((resStr1 == "" && resStr2 != "") || (resStr1 != "" && resStr2 != ""))
            {
                StringMatch stringMatch = new StringMatch(readWord2.strList, resStr2);
                count = stringMatch.comparTimes;
                Console.WriteLine("输入1：" + title1 + ".docx，输入2：" + title2 + ".docx，输出为：");
                Console.WriteLine();
                Console.WriteLine("替换题：请将文中所有的文字“" + resStr1 + "”替换为“" + resStr2 + "”。总分：" + count + "分");
                Console.WriteLine();
                Console.WriteLine("===============================================================");
                Console.WriteLine();
                return;
            }
            if (resStr1 != "" && resStr2 == "")
            {
                StringMatch stringMatch1 = new StringMatch(readWord1.strList, resStr1);
                count = stringMatch1.comparTimes;
                Console.WriteLine("输入1：" + title1 + ".docx，输入2：" + title2 + ".docx，输出为：");
                Console.WriteLine();
                Console.WriteLine("替换题：请删除文中所有的文字“" + resStr1 + "”。总分：" + count + "分");
                Console.WriteLine();
                Console.WriteLine("===============================================================");
                Console.WriteLine();
                return;
            }
            if (resStr1 == "" && resStr2 == "")
            {
                Console.WriteLine("输入1：" + title1 + ".docx，输入2：" + title2 + ".docx，输出为：");
                Console.WriteLine();
                Console.WriteLine("没有替换题！");
                return;
            }
        }
    }
}
