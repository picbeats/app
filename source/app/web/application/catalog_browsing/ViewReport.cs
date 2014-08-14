using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app.web.application.catalog_browsing
{
  public class ViewReport<ReportInput, Report> : ISupportAUserStory
  {
    ICreateReport report_creator;
    IDisplayInformation display_engine;

    public ViewReport(ICreateReport reportCreator, IDisplayInformation displayEngine)
    {
      report_creator = reportCreator;
      display_engine = displayEngine;
    }

    public void process(IProvideRequestDetails request)
    {
      var input = request.map<ReportInput>();
      var results = report_creator.create<ReportInput, Report>(input);
      display_engine.display(results);
    }
  }
}
