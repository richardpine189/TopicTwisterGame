using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    public interface IMatchAction
    {
        void CreateMatch();

        void FindPlayers();

        string GetPlayerName();

        string GetOpponentName();

        Match GetMatch();

        Round GetCurrentRound();

        public bool CheckActiveMatch();

        bool IsChallengerTurn();
    }

