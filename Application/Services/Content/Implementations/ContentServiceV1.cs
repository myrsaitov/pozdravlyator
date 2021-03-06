using MapsterMapper;
using SL2021.Application.Identity.Interfaces;
using SL2021.Application.Repositories;
using SL2021.Application.Services.Content.Interfaces;

namespace SL2021.Application.Services.Content.Implementations
{
    public sealed partial class ContentServiceV1 : IContentService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IContentRepository _contentRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public ContentServiceV1(
            IContentRepository contentRepository, 
            ICategoryRepository categoryRepository, 
            ITagRepository tagRepository, 
            IIdentityService identityService, 
            IMapper mapper)
        {
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
            _identityService = identityService;
            _mapper = mapper;
        }
    }
}