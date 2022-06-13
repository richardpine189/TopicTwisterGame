using Assets.Scripts.Interfaces;
using Assets.Scripts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Actions
{
    public class SaveMatch
    {
        IMatchRepository _matchRepository;

        public SaveMatch()
        {
            _matchRepository = ServiceLocator.Instance.GetService<IMatchRepository>();
        }

        public void Save(Match match)
        {
            if(match.id == null)
            {
                match.id = _matchRepository.GetNewId();
            }

            _matchRepository.SaveMatch(match);
        }
    }
}
