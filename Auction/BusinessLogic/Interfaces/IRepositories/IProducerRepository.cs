﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.Models;

namespace BusinessLogic.Interfaces.IRepositories
{
    public interface IProducerRepository : IRepository<Producer>
    {
        Producer Get(int id);
    }
}
