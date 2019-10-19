namespace GreenHouse.Core.Request.login
{
    public class LoginResponse : IResponse
    {
        public bool Success { get; set; }
     
        public string Error { get; set; }
    }
}