using Assets.Scripts.Presenters;
using Core.Match;
using Core.Match.Interface;
using Core.Match.PlayersNames;
using Core.Match.Service;
using Core.Match.TitleHeaderView;
using MainScene.MatchList.Repository;
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
    private AnsweringView _answeringView;

    [SerializeField]
    private CorrectionView _correctionView;

    [SerializeField]
    private EndRoundView _endRoundView;

    #region Header Provider
    
    [SerializeField]
    private MatchHeaderView _matchHeaderView;

    [SerializeField]
    private MatchHeaderLetterView _matchHeaderLetterView;

    [SerializeField]
    private PlayerNameView _matchHeaderPlayerNameView;

    [SerializeField]
    private TitleHeaderView _matchHeaderTitleView;

    #endregion


    [SerializeField]
    private RouteConfig _categoriesRouteConfig;

    public override void InstallBindings()
    {
        IGetMatchService matchService = new MatchService(API_URL_BASE_PATH);
        //RemoveActiveMatch remove = new RemoveActiveMatch();
        Container.Bind<IActiveMatch>().To<ActiveMatchInMemory>().AsSingle().NonLazy();
        Container.BindInterfacesTo<SaveDataMatchInMemory>().AsTransient();
        Container.BindInterfacesTo<GetDataMatchInMemory>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchHasUseCase>().AsTransient();
        Container.BindInterfacesTo<PlayerPrefMatchIdRepository>().AsTransient().NonLazy();
        Container.Bind<ICategoryService>().To<CategoryService>().AsTransient().WithArguments(_categoriesRouteConfig.path).NonLazy();
        
        Container.Bind<RemoveActiveMatch>().AsTransient();
        Container.Bind<ResetActiveMatch>().AsTransient();
        
        Container.Bind<ILoadingGameView>().To<LoadingGameView>().FromInstance(_loadingView).NonLazy();
        Container.Bind<IGetCurrentMatchUseCase>().To<GetCurrentMatchUseCase>().AsTransient().WithArguments(matchService).NonLazy();
        Container.Bind<IGetMatchId>().To<MatchIDUseCase>().AsTransient().NonLazy();
        //Container.Bind<LoadingGamePresenter>().AsTransient().Lazy();
        Container.Instantiate<LoadingGamePresenter>();
        
        //Container.BindInterfacesTo<LetterView>().FromInstance(_letterView).NonLazy();
        Container.Bind<ILetterView>().To<LetterView>().FromInstance(_letterView).NonLazy();
        Container.Bind<IGetLetterUseCase>().To<GetRandomLetterUseCase>().AsTransient();
        //Container.Bind<LetterPresenter>().AsTransient().Lazy();
        Container.Instantiate<LetterPresenter>();
        
        //Container.BindInterfacesTo<CategoriesView>().FromInstance(_categoriesView).NonLazy();
        Container.Bind<ICategoriesView>().To<CategoriesView>().FromInstance(_categoriesView).NonLazy();
        Container.Bind<ICategoriesGetter>().To<GetCategoriesUseCase>().AsTransient().NonLazy();
        //Container.Bind<CategoriesPresenter>().AsTransient().Lazy();
        Container.Instantiate<CategoriesPresenter>();
        
        //Container.BindInterfacesTo<AnsweringView>().FromInstance(_answeringView).NonLazy();
        Container.Bind<IAnsweringView>().To<AnsweringView>().FromInstance(_answeringView).NonLazy();
        //Container.Bind<AnswersPresenter>().AsTransient().Lazy();
        Container.Instantiate<AnswersPresenter>();
        
        Container.Bind<IRoundTimerView>().To<RoundTimerView>().FromInstance(_roundTimerView).NonLazy();
        Container.Bind<IRoundTimerUseCase>().To<RoundTimerUseCase>().AsTransient().NonLazy();
        //Container.Bind<RoundTimerPresenter>().AsTransient().Lazy();
        Container.Instantiate<RoundTimerPresenter>();
  
        //Container.BindInterfacesTo<CorrectionView>().FromInstance(_correctionView).NonLazy();
        Container.Bind<ICorrectionView>().To<CorrectionView>().FromInstance(_correctionView).NonLazy();
        Container.Bind<IGetCorrections>().To<CorrectionGetter>().AsTransient();
        Container.Bind<IUpdateMatchUseCase>().To<UpdateMatchUseCase>().AsTransient().WithArguments(matchService);
        //Container.Bind<CorrectionPresenter>().AsTransient().Lazy();
        Container.Instantiate<CorrectionPresenter>();

        Container.Bind<IGetRoundResult>().To<GetRoundResultsUseCase>().AsTransient().WithArguments(matchService);
        Container.Bind<IEndRoundView>().To<EndRoundView>().FromInstance(_endRoundView).NonLazy();
        Container.Instantiate<EndRoundPresenter>();
        
        Container.Bind<IMatchHeaderView>().To<MatchHeaderView>().FromInstance(_matchHeaderView).NonLazy();
        Container.Bind<IMatchHeaderLetterView>().To<MatchHeaderLetterView>().FromInstance(_matchHeaderLetterView).NonLazy();
        Container.Bind<IPlayerNameView>().To<PlayerNameView>().FromInstance(_matchHeaderPlayerNameView).NonLazy();
        Container.Bind<ITitleHeaderView>().To<TitleHeaderView>().FromInstance(_matchHeaderTitleView).NonLazy();
        Container.Instantiate<MatchHeaderPresenter>();
        Container.Instantiate<MatchHeaderLetterPresenter>();
        Container.Instantiate<PlayerNamePresenter>();
        Container.Instantiate<TitleHeaderPresenter>();
    }
}