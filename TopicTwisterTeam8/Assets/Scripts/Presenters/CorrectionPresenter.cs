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

        public CorrectionPresenter(ICorrectionView view)
        {
            _view = view;
        }

        public void GetCorrections(string[] roundCategories, string[] answers)
        {
            //TODO
        }

        public void GetCategoriesFromRepository(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
