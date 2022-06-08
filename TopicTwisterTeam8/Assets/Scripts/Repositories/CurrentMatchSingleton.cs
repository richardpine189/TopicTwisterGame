﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTwister.Assets.Scripts.Models;

namespace Assets.Scripts.Repositories
{
    public sealed class CurrentMatchSingleton
    {
        private CurrentMatchSingleton() { }

        private static Match _currentMatch;

        public static Match Get()
        {
            return _currentMatch;
        }

        public static void Set(Match match)
        {
            _currentMatch = match;
        }
    }
}