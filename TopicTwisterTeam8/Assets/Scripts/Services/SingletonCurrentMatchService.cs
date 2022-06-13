﻿using Assets.Scripts.Interfaces;
using Assets.Scripts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Services
{
    public class SingletonCurrentMatchService : ICurrentMatchService
    {
        public Match GetActiveMatch()
        {
            return CurrentMatchSingleton.Get();
        }

        public void SetActiveMatch(Match match)
        {
            CurrentMatchSingleton.Set(match);
        }
    }
}
