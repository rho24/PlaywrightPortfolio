using System;
using AspNet.Identity.RavenDB.Stores;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using PlaywrightPortfolio.Models;
using Raven.Client;
using Raven.Client.Document;

namespace PlaywrightPortfolio.App_AutofacModules
{
    public class RavenDBConfig : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.Register(
                c => {
                    IDocumentStore store = new DocumentStore { ConnectionStringName = "RavenDb", DefaultDatabase = "playwright" }.Initialize();

                    return store;
                }).As<IDocumentStore>().SingleInstance();

            builder.Register(c => c.Resolve<IDocumentStore>().OpenAsyncSession()).As<IAsyncDocumentSession>().InstancePerHttpRequest();
            builder.Register(c => new RavenUserStore<ApplicationUser>(c.Resolve<IAsyncDocumentSession>(), false)).As<IUserStore<ApplicationUser>>().InstancePerHttpRequest();
            builder.RegisterType<UserManager<ApplicationUser>>().InstancePerHttpRequest();
        }
    }
}