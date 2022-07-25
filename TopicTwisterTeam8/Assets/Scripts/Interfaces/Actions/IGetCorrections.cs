using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGetCorrections
{
    Task<bool[]> GetCorrections(string[] roundCategories, string[] answers, char letter);
}