﻿namespace WidePictBoard.Application.Services.Comment.Contracts
{
    public static class Create
    {

        public sealed class Request
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        public sealed class Response
        {
            public int Id { get; set; }
        }
    }
}