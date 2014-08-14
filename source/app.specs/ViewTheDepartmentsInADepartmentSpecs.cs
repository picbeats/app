using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof (ViewTheMainDepartments))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserStory,
      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      private Establish c =
        () =>
        {
          display_engine = depends.on<IDisplayInformation>();
          department_finder = depends.on<IGetDepartments>();

          request = fake.an<IProvideRequestDetails>();

          match = fake.an<DepartmentMatch>();
          departmentMatch = req => match;
          departments = new List<MainDepartmentLineItem>();
          department_finder.setup(x => x.get_the_departments(match)).Return(departments);      
        };

      Because b = () =>
        sut.process(request);

      private It displays_the_departments = () =>
        display_engine.received(x => x.display(departments));

      private static IBuildDepartmentMatch departmentMatch;
      static IProvideRequestDetails request;
      private static DepartmentMatch match;
      private static IDisplayInformation display_engine;
      private static IGetDepartments department_finder;
      private static IEnumerable<MainDepartmentLineItem> departments;
    }
  }
}
