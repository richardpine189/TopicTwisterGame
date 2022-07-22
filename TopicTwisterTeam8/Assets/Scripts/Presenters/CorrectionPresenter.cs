using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Presenters
{
    class CorrectionPresenter
    {
        private bool[] results;
        private ICorrectionView _view;
        private ICategoriesRepository _categoryRepository;
        private IMatchAction _matchActions;

        public CorrectionPresenter(ICorrectionView view, ICategoriesRepository categoryRepository)
        {
            _view = view;
            _categoryRepository = categoryRepository;
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
            round.challengerResult = results;

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

        public bool[] GetCorrections(string[] roundCategories, string[] answers, char letter)
        {
            results = new bool[5];

            List<Category> categories = _categoryRepository.GetCategories();

            for(int i = 0; i< 5; i++)
            {
                results[i] = categories.FirstOrDefault(x => x.Name == roundCategories[i]).ExisistInCategory(answers[i], letter);
            }

            return results;
        }
    }
}
