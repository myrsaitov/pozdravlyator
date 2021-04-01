﻿using System;
using System.Linq.Expressions;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;
using WidePictBoard.Application.Repositories;
using WidePictBoard.Application.Services.PagedBase.Contracts;
using WidePictBoard.Domain.General;

namespace WidePictBoard.Application.Services.PagedBase.Interfaces
{
    public interface IPagedBase<TPagedResponse, TSingleResponce, TPagedRequest, TEntity>
        where TEntity : Entity<int>
    {
        Task<Paged.Response<TSingleResponce>> GetPaged(TPagedRequest request, IRepository<TEntity, int> repository, IMapper mapper, CancellationToken cancellationToken);
        Task<Paged.Response<TSingleResponce>> GetPaged(Expression<Func<TEntity, bool>> predicate, TPagedRequest request, IRepository<TEntity, int> repository, IMapper mapper, CancellationToken cancellationToken);
    }
}