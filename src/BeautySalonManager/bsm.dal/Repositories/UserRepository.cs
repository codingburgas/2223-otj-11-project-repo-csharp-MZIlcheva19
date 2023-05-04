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

        public void AddRow(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
