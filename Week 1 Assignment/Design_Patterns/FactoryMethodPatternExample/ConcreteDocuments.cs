using System;

namespace FactoryMethodPatternExample
{
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Word Document (.docx)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Word Document...");
        }

        public void Close()
        {
            Console.WriteLine("Closing Word Document.");
        }
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document (.pdf)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving (exporting) PDF Document...");
        }

        public void Close()
        {
            Console.WriteLine("Closing PDF Document.");
        }
    }

    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel Spreadsheet (.xlsx)...");
        }

        public void Save()
        {
            Console.WriteLine("Saving Excel Spreadsheet...");
        }

        public void Close()
        {
            Console.WriteLine("Closing Excel Spreadsheet.");
        }
    }
}
