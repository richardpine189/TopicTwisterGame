using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

public interface IGetMatchesInfoUseCase
    {
        Task<List<MatchDTO>> Execute();
    }

