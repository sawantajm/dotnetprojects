namespace mango.Web.Services.IServices
{
    public interface ITockenProvider
    {
        void SetTocken(string tocken);
        string? GetTocken();
        void ClearTocken();
    }
}
