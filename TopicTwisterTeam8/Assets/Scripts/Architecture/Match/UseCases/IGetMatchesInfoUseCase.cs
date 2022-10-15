using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Models.DTO;

public interface IGetMatchesInfoUseCase
    {
        Task<List<MatchDTO>> Execute();
    }

