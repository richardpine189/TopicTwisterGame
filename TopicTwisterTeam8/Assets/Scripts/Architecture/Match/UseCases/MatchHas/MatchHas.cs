using Architecture.Match.ActiveMatchRepository;
using Zenject;

namespace Architecture.Match.UseCases.MatchHas
{
    class MatchHas : IMatchHasUseCase
    {
        [Inject]
        private IActiveMatchRepository _activeMatchRepository;
    
        public bool CurrentCategories()
        {
            return _activeMatchRepository.Match.round.CurrentCategories != null;
        }
    }
}
