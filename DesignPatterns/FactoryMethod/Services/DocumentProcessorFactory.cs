namespace DocumentProcessor.Services;

public abstract class DocumentProcessorFactory
{
  public abstract IDocumentProcessor CreateProcessor();

  public void ProcessDocument(string content)
  {
    var processor = CreateProcessor();
    processor.ProcessDocument(content);

    Console.WriteLine($"Document processed using {processor.GetSupportedFormat()} processor");
    Console.WriteLine($"Processing completed successfully.\n");
  }
}