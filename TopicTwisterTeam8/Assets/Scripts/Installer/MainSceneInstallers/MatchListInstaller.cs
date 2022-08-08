using UnityEngine;
using Zenject;

public class MatchListInstaller : MonoInstaller
{
    [SerializeField] private MatchListView _matchListView;

    public override void InstallBindings()
    {
        Container.Bind<IMatchListView>().To<MatchListView>().FromInstance(_matchListView).NonLazy();
        Container.Bind<IGetMatchesInfo>().To<MatchListGetter>().AsTransient().NonLazy();
        Container.Bind<IMatchRepository>().To<JsonMatchRepository>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchListPresenter>().AsTransient().Lazy();
    }
}