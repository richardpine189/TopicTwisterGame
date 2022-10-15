using Architecture.Category.AnswersPanel;
using Architecture.Category.CorrectionPanel;
using Architecture.Category.Gateway;
using Architecture.Category.UseCases.GetCategories;
using Architecture.Category.UseCases.GetCorrection;
using Architecture.Letter.UseCase;
using Architecture.Match.ActiveMatchRepository;
using Architecture.Match.ActiveMatchRepository.UseCases;
using Architecture.Match.Gateway;
using Architecture.Match.Gateway.Interfaces;
using Architecture.Match.MatchHeader.Letter;
using Architecture.Match.MatchHeader.PlayersNames;
using Architecture.Match.MatchHeader.RoundStatus;
using Architecture.Match.MatchHeader.TitleHeaderView;
using Architecture.Match.Panel.EndRound;
using Architecture.Match.Panel.EndRound.GetRoundResults;
using Architecture.Match.Panel.LoadingMatch;
using Architecture.Match.UseCases.GetCurrentMatch;
using Architecture.Match.UseCases.GetMatchData;
using Architecture.Match.UseCases.GetRoundData;
using Architecture.Match.UseCases.MatchHas;
using Architecture.Match.UseCases.SaveMatchData;
using Architecture.Match.UseCases.SaveRoundData;
using Architecture.Match.UseCases.UpdateMatch;
using Architecture.OnGoingMatch.Repository;
using Architecture.OnGoingMatch.UseCase;
using Architecture.Timer;
using UnityEngine;
using Zenject;

public class MatchDependencyInstaller : MonoInstaller
{
    //private readonly string API_URL_BASE_PATH = "http://localhost:8082";
    
    [SerializeField]
    private LoadingGameView _loadingView;

    [SerializeField]
    private Architecture.Letter.View.LetterView _letterView;

    [SerializeField]
    private Architecture.Category.CategoriesPanel.CategoriesView _categoriesView;

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
    [SerializeField]
    private RouteConfig _matchRouteConfig;

    public override void InstallBindings()
    {
        IGetMatchGateway matchGateway = new MatchGateway(_matchRouteConfig.path);
        //RemoveActiveMatch remove = new RemoveActiveMatch();
        Container.Bind<IActiveMatchRepository>().To<ActiveMatchRepositoryInMemory>().AsSingle().NonLazy();
        Container.BindInterfacesTo<SaveMatchData>().AsTransient();
        Container.BindInterfacesTo<SaveRoundData>().AsTransient();
        Container.BindInterfacesTo<GetRoundData>().AsTransient().NonLazy();
        Container.BindInterfacesTo<GetMatchData>().AsTransient().NonLazy();
        Container.BindInterfacesTo<MatchHas>().AsTransient();
        Container.BindInterfacesTo<PlayerPrefMatchIdRepository>().AsTransient().NonLazy();
        Container.Bind<Architecture.Category.Gateway.ICategoryService>().To<CategoryService>().AsTransient().WithArguments(_categoriesRouteConfig.path).NonLazy();
        
        Container.Bind<RemoveActiveMatch>().AsTransient();
        Container.Bind<ResetActiveMatch>().AsTransient();
        
        Container.Bind<ILoadingGameView>().To<LoadingGameView>().FromInstance(_loadingView).NonLazy();
        Container.Bind<IGetCurrentMatchUseCase>().To<GetCurrentMatch>().AsTransient().WithArguments(matchGateway).NonLazy();
        Container.Bind<IGetMatchId>().To<MatchIDUseCase>().AsTransient().NonLazy();
        //Container.Bind<LoadingGamePresenter>().AsTransient().Lazy();
        Container.Instantiate<LoadingGamePresenter>();
        
        //Container.BindInterfacesTo<LetterView>().FromInstance(_letterView).NonLazy();
        Container.Bind<Architecture.Letter.View.ILetterView>().To<Architecture.Letter.View.LetterView>().FromInstance(_letterView).NonLazy();
        Container.Bind<IGetLetterUseCase>().To<GetRandomLetter>().AsTransient();
        //Container.Bind<LetterPresenter>().AsTransient().Lazy();
        Container.Instantiate<Architecture.Letter.LetterPresenter>();
        
        //Container.BindInterfacesTo<CategoriesView>().FromInstance(_categoriesView).NonLazy();
        Container.Bind<Architecture.Category.CategoriesPanel.ICategoriesView>().To<Architecture.Category.CategoriesPanel.CategoriesView>().FromInstance(_categoriesView).NonLazy();
        Container.Bind<IGetCategoriesUseCase>().To<GetCategories>().AsTransient().NonLazy();
        //Container.Bind<CategoriesPresenter>().AsTransient().Lazy();
        Container.Instantiate<Architecture.Category.CategoriesPanel.CategoriesPresenter>();
        
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
        Container.Bind<IUpdateMatchUseCase>().To<UpdateMatch>().AsTransient().WithArguments(matchGateway);
        //Container.Bind<CorrectionPresenter>().AsTransient().Lazy();
        Container.Instantiate<CorrectionPresenter>();

        Container.Bind<IGetRoundResult>().To<GetRoundResultsUseCase>().AsTransient().WithArguments(matchGateway);
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