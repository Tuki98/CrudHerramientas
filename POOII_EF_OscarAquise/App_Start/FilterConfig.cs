using System.Web;
using System.Web.Mvc;

namespace POOII_EF_OscarAquise
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
