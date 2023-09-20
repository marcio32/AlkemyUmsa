﻿using AlkemyUmsa.DataAccess.Repositories;

namespace AlkemyUmsa.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public RoleRepository RoleRepository { get; }
        public AccountRepository AccountRepository { get; }
        Task<int> Complete();
     
    }
}
