﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using WidePictBoard.Application.Identity.Interfaces;
using WidePictBoard.Application.Repositories;
using WidePictBoard.Application.Services.PagedBase.Contracts;
using WidePictBoard.Application.Services.PagedBase.Implementations;
using WidePictBoard.Application.Services.Tag.Interfaces;
using WidePictBoard.Application.Services.Tag.Contracts;

namespace WidePictBoard.Application.Services.Tag.Implementations
{
    public sealed class TagServiceV1 : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private PagedBase<Paged.Response<GetById.Response>, GetById.Response, Paged.Request, Domain.Tag> _paged;

        public TagServiceV1(ITagRepository repository, IIdentityService identityService, IMapper mapper)
        {
            _repository = repository;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<Create.Response> Create(Create.Request request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Domain.Tag>(request);
            tag.CreatedAt = DateTime.UtcNow;

            await _repository.Save(tag, cancellationToken);
            return new Create.Response
            {
                Id = tag.Id
            };
        }

        public async Task<Paged.Response<GetById.Response>> GetPaged(Paged.Request request, CancellationToken cancellationToken)
        {
            _paged = new PagedBase<Paged.Response<GetById.Response>, GetById.Response, Paged.Request, Domain.Tag>();
            return await _paged.GetPaged(request, _repository, _mapper, cancellationToken);
        }
    }
}