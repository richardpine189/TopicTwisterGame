namespace Architecture.Match.ActiveMatchRepository
{
    public class ActiveMatchRepositoryInMemory : IActiveMatchRepository
    {
        private Domain.Match match;

        public Domain.Match Match {
            get
            {
                return match;
            }
            set
            {
                match = value;
            }
        }

    }
}
