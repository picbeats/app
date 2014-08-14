namespace app.web.application.catalog_browsing
{
  public interface ICreateReport
  {
    Report create<ReportInput, Report>(ReportInput input);
  }
}