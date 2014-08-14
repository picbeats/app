using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  // [Subject(typeof(ViewReport<object,object>))]
  public class ViewReportSpecs
  {
    public class ReportInput { }
    public class Report { }

    public abstract class concern : Observes<ISupportAUserStory,
      ViewReport<ReportInput,Report>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayInformation>();
        report_creator = depends.on<ICreateReport>();
        input = new ReportInput();
        report = new Report();
        report_creator.setup(x => x.create<ReportInput,Report>(input)).Return(report);
        request = fake.an<IProvideRequestDetails>();
        request.setup(x => x.map<ReportInput>()).Return(input);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_departments_of_the_chosen_department = () =>
        display_engine.received(x => x.display(report));

      static ICreateReport report_creator;
      static IDisplayInformation display_engine;
      static IProvideRequestDetails request;
      static ReportInput input;
      private static Report report;
    }
  }
}