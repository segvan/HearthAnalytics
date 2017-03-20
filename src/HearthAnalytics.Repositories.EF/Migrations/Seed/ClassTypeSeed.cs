using HearthAnalytics.Model;
using HearthAnalytics.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HearthAnalytics.Repositories.EF.Seed
{
    [SeedOrder(1)]
    public class ClassTypeSeed : ISeed
    {
        private readonly DbSet<ClassType> _databaseSet;

        public ClassTypeSeed(DbSet<ClassType> dbset)
        {
            _databaseSet = dbset;
        }

        public void Apply()
        {   
            AddClassType("Druid", ClassTypeEnum.Druid);
            AddClassType("Hunter", ClassTypeEnum.Hunter);
            AddClassType("Mage", ClassTypeEnum.Mage);
            AddClassType("Paladin", ClassTypeEnum.Paladin);
            AddClassType("Priest", ClassTypeEnum.Priest);
            AddClassType("Rogue", ClassTypeEnum.Rogue);
            AddClassType("Shaman", ClassTypeEnum.Shaman);
            AddClassType("Warlock", ClassTypeEnum.Warlock);
            AddClassType("Warrior", ClassTypeEnum.Warrior);
        }

        private void AddClassType(string name, ClassTypeEnum classTypeEnum)
        {            
            var classType = _databaseSet.FirstOrDefault(x => x.ClassTypeEnum == classTypeEnum);

            if (classType == null)
            {
                classType = new ClassType
                {
                    Name = name,
                    ClassTypeEnum = classTypeEnum
                };

                _databaseSet.Add(classType);
            }
        }
    }
}
