using Assets.Scripts.Actions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Presenters
{
    public class LetterPresenter
    {
        private ILetterView _view;
        private ILetterGetter _letterGetter;
        private ICategoriesGetter _categoriesGetter;

        public LetterPresenter(ILetterView view, ILetterGetter letterGetter, ICategoriesGetter categoriesGetter)
        {
            _view = view;
            _letterGetter = letterGetter;
            _categoriesGetter = categoriesGetter;
            _view.OnSpinClick += GetLetter;

            GetCategories();
        }

        private void GetCategories()
        {
            string[] categories = _categoriesGetter.GetCategories();

            _view.ShowCategories(categories);
        }

        private void GetLetter()
        {
            char rndLetter = _letterGetter.GetLetter();

            _view.ShowLetter(rndLetter);
        }
    }
}
