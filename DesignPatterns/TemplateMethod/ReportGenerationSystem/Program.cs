using ReportGenerationSystem.Services;

var reportService = new ReportService();
reportService.GenerateAllReports();
reportService.GenerateAllReportsInFormat("CSV");
