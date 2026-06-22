using System;

namespace FactoryMethodPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Factory Method Pattern Example");
            Console.WriteLine("========================================");

            // Create document factories
            DocumentFactory wordFactory = new WordDocumentFactory();
            DocumentFactory pdfFactory = new PdfDocumentFactory();
            DocumentFactory excelFactory = new ExcelDocumentFactory();

            // Create and test Word document
            Console.WriteLine("\n--- Testing Word Document Creation ---");
            IDocument wordDoc = wordFactory.CreateDocument();
            wordDoc.Open();
            wordDoc.Save();
            wordDoc.Close();

            // Create and test PDF document
            Console.WriteLine("\n--- Testing PDF Document Creation ---");
            IDocument pdfDoc = pdfFactory.CreateDocument();
            pdfDoc.Open();
            pdfDoc.Save();
            pdfDoc.Close();

            // Create and test Excel document
            Console.WriteLine("\n--- Testing Excel Document Creation ---");
            IDocument excelDoc = excelFactory.CreateDocument();
            excelDoc.Open();
            excelDoc.Save();
            excelDoc.Close();

            Console.WriteLine("\nFactory Method Pattern demonstration completed.");
        }
    }
}
