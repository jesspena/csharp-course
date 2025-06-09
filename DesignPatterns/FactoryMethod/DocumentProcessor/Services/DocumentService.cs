namespace DocumentProcessor.Services;

public class DocumentService
{
  // Initialize available factories - follows Dependency Inversion Principle
  private readonly Dictionary<string, DocumentProcessorFactory> _factories = new(StringComparer.OrdinalIgnoreCase)
  {
      { "pdf", new PdfProcessorFactory() },
      { "word", new WordProcessorFactory() },
      { "excel", new ExcelProcessorFactory() }
  };

  public void ProcessDocument(string documentType, string content)
  {
    if (!_factories.TryGetValue(documentType, out var factory))
    {
      throw new NotSupportedException($"Document type '{documentType}' is not supported");
    }

    factory.ProcessDocument(content);
  }

  public IEnumerable<string> GetSupportedFormats()
  {
    return _factories.Keys;
  }
}