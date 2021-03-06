namespace SL2021.Application.Services.User.Contracts
{
    public static class Register
    {
        public sealed class Request
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
        }

        public sealed class Response
        {
            public string UserId { get; set; }
        }
    }
}