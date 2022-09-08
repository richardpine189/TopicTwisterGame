using UnityEngine;
using Zenject;

public class LoginDependencyInstaller : MonoInstaller
{
    [SerializeField]
    private LoginView _loginView;

    [SerializeField] private RouteConfig _config;
    public override void InstallBindings()
    {
        Container.Bind<ILoginGetUserAction>().To<LoginAction>().AsTransient().NonLazy();
        Container.Bind<ILoginView>().To<LoginView>().FromInstance(_loginView).NonLazy();
        Container.Bind<ILoginService>().To<LoginService>().AsTransient().WithArguments(_config.path).NonLazy();
        //Container.BindInterfacesTo<LoginPresenter>().AsTransient().Lazy();
        Container.Instantiate<LoginPresenter>();
    }
}