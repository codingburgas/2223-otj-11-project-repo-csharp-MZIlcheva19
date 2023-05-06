using bsm.dal.Data;
using bsm.dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsm.dal.Repositories
{
    public class UserRepository
    {
        private readonly BeautySalonContext _context;

        public UserRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public User? GetUserByUsername(string username)
        {
            User? user = _context
                .Users
                .FirstOrDefault(u => u.Username == username);

            return user;
        }

        public void AddRow(User user)
        {
            if(user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public void DeleteRow(User user)
        {
            if(user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
