using HearthAnalytics.Model;
using HearthAnalytics.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HearthAnalytics.Repositories.EF.Seed
{
    [SeedOrder(2)]
    public class MatchResultSeed : ISeed
    {
        private readonly DbSet<MatchResult> _databaseSet;

        public MatchResultSeed(DbSet<MatchResult> dbset)
        {
            _databaseSet = dbset;
        }

        public void Apply()
        {   
            AddMatchResult("Defeat", MatchResultEnum.Defeat);
            AddMatchResult("Draw", MatchResultEnum.Draw);
            AddMatchResult("Win", MatchResultEnum.Win);
        }

        private void AddMatchResult(string name, MatchResultEnum matchResultEnum)
        {            
            var matchResult = _databaseSet.FirstOrDefault(x => x.MatchResultEnum == matchResultEnum);

            if (matchResult == null)
            {
                matchResult = new MatchResult
                {
                    Name = name,
                    MatchResultEnum = matchResultEnum
                };

                _databaseSet.Add(matchResult);
            }
        }
    }
}
