using DAL.DB;
using DAL.ListCollection;
using INoteBookBLL;
using INoteBookDAL;
using Ninject;
using Ninject.Web.Common.WebHost;
using NoteBook.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NoteMVC
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            Registration(kernel);

            return kernel;
        }

        private void Registration(StandardKernel kernel)
        {
            kernel.Bind<INoteBookLogic>().To<NoteBookLogic>();
            kernel.Bind<INoteBookDao>().To<NoteDaoList>();
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
