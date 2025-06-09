using DocumentProcessor.Services;

namespace DocumentProcessor;

public class Program
{
  public static void Main()
  {
    Console.WriteLine("Factory Method\n");
    Console.WriteLine("Tightly coupled approach");

    var coupledProcessor = new DocumentProcessorBad();

    try
    {
      coupledProcessor.ProcessDocument("pdf", "Sample PDF content");
      Console.WriteLine();
      coupledProcessor.ProcessDocument("word", "Sample Word content");
      // What would happen if we would need to add PowerPoint support ?
      // We would be violating design principles
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine($"\n{new string('-', 15)}\n");

    Console.WriteLine("Applied Factory Method");

    var documentService = new DocumentService();

    var documentExamples = new[]
    {
      new { Type = "pdf", Content = "Important PDF contract content"},
      new { Type = "word", Content = "Meeting notes and action items"},
      new { Type = "excel", Content = "Financial data in tables"}
    };

    foreach (var document in documentExamples)
    {
      try
      {
        documentService.ProcessDocument(document.Type, document.Content);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error processing {document.Type}: {ex.Message}\n");
      }
    }
  }
}