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
            container.RegisterType<IAutenticacaoBLL, AutenticacaoBLL>();
            container.RegisterType<IAdministrativoBLL, Administrativo>();
            container.RegisterType<IEscalacaoBLL, EscalacaoBLL>();

            container.RegisterType<IHomeDAL, HomeDAL>();
            container.RegisterType<IAutenticacaoDAL, AutenticacaoDAL>();
            container.RegisterType<IAdministrativoDAL, AdministrativoDAL>();
            container.RegisterType<IEscalacaoDAL, EscalacaoDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
