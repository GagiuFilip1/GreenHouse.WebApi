namespace GreenHouse.Core.Request
{
    public interface IResponse
    {
        bool Success { get; set; }
        string Error { get; set; }
    }
}