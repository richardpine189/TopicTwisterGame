using Assets.Scripts.Presenters;
using Core.Match;
using Core.Match.Interface;
using Core.Match.Service;
using Team8.TopicTwister;
using UnityEngine;
using Zenject;

public class MatchDependencyInstaller : MonoInstaller
{
    [SerializeField] private LoadingGameView _loadingView;
    private readonly string API_URL_BASE_PATH = "http://0.0.0.0:8082";
    public override void InstallBindings()
    {
        IGetMatchService service = new MatchService(API_URL_BASE_PATH);
        Container.Bind<ILoadingGameView>().To<LoadingGameView>().FromInstance(_loadingView).NonLazy();
        Container.Bind<IGetCurrentMatchUseCase>().To<GetCurrentMatchUseCase>().AsTransient().WithArguments(service).NonLazy();
        Container.BindInterfacesTo<LoadingGamePresenter>().AsTransient().Lazy();
    }
}