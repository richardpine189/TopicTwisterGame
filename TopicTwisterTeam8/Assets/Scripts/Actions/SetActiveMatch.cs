
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public class SetActiveMatch
    {
        IMatchRepository _matchRepository;
        ICurrentMatchService _matchService;

        public SetActiveMatch()
        {
            _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
            _matchService = new SingletonCurrentMatchService();
        }

        public void Execute(int id)
        {
            List<Match> matches = _matchRepository.GetMatches();
            Match activeMatch = matches.Find(m => m.id == id);
            _matchService.SetActiveMatch(activeMatch);
        }

        public void RemoveActiveMatch()
        {
            _matchService.SetActiveMatch(null);
        }
    }

