
using System.Collections.Generic;

namespace SL2021.Application.Services.Contracts
{
    public static class Paged
    {
        public class Request
        {
            public int Page { get; set; } = 0;
            public int PageSize { get; set; } = 10;
        }

        public class Response<T>
        {
            public int Total { get; set; }
            public int Limit { get; set; }
            public int Offset { get; set; }
            
            public IEnumerable<T> Items { get; set; }
        } 
    }
}