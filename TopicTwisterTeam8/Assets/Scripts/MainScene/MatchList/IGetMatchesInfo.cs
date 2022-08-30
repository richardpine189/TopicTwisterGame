using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGetMatchesInfo
    {
        Task<List<MatchDTO>> Execute();
    }

