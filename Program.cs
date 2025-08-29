using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== PDF Content Comparator ===");

        string folder1 = "DocsA";  
        string folder2 = "DocsB";

        var comparator = new PdfComparator();
        comparator.CompareFolders(folder1, folder2);
    }
}
