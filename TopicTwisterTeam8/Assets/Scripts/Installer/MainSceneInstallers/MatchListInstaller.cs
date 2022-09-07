using Core.Match.Interface;
using Core.Match.Service;
using MainScene.MatchList.Repository;
using UnityEngine;
using Zenject;

public class MatchListInstaller : MonoInstaller
{
    [SerializeField] private MatchListView _matchListView;
    [SerializeField] private NewGameView _newGameView;
    public override void InstallBindings()
    {
        MatchService matchServices = new MatchService("http://localhost:8082");
        
        Container.Bind<IMatchListView>().To<MatchListView>().FromInstance(_matchListView).NonLazy();
        Container.Bind<IGetMatchesService>().To<MatchService>().FromInstance(matchServices).NonLazy();
        Container.Bind<IGetMatchService>().To<MatchService>().FromInstance(matchServices).NonLazy();
        Container.Bind<IGetMatchesInfoUseCase>().To<MatchListGetterUseCase>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchListPresenter>().AsTransient().Lazy();
        Container.Bind<IMatchIdRepository>().To<PlayerPrefMatchIdRepository>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchIDUseCase>().AsSingle();

        Container.Bind<INewGameView>().To<NewGameView>().FromInstance(_newGameView).NonLazy();
        Container.BindInterfacesTo<NewGamePresenter>().AsTransient().Lazy();



    }
}