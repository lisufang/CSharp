using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing; 

namespace WordOpenXmlElement
{
    class Program
    {
       
             static void Main(string[] args)
        {
            string fileName = @"C:\Users\Public\Documents\AccessElementsSameLevel.docx";
            using (WordprocessingDocument wordprocessingDocument = 
                WordprocessingDocument.Open(fileName, false))
            {
                // Create a Body object.
                DocumentFormat.OpenXml.Wordprocessing.Body body =
                    wordprocessingDocument.MainDocumentPart.Document.Body;

                // Create a Paragraph object.
                DocumentFormat.OpenXml.Wordprocessing.Paragraph firstParagraph =
                    body.Elements<Paragraph>().FirstOrDefault();

                // Get the first child of an OpenXmlElement.
                 DocumentFormat.OpenXml.OpenXmlElement firstChild = firstParagraph.FirstChild;
                IEnumerable<Run> elementsAfter =
                    firstChild.ElementsAfter().Where(c => c is Run).Cast<Run>();

                // Get the Run elements after the specified element.
                Console.WriteLine("Run elements after the first child are: ");
                foreach (DocumentFormat.OpenXml.Wordprocessing.Run run in elementsAfter)
                {
                    Console.WriteLine(run.InnerText);
                }
                Console.ReadKey();
            }
        }  
    }
}
