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
        private MatchService matchService;

        public UpdateMatchUseCase(MatchService matchService)
        {
            this.matchService = matchService;
        }

        public async Task<bool> Execute(MatchDTO match)
        {
            return await matchService.UpdateMatch(match);
        }
    }
}
