

using System.Collections.Generic;

namespace Architecture.Match.Domain.DTO
{
    public class RoundDTO
    {
        public int idMatch;
        public List<string> categories;
        public List<string> answers;
        public List<bool> results;
        public char letter;
        public int timeLeft;
    }
}
