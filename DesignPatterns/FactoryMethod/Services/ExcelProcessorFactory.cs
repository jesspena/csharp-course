namespace DocumentProcessor.Services;

public class ExcelProcessorFactory : DocumentProcessorFactory
{
  public override IDocumentProcessor CreateProcessor()
  {
    // We can have more logic to create the instance
    return new ExcelProcessorFactory();
  }
}