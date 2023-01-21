using DAL.ViewModels;
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
        bool Add(Group group);
        bool Update(Group group);
        bool Delete(Group group);
        bool Delete(int id);
        void Save();
        IEnumerable<Group> GetAll(); 
        IEnumerable<ViewModelGroups> GetAllGroupToShow(); 
        Group GetById(int id);
        Group GetByName(string Name);
    }
}
