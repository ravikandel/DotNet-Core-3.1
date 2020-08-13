using DemoApp.Common.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Business.Product
{
    public interface IProductBusiness
    {
        IList<Common.Common.Product> GetAll();
        DbResponse InsertUpdate(Common.Common.Product model);
        Common.Common.Product PopulateById(int? PId);
        DbResponse Delete(int? PId);

    }
}
