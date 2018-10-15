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

        static void Main(string[] args)
        {
            string wordPathStr = @"\documents\科研细则.docx";
            using (WordprocessingDocument doc = WordprocessingDocument.Open(wordPathStr, true))
            {
                Body body = doc.MainDocumentPart.Document.Body;
                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    Console.WriteLine(paragraph.InnerText);
                }
            }
            Console.ReadLine();
        }
    }
}
