using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

public interface IGetMatchesService
{
    Task<List<MatchDTO>> GetMatchesDTOByName(string userName);
}
