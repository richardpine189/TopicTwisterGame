using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.DTO;

public interface IGetMatchesGateway
{
    Task<List<MatchDTO>> GetMatchesDTOByName(string userName);
}
