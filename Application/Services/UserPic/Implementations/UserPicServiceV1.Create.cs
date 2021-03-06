using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SL2021.Application.Services.UserPic.Contracts;
using SL2021.Application.Services.UserPic.Contracts.Exceptions;
using SL2021.Application.Services.UserPic.Interfaces;
using Flurl;  // NuGet Flurl.Http
using SL2021.Application.Services.User.Contracts.Exceptions;
using SL2021.Application.Common;
using SL2021.Domain.General.Exceptions;

namespace SL2021.Application.Services.UserPic.Implementations
{
    public sealed partial class UserPicServiceV1 : IUserPicService
    {
        public async Task<Create.Response> Create(
            Create.Request request,
            CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

            if (!ImageExtensions.Contains(Path.GetExtension(request.Image.FileName).ToUpperInvariant()))
            {
                throw new NotAnImageException();
            }


            var userId = await _identityService.GetCurrentUserId(cancellationToken);

            var user = await _userRepository.FindById(userId, cancellationToken);

            var isAdmin = await _identityService.IsInRole(
                userId,
                RoleConstants.AdminRole,
                cancellationToken);

            if (!isAdmin && user.Id != userId)
            {
                throw new NoRightsException("Нет прав для выполнения операции.");
            }

            var fileName = $"{user.UserName}{Path.GetExtension(request.Image.FileName)}";

            if (user.UserPic is null)
            {
                var domainUserPic = new Domain.UserPic()
                {
                    URL = Url.Combine(
                        request.BaseURL,
                        "api/v1/userpics",
                        user.UserName),
                    CreatedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                user.UserPic = domainUserPic;

                await _userPicRepository.Save(
                    domainUserPic,
                    cancellationToken);
            }

            user.UserPic.UpdatedAt = DateTime.UtcNow;
            user.IsDeleted = false;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.Save(
                user,
                cancellationToken);

            var filePath = Path.Combine(@"Images", @"Users", fileName);
            new FileInfo(filePath).Directory?.Create();

            await using var stream = new FileStream(filePath, FileMode.Create);
            await request.Image.CopyToAsync(stream);

            var result = new Create.Response()
            {
                FileName = fileName,
                FileSize = request.Image.Length
            };

            return result;
        }
    }
}