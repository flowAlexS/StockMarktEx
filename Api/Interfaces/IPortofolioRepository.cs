﻿using Api.Models;

namespace Api.Interfaces
{
    public interface IPortofolioRepository
    {
        Task<List<Stock>> GetUserPortofolio(AppUser user);
    }
}