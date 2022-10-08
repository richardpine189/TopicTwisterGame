using Core.Match.Interface;
using Core.Match.Service;
using MainScene.Header;
using MainScene.MatchList.Repository;
using UnityEngine;
using Zenject;

public class MatchListInstaller : MonoInstaller
{
    [SerializeField] private HeaderMainView _headerMainView;
    [SerializeField] private MatchListView _matchListView;
    [SerializeField] private NewGameView _newGameView;
    [SerializeField] private RouteConfig _routeAPI;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<MatchGateway>().AsSingle().WithArguments(_routeAPI.path).NonLazy();
        Container.Bind<IHeaderMainView>().To<HeaderMainView>().FromInstance(_headerMainView).NonLazy();
        Container.Bind<IMatchListView>().To<MatchListView>().FromInstance(_matchListView).NonLazy();
        Container.Bind<IGetMatchesInfoUseCase>().To<MatchListGetterUseCase>().AsTransient().NonLazy();
        Container.Bind<IMatchIdRepository>().To<PlayerPrefMatchIdRepository>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchIDUseCase>().AsSingle().NonLazy();
        Container.Bind<INewGameView>().To<NewGameView>().FromInstance(_newGameView).NonLazy();

        Container.Instantiate<HeaderMainPresenter>();
        Container.Instantiate<MatchListPresenter>();
        Container.Instantiate<NewGamePresenter>();
    }
}