using MainScene.MatchList.Repository;
using Zenject;

    public class MatchIDUseCase : ISaveMatchId, IGetMatchId
    {
        [Inject] private IMatchIdRepository _matchIdRepository;

        public MatchIDUseCase()
        {
            UnityEngine.Debug.Log("Hola Mundo");
        }
        public void Invoke(int matchID)
        {
            _matchIdRepository.SaveMatchId(matchID);
        }

        public int Invoke()
        {
            return _matchIdRepository.GetMatchId();
        }
    }

    public interface IGetMatchId
    {
        public int Invoke();
    }

    public interface ISaveMatchId
    {
        
        public void Invoke(int matchID);
    }
