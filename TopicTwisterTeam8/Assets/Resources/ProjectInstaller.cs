using Architecture.User.Repository;
using Architecture.User.UseCase;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILocalPlayerDataRepository>().To<PlayerPrefsPlayerDataRepository>().AsSingle();
        Container.Bind<IGetUserDataUseCase>().To<GetUserData>().AsSingle();
    }
}