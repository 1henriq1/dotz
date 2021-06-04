﻿using Dotz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Domain.Interfaces
{
    public interface IProductService
    {
        Task TradeAsync(Guid productId);
        Task<IEnumerable<Product>> GetAsync();
    }
}
