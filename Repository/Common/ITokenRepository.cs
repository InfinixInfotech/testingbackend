﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface ITokenRepository 
    {
        Task AddTokenToBlacklistAsync(string token, DateTime expiryDate);
        Task<bool> IsTokenBlacklistedAsync(string token);
    }
}
