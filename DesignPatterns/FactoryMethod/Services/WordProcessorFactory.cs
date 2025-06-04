namespace DocumentProcessor.Services;

public class WordProcessorFactory : DocumentProcessorFactory
{
  public override IDocumentProcessor CreateProcessor()
  {
    // We can have more logic to create the instance
    return new WordProcessorFactory();
  }
}