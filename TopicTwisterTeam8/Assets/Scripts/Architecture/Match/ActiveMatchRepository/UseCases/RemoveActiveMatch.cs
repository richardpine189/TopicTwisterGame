using Zenject;

namespace Architecture.Match.ActiveMatchRepository.UseCases
{
    public class RemoveActiveMatch
    {
        [Inject] private IActiveMatchRepository _matchRepositoryAction;
        public void Execute()
        {
            _matchRepositoryAction.Match = null;
        }
    }
}
