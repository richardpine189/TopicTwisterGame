using Assets.Scripts.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Presenters
{
    public class CorrectionPresenter
    {
        ICategoriesRepository _categoryRepository;
        ICorrectionView _view;

        public CorrectionPresenter(ICorrectionView view, ICategoriesRepository categoryRepository)
        {
            _view = view;
            _categoryRepository = categoryRepository;
            _view.OnNextTurnClick += EndTurn;
        }

        public void EndTurn(string[] roundCategories, string[] answers, char letter)
        {
            Match match = new Match();

            match.challenger = new User(1, "Ricardo");
            match.opponent = new User(2, "Theo");
            match.rounds[0] = new Round() {
                assignedCategoryNames = roundCategories,
                letter = letter,
                challengerAnswers = answers
            };

            SaveMatch action = new SaveMatch();
            action.Save(match);
        }

        public bool[] GetCorrections(string[] roundCategories, string[] answers, char letter)
        {
            bool[] result = new bool[5];

            List<Category> categories = _categoryRepository.GetCategories();

            for(int i = 0; i < 5; i++)
            {
                result[i] = categories.FirstOrDefault(x => x.Name == roundCategories[i]).ExisistInCategory(answers[i], letter);
            }

            return result;
        }
    }
}