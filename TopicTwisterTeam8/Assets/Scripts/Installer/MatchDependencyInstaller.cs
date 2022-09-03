using Assets.Scripts.Presenters;
using Core.Match;
using Core.Match.Interface;
using Core.Match.Service;
using Team8.TopicTwister;
using UnityEngine;
using Zenject;

public class MatchDependencyInstaller : MonoInstaller
{
    private readonly string API_URL_BASE_PATH = "http://localhost:8082";
    
    [SerializeField]
    private LoadingGameView _loadingView;

    [SerializeField]
    private LetterView _letterView;

    [SerializeField]
    private CategoriesView _categoriesView;

    [SerializeField]
    private RoundTimerView _roundTimerView;

    [SerializeField]
    private RouteConfig _categoriesRouteConfig;

    public override void InstallBindings()
    {
        Container.Bind<IActiveMatch>().To<ActiveMatchInMemory>().AsSingle().NonLazy();
        Container.BindInterfacesTo<SaveDataMatchInMemory>().AsTransient();
        Container.BindInterfacesTo<MatchHasUseCase>().AsTransient();
        Container.BindInterfacesTo<GetMatchDataUseCase>().AsTransient();

        IGetMatchService service = new MatchService(API_URL_BASE_PATH);
        Container.Bind<ILoadingGameView>().To<LoadingGameView>().FromInstance(_loadingView).NonLazy();
        Container.Bind<IGetCurrentMatchUseCase>().To<GetCurrentMatchUseCase>().AsTransient().WithArguments(service).NonLazy();
        Container.BindInterfacesTo<LoadingGamePresenter>().AsTransient().Lazy();

        Container.Bind<ILetterView>().To<LetterView>().FromInstance(_letterView).NonLazy();
        Container.Bind<IGetLetterUseCase>().To<GetRandomLetterUseCase>().AsTransient();
        Container.BindInterfacesTo<LetterPresenter>().AsTransient().Lazy();

        Container.Bind<ICategoriesView>().To<CategoriesView>().FromInstance(_categoriesView).NonLazy();
        Container.Bind<ICategoryService>().To<CategoryService>().AsTransient().WithArguments(_categoriesRouteConfig.path).NonLazy();
        Container.Bind<ICategoriesGetter>().To<GetCategoriesUseCase>().AsTransient().NonLazy();
        Container.BindInterfacesTo<CategoriesPresenter>().AsTransient().Lazy();

        Container.Bind<IRoundTimerView>().To<RoundTimerView>().FromInstance(_roundTimerView).NonLazy();
        Container.Bind<IRoundTimerUseCase>().To<RoundTimerUseCase>().AsTransient().NonLazy();
        Container.BindInterfacesTo<RoundTimerPresenter>().AsTransient().Lazy();
    }
}