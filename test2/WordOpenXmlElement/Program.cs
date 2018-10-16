using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;

namespace WordOpenXmlElement
{
    class Program
    {

        //使用DocumentFormat.OpenXml解析word文档，输出word文本内容
        static void Main(string[] args)
        {
            //“科研细则.docx”存储路径
            string filePath = @"E:\Study\studywork\test2\documents\科研细则.docx";
            //使用文件路径打开WordprocessingDocument进行处理。
            using (WordprocessingDocument wordprocessingDocument =
                WordprocessingDocument.Open(filePath, false))
            {
                // DocumentFormat.OpenXml.Wordprocessing.Body创建一个body对象，存储上述文档的body
                Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
                //定义一个paragraph，遍历循环word正文中的段落元素
                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    Console.WriteLine(paragraph.InnerText);  //输出段落中的内容
                }
                Console.ReadKey();  //等待键盘输入，退出程序。使调试时能看到输出结果。如果没有此句，命令窗口会一闪而过。
            }
        }
    }
}

