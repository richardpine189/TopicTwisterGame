using Architecture.Match.ActiveMatchRepository;
using Architecture.Match.Domain.DTO;
using Zenject;

namespace Architecture.Match.UseCases.SaveMatchData
{
    class SaveMatchData : ISaveMatchDataUseCase
    {
        [Inject] IActiveMatchRepository _matchRepositoryUseCase;
        public void SaveIDMatch(int matchId)
        {
            _matchRepositoryUseCase.Match.idMatch = matchId;
        }

        public void SavePlayerName(string challenger, string opponent)
        {
            _matchRepositoryUseCase.Match.challengerName = challenger;
            _matchRepositoryUseCase.Match.opponentName = opponent;
        }

        public void SaveCurrentRound(int currentRound)
        {
            _matchRepositoryUseCase.Match.currentRound = currentRound;
        }

        public void SetTurnState(bool isChallengerTurn)
        {
            _matchRepositoryUseCase.Match.isChallengerTurn = isChallengerTurn;
        }
        public void SetMatchState(bool isMatchFinished)
        {
            _matchRepositoryUseCase.Match.isMatchFinished = isMatchFinished;
        }

        public void SaveNewMatch(MatchDTO matchDto)
        {
            _matchRepositoryUseCase.Match = new Domain.Match();
            _matchRepositoryUseCase.Match.idMatch = matchDto.idMatch;
            _matchRepositoryUseCase.Match.challengerName = matchDto.challengerName;
            _matchRepositoryUseCase.Match.opponentName = matchDto.opponentName;
            _matchRepositoryUseCase.Match.currentRound = matchDto.currentRound;
            _matchRepositoryUseCase.Match.isChallengerTurn = matchDto.isChallengerTurn;
            _matchRepositoryUseCase.Match.isMatchFinished = matchDto.isMatchFinished;
        }

        public void SaveActiveMatch(ActiveMatchDTO activeMatch, int matchId)
        {
            _matchRepositoryUseCase.Match = new Domain.Match();
            _matchRepositoryUseCase.Match.idMatch = matchId;
            _matchRepositoryUseCase.Match.challengerName = activeMatch.challengerName;
            _matchRepositoryUseCase.Match.opponentName = activeMatch.opponentName;
            _matchRepositoryUseCase.Match.currentRound = activeMatch.currentRound;
            _matchRepositoryUseCase.Match.round.CurrentCategories = activeMatch.currentCategories;
            _matchRepositoryUseCase.Match.round.CurrentLetter = activeMatch.currentLetter;
            _matchRepositoryUseCase.Match.round.RoundTimeLeft = activeMatch.currentTime;
        }
    }
}