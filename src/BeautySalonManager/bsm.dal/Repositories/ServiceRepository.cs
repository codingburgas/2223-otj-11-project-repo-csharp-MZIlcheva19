﻿using bsm.dal.Models;
using bsm.dal.Data;

namespace bsm.dal.Repositories
{
    public class ServiceRepository
    {
        private readonly BeautySalonContext _context;

        public ServiceRepository(BeautySalonContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services;
        }
    }
}