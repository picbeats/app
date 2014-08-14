using System.Collections.Generic;

namespace app.web.application.catalog_browsing
{
    public interface IFindProductsInADepartment
    {
        IEnumerable<ProductInfoItem> get_products_of_department(ProductsInDepartmentInput input);
    }
}