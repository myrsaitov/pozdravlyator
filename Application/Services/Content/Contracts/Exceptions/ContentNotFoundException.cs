﻿using WidePictBoard.Domain.General.Exceptions;

namespace WidePictBoard.Application.Services.Content.Contracts.Exceptions
{
    public sealed class CommentNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Объявление с таким ID[{0}] не было найдено.";
        
        public CommentNotFoundException(int adId) : base(string.Format(MessageTemplate, adId))
        {
        }
    }
}