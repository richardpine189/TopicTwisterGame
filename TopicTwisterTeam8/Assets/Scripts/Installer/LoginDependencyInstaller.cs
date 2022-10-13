using UnityEngine;
using Zenject;

public class LoginDependencyInstaller : MonoInstaller
{
    [SerializeField]
    private LogInView _loginView;

    [SerializeField]
    private SignInView _signInView;

    [SerializeField] private RouteConfig _config;
    public override void InstallBindings()
    {
        Container.Bind<ILoginView>().To<LogInView>().FromInstance(_loginView).NonLazy();
        Container.Bind<ILoginGetUserUseCase>().To<LoginUserUseCase>().AsTransient().NonLazy();

        Container.Bind<ISignInView>().To<SignInView>().FromInstance(_signInView).NonLazy();
        Container.Bind<ISignInUseCase>().To<SignInUseCase>().AsTransient().NonLazy();

        Container.Bind<IUsersService>().To<UserGateway>().AsTransient().WithArguments(_config.path).NonLazy();

        Container.Instantiate<LoginPresenter>();
        Container.Instantiate<SignInPresenter>();
    }
}