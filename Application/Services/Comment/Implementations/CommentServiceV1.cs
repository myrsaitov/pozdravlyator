﻿using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WidePictBoard.Application.Common;
using WidePictBoard.Application.Identity.Interfaces;
using WidePictBoard.Application.Repositories;
using WidePictBoard.Application.Services.Comment.Contracts;
using WidePictBoard.Application.Services.Comment.Contracts.Exceptions;
using WidePictBoard.Application.Services.Comment.Interfaces;
using WidePictBoard.Domain.General.Exceptions;
using WidePictBoard.Application.Services.PagedBase.Contracts;
using WidePictBoard.Application.Services.PagedBase.Implementations;
using WidePictBoard.Application.Services.Content.Contracts.Exceptions;

namespace WidePictBoard.Application.Services.Comment.Implementations
{
    public sealed class CommentServiceV1 : ICommentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private PagedBase<GetPaged.Response, GetPaged.Response.SingleResponse, GetPaged.Request, Domain.Comment> _paged;

        public CommentServiceV1(ICommentRepository commentRepository, IContentRepository contentRepository, IIdentityService identityService, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _commentRepository = commentRepository;
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<Create.Response> Create(Create.Request request, CancellationToken cancellationToken)
        {
            string userId = await _identityService.GetCurrentUserId(cancellationToken);

            var comment = _mapper.Map<Domain.Comment>(request); 
            comment.IsDeleted = false;
            comment.OwnerId = userId;
            comment.CreatedAt = DateTime.UtcNow;

            var contentRequest = new Content.Contracts.GetById.Request()
            {
                Id = comment.ContentId
            };

            var content = await _contentRepository.FindByIdWithUserInclude(contentRequest.Id, cancellationToken);
            if (content == null)
            {
                throw new ContentNotFoundException(contentRequest.Id);
            };

            content.Comments = new List<Domain.Comment>()
            {
                comment
            };

            await _contentRepository.Save(content, cancellationToken);

            await _commentRepository.Save(comment, cancellationToken);

            return new Create.Response
            {
                Id = comment.Id
            };
        }
        
        public async Task<Update.Response> Update(Update.Request request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.FindByIdWithUserInclude(request.Id, cancellationToken);
            if (comment == null)
            {
                throw new CommentNotFoundException(request.Id);
            }

            var userId = await _identityService.GetCurrentUserId(cancellationToken);
            var isAdmin = await _identityService.IsInRole(userId, RoleConstants.AdminRole, cancellationToken);

            if (!isAdmin && comment.OwnerId != userId)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
            }

            comment.Body = request.Body;
            comment.IsDeleted = false;
            comment.UpdatedAt = DateTime.UtcNow;
            await _commentRepository.Save(comment, cancellationToken);

            return new Update.Response
            {
                Id = comment.Id
            };
        }

        public async Task Delete(Delete.Request request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.FindByIdWithUserInclude(request.Id, cancellationToken);
            if (comment == null)
            {
                throw new CommentNotFoundException(request.Id);
            }

            var userId = await _identityService.GetCurrentUserId(cancellationToken);
            var isAdmin = await _identityService.IsInRole(userId, RoleConstants.AdminRole, cancellationToken);

            if (!isAdmin && comment.OwnerId != userId)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
            }

            comment.IsDeleted = true;
            comment.UpdatedAt = DateTime.UtcNow;
            await _commentRepository.Save(comment, cancellationToken);
        }

        public async Task Restore(Restore.Request request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.FindByIdWithUserInclude(request.Id, cancellationToken);
            if (comment == null)
            {
                throw new CommentNotFoundException(request.Id);
            }

            var userId = await _identityService.GetCurrentUserId(cancellationToken);
            var isAdmin = await _identityService.IsInRole(userId, RoleConstants.AdminRole, cancellationToken);

            if (!isAdmin && comment.OwnerId != userId)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
            }

            comment.IsDeleted = false;
            comment.UpdatedAt = DateTime.UtcNow;
            await _commentRepository.Save(comment, cancellationToken);
        }

        public async Task<Paged.Response<GetPaged.Response.SingleResponse>> GetPaged(GetPaged.Request request, CancellationToken cancellationToken)
        {
            _paged = new PagedBase<GetPaged.Response, GetPaged.Response.SingleResponse, GetPaged.Request, Domain.Comment>();
            return await _paged.GetPaged(
                a=>a.ContentId==request.ContentId,
                request,
                _commentRepository,
                _mapper,
                cancellationToken);
        }
    }
}