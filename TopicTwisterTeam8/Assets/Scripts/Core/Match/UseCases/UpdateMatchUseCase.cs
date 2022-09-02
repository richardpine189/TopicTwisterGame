using Assets.Scripts.Core.Match.Interface;
using Core.Match.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Core.Match.UseCases
{
    class UpdateMatchUseCase : IUpdateMatchUseCase
    {
        private MatchService _matchService;

        public UpdateMatchUseCase(MatchService matchService)
        {
            this._matchService = matchService;
        }

        public async Task<bool> Execute(global::Match match)
        {
            return await _matchService.UpdateMatch(match);
        }
    }
}
