using DavidTielke.PersonManagerApp.Data.DataStoring;
using DavidTielke.PersonManagerApp.Logic.PersonManagement;
using Ninject;

namespace DavidTielke.PersonManagerApp.Infrastructure.Mappings;

public class KernelFactory
{
    public IKernel Create()
    {
        var kernel = new StandardKernel();

        kernel.Bind<IPersonManager>().To<PersonManager>();
        kernel.Bind<IPersonRepository>().To<PersonRepository>();
        kernel.Bind<IPersonParser>().To<PersonParser>();

        return kernel;
    }
}