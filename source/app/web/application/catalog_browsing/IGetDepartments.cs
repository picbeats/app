using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
  public interface IGetDepartments
  {
    IEnumerable<MainDepartmentLineItem> get_the_departments(DepartmentMatch match);
  }   
  }
 