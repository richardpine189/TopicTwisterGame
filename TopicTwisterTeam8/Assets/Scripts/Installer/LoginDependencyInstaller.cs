using UnityEngine;
using Zenject;

public class LoginDependencyInstaller : MonoInstaller
{
    [SerializeField]
    private LoginView _loginView;

    [SerializeField] private RouteConfig _config;
    public override void InstallBindings()
    {
        Container.Bind<ILoginGetUserUseCase>().To<LoginUserUseCase>().AsTransient().NonLazy();
        Container.Bind<ILoginView>().To<LoginView>().FromInstance(_loginView).NonLazy();
        Container.Bind<ILoginService>().To<LoginService>().AsTransient().WithArguments(_config.path).NonLazy();
        Container.Instantiate<LoginPresenter>();
    }
}