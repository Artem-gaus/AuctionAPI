﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLogic.DTO;
using BusinessLogic.Interfaces.IServices;

namespace BusinessLogic.Interfaces
{
    public interface ICustomerService : IService<CustomerDTO>
    {
    }
}
