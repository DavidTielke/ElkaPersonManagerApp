using Ninject;
using PersonManagerApp.ConsoleClient;

namespace Mappings;

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