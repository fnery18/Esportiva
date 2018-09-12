using Esportiva.BLL;
using Esportiva.BLL.Interfaces;
using Esportiva.DAL;
using Esportiva.DAL.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Esportiva
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IHomeBLL, HomeBLL>();

            container.RegisterType<IHomeDAL, HomeDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}