using AutoFac_Demo2.IRepository;
using AutoFac_Demo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFac_Demo2.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new List<User>();
        public UserRepository()
        {
            Add(new User { Id = 1, Name = "hyh" });
            Add(new User { Id = 2, Name = "hyg" });
            Add(new User { Id = 3, Name = "hyr" });
        }

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User Get(int id)
        {
            return Users.Find(p => p.Id == id);
        }

        public User Add(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Users.Add(item);
            return item;
        }

        public bool Update(User item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = Users.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            Users.RemoveAt(index);
            Users.Add(item);
            return true;
        }

        public bool Delete(int id)
        {
            Users.RemoveAll(p => p.Id == id);
            return true;
        }
    }
}
