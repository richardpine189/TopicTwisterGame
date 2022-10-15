
using Zenject;

namespace Architecture.Match.ActiveMatchRepository.UseCases
{
    public class ResetActiveMatch
    {
        [Inject] private IActiveMatchRepository _matchRepositoryAction;
    
        public void Execute()
        {
            _matchRepositoryAction.Match.round.CurrentCategories = null;
            _matchRepositoryAction.Match.round.CurrentLetter = null;
            _matchRepositoryAction.Match.round.CurrentAnswers = null;
            _matchRepositoryAction.Match.round.CurrentResults = null;
            _matchRepositoryAction.Match.round.RoundTimeLeft = 60;
        }
    }
}
