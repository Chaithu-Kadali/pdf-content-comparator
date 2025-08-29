using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Tesseract;

public class PdfComparator
{
    public void CompareFolders(string folder1, string folder2)
    {
        foreach (var file1 in Directory.GetFiles(folder1, "*.pdf"))
        {
            foreach (var file2 in Directory.GetFiles(folder2, "*.pdf"))
            {
                string text1 = ExtractText(file1);
                string text2 = ExtractText(file2);

                double similarity = CalculateCosineSimilarity(text1, text2);
                Console.WriteLine($"{Path.GetFileName(file1)} vs {Path.GetFileName(file2)} => {similarity * 100:F2}% similar");
            }
        }
    }

    private string ExtractText(string filePath)
    {
        using var reader = new PdfReader(filePath);
        string text = "";
        for (int i = 1; i <= reader.NumberOfPages; i++)
        {
            text += PdfTextExtractor.GetTextFromPage(reader, i);
        }
        return text;
    }

    private double CalculateCosineSimilarity(string text1, string text2)
    {
        var words1 = text1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var words2 = text2.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var set = new HashSet<string>(words1);
        set.UnionWith(words2);

        var vec1 = new List<int>();
        var vec2 = new List<int>();

        foreach (var word in set)
        {
            vec1.Add(Array.FindAll(words1, w => w == word).Length);
            vec2.Add(Array.FindAll(words2, w => w == word).Length);
        }

        double dot = 0, mag1 = 0, mag2 = 0;
        for (int i = 0; i < vec1.Count; i++)
        {
            dot += vec1[i] * vec2[i];
            mag1 += Math.Pow(vec1[i], 2);
            mag2 += Math.Pow(vec2[i], 2);
        }

        return dot / (Math.Sqrt(mag1) * Math.Sqrt(mag2) + 1e-10);
    }
}
