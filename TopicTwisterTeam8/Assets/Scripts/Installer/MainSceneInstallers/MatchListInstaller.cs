using Core.Match.Service;
using UnityEngine;
using Zenject;

public class MatchListInstaller : MonoInstaller
{
    [SerializeField] private MatchListView _matchListView;

    public override void InstallBindings()
    {
        MatchService matchServices = new MatchService("http://localhost:8082");
        Container.Bind<IMatchListView>().To<MatchListView>().FromInstance(_matchListView).NonLazy();
        Container.Bind<IGetMatchesService>().To<MatchService>().FromInstance(matchServices).NonLazy();
        Container.Bind<IGetMatchesInfoUseCase>().To<MatchListGetterUseCase>().AsTransient().NonLazy();
        //Container.Bind<IGetMatches>().To<JsonMatchRepository>().AsTransient().NonLazy();
        
        Container.BindInterfacesTo<MatchListPresenter>().AsTransient().Lazy();
    }
}