using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


class CorrectionPresenter
    {
        private CorrectionStatus[] _results;
        private ICorrectionView _view;
        private ICategoriesGetter _categoriesGetter;
        private IMatchAction _matchActions;

        public CorrectionPresenter(ICorrectionView view, ICategoriesGetter categoryService)
        {
            _view = view;
            _categoriesGetter = categoryService;
            _matchActions = new HardcodedMatchActions();
            //_view.OnNextTurnClick += EndTurn;
        }

        public void EndTurn(string[] roundCategories, string[] answers, char letter)
        {
            // This assaingment should be inside a method of the actions object
            Match match = _matchActions.GetMatch();
            int currentRoundIndex = _matchActions.GetCurrentRoundIndex();

            Round round = _matchActions.GetCurrentRound() != null ? _matchActions.GetCurrentRound() : new Round();

            round.assignedCategoryNames = roundCategories;
            round.letter = letter;
            round.challengerAnswers = answers;
            round.challengerResult = _results;

            if (round.opponentAnswers != null)
            {
                round.roundFinished = true;
            }

            match.rounds[currentRoundIndex] = round;

            SaveMatch action = new SaveMatch();
            action.Save(match);

            if (round.roundFinished)
            {
                _view.LoadNextTurn();
            }
            else
            {
                _view.ChangeScene();
            }
        }

        public async Task<CorrectionStatus[]> GetCorrections(string[] roundCategories, string[] answers, char letter)
        {
            _results = new CorrectionStatus[5];

            var categories = await _categoriesGetter.GetCategories(5); //HARDCODED AMOUNT
            //TODO
            return _results;
        }
    }

