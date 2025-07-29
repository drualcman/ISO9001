﻿using ISO9001.NonConformities.Repositories.Entities;

namespace ISO9001.NonConformities.Repositories.Interfaces
{
    public interface IQueryableNonConformityDataContext
    {
        IQueryable<NonConformityReadModel> NonConformities { get; }

        IQueryable<NonConformityDetailReadModel> NonConformityDetails { get; }

        Task<IEnumerable<NonConformityReadModel>> ToListAsync(
            IQueryable<NonConformityReadModel> queryable);

        Task<IEnumerable<NonConformityDetailReadModel>> ToListAsync(
            IQueryable<NonConformityDetailReadModel> queryable);
    }
}

