namespace DocumentProcessor;

public class DocumentProcessorBad
{
  public void ProcessDocument(string documentType, string content)
  {
    // Violation of Open/Closed Principle - needs modification for new document type
    // Violation of Single Responsibility - knows about all document types
    // The code is repeated and tightly coupled
    if (documentType.Equals("pdf", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Processing PDF document");
      Console.WriteLine($"Converting PDF content: {content}");
      Console.WriteLine($"PDF processing completed with Adobe format");
    }
    else if (documentType.Equals("word", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Processing Word document");
      Console.WriteLine($"Converting Word content: {content}");
      Console.WriteLine($"Word processing completed with Microsoft format");
    }
    else if (documentType.Equals("excel", StringComparison.CurrentCultureIgnoreCase))
    {
      Console.WriteLine("Processing Excel document");
      Console.WriteLine($"Converting Excel content: {content}");
      Console.WriteLine($"Excel processing completed with spreadsheet format");
    }
    else
    {
      throw new NotSupportedException($"Document type '{documentType}' is not supported");
    }
  }
}