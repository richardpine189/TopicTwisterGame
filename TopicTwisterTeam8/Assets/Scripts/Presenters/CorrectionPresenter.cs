using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

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
