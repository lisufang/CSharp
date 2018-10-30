using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AutomaticProgram
{
    class ReadWord
    {
        public List<string> TextList = new List<string>();
        public string strList;
        public void ChangeToStr(List<string> text)
        {

        }
        public ReadWord(string filename)
        {
            try
            {
                //使用文件路径打开WordprocessingDocument进行处理
                using (WordprocessingDocument wordprocessingDocument =
                WordprocessingDocument.Open(filename, true))
                {
                    // DocumentFormat.OpenXml.Wordprocessing.Body创建一个body对象，存储上述文档的body
                    DocumentFormat.OpenXml.Wordprocessing.Body body = wordprocessingDocument.MainDocumentPart.Document.Body;

                    //  定义一个elements,获取所有元素
                    IEnumerable<DocumentFormat.OpenXml.OpenXmlElement> elements = body.Elements<DocumentFormat.OpenXml.OpenXmlElement>();
                    //遍历元素列表，输出内容
                    foreach (DocumentFormat.OpenXml.OpenXmlElement element in elements)
                    {
                        strList += element.InnerText.ToString();
                        TextList.Add(element.InnerText);
                    }
                }
            }
            catch
            {
                Console.WriteLine("没有找到文件");
                Console.ReadKey();
            }
        }
    }
}
