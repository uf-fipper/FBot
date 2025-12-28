using FBot.Invoker;
using Microsoft.Extensions.DependencyInjection;

namespace FBot;

public interface IFDriverBuilder
{
    IServiceCollection Services { get; }

    IDependentInvokerBuilder InvokerBuilder { get; }
}

public class FDriverBuilder(IServiceCollection services, IDependentInvokerBuilder invokerBuilder)
    : IFDriverBuilder
{
    public IServiceCollection Services => services;

    public IDependentInvokerBuilder InvokerBuilder => invokerBuilder;
}
