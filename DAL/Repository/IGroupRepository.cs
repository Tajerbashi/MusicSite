using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGroupRepository:IDisposable
    {
        bool Add(GrouptType group);
        bool Update(GrouptType group);
        bool Delete(GrouptType group);
        bool Delete(int id);
        void Save();
        IEnumerable<GrouptType> GetAll();
        GrouptType GetById(int id);
        GrouptType GetByName(string Name);
    }
}
