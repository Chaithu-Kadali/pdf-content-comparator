📑 PDF Content Comparator

Compare text and images inside two sets of PDF documents using OCR + AI.

🚀 Overview

This tool extracts text and screenshots from PDF documents, applies OCR where necessary, and then uses AI embeddings to measure similarity between two document sets. Ideal for scenarios like identifying reused or modified documents.

🛠 Tech Stack

C# (.NET)

iTextSharp (PDF parsing)

Tesseract OCR (image text extraction)

Azure OpenAI (text-embedding-ada-002 for similarity)

✨ Features

Extracts both text and image content from PDFs

OCR support for scanned pages

AI-based semantic similarity comparison

Generates similarity reports

⚙️ Setup

Clone the repo

git clone https://github.com/<your-username>/pdf-content-comparator.git


Open the solution in Visual Studio

Install dependencies via NuGet:

iTextSharp

Tesseract

Azure.AI.OpenAI

Add your Azure OpenAI API key in appsettings.json

▶️ Usage
dotnet run


Input folder A: /FastSearchDocs

Input folder B: /EwbDocs

Output: CSV report with similarity scores

🔮 Future Work

Add UI dashboard for comparison results

Support for more document formats (Word, Excel)

Parallel processing for large PDF sets
