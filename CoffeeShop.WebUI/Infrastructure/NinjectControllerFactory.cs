using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using CoffeeShop.Domain.DbConc;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;
using Moq;
using Ninject;

namespace CoffeeShop.WebUI.Infrastructure
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {

            ninjectKernel.Bind<IProductRepository>().To<EfProductRepository>().InSingletonScope();
            //singleton, single instance
        }
        
    }
}