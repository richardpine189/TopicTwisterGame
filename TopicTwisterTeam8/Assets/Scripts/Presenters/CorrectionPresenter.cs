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
        ICorrectionView _view;

        public CorrectionPresenter(ICorrectionView view)
        {
            _view = view;
        }

        public void GetCorrections(string[] roundCategories, string[] answers)
        {

        }
    }
}
