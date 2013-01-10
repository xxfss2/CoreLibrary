using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Jiuzh.CoreBase.Infrastructure;
namespace Jiuzh.Infrastructure.EnterpriseLibrary
{
    
    using System.Configuration;

 //   using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
    public class WeblogLoggingExceptionHandlerData : ExceptionHandlerData
    {
        private const string Category = "logCategory";

        public WeblogLoggingExceptionHandlerData()
            : base(typeof(WeblogLoggingExceptionHandler))
        {
        }

        public WeblogLoggingExceptionHandlerData(string name, string logCategory)
            : base(name, typeof(WeblogLoggingExceptionHandler))
        {
            LogCategory = logCategory;
        }

        [ConfigurationProperty(Category, IsRequired = true)]
        public string LogCategory
        {
            get
            {
                return (string)this[Category];
            }
            set
            {
                this[Category] = value;
            }
        }


        public override IEnumerable<TypeRegistration> GetRegistrations(string namePrefix)
        {
             yield return
                new TypeRegistration<IExceptionHandler>(
                    () => new WeblogLoggingExceptionHandler(LogCategory, IoC.Resolve<ILogger>()))
                {
                    Name = BuildName(namePrefix),
                    Lifetime = TypeRegistrationLifetime.Transient
                };
        }



    }
}
