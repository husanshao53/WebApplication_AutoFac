using AutoFac_Demo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Demo2.IRepository
{
    public interface IUserRepository : IDependency
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Add(User item);
        bool Update(User item);
        bool Delete(int id);
    }
}
