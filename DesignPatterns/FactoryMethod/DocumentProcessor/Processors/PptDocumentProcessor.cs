using DocumentProcessor.Interfaces;

namespace DocumentProcessor.Processors;

public class PptDocumentProcessor : IDocumentProcessor
{
  public void ProcessDocument(string content)
  {
    Console.WriteLine("Processing Ppt document");
    Console.WriteLine($"Converting Ppt content: {content}");
    Console.WriteLine($"Ppt processing completed with spreadsheet format");
  }

  public string GetSupportedFormat() => "Ppt";
}