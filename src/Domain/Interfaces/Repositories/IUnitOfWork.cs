﻿namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
