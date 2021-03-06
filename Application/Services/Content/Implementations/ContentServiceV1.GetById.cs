using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SL2021.Application.Services.Content.Contracts;
using SL2021.Application.Services.Content.Contracts.Exceptions;
using SL2021.Application.Services.Content.Interfaces;

namespace SL2021.Application.Services.Content.Implementations
{
    public sealed partial class ContentServiceV1 : IContentService
    {
        public async Task<GetById.Response> GetById(
            GetById.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var content = await _contentRepository.FindByIdWithUserAndCategoryAndTags(
                request.Id,
                cancellationToken);

            if (content == null)
            {
                throw new ContentNotFoundException(request.Id);
            }

            var response = _mapper.Map<GetById.Response>(content);

            return response;
        }
    }
}