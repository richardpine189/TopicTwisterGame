using System;
using Architecture.Category.UseCases.GetCorrection;
using Architecture.Match.ActiveMatchRepository.UseCases;
using Architecture.Match.UseCases.GetRoundData;
using Architecture.Match.UseCases.SaveRoundData;
using Architecture.Match.UseCases.UpdateMatch;
using Zenject;

namespace Architecture.Category.CorrectionPanel
{
    class CorrectionPresenter
    {
        private bool[] _results;
        private ICorrectionView _view;
        private IGetCorrections _getCorrections;
        private IUpdateMatchUseCase _updateMatch;

        [Inject]
        private IGetRoundDataUseCase _getRoundDataUseCase;

        [Inject]
        private ISaveRoundDataUseCase _saveRoundDataUseCase;

        [Inject]
        private RemoveActiveMatch _remove;
    
        [Inject]
        private ResetActiveMatch _resetActiveMatch;

        public CorrectionPresenter(ICorrectionView view, IGetCorrections getCorrections, IUpdateMatchUseCase updateMatch)
        {
            _view = view;
            _getCorrections = getCorrections;
            _updateMatch = updateMatch;
            _view.OnEndTurn += EndTurn;
            _view.OnGetCorrections += GetCorrections;
        }

        ~CorrectionPresenter()
        {
            _view.OnEndTurn -= EndTurn;
            _view.OnGetCorrections -= GetCorrections;
        }

        public async void EndTurn()
        {
            try
            {
                bool showEndRoundPanel = await _updateMatch.Invoke();

                if(showEndRoundPanel)
                {
                    _resetActiveMatch.Execute();
                    _view.LoadNextTurn();
                }
                else
                {
                    _remove.Execute();
                    _view.ChangeScene();
                }
            }
            catch(Exception ex)
            {
                _view.ShowErrorPanel(ex.Message);
            }
        }

        public async void GetCorrections()
        {
            var answers = _getRoundDataUseCase.GetCurrentAnswers();

            _results = await _getCorrections.GetCorrections(_getRoundDataUseCase.GetCurrentCategories(), answers, (char)_getRoundDataUseCase.GetCurrentLetter());

            _saveRoundDataUseCase.SaveCurrentResults(_results);

            _view.ShowAnswers(answers);

            _view.ShowCorrections(_results);
        }

    }
}

