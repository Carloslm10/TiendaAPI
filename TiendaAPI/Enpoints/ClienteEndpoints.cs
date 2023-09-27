namespace TiendaAPI.Enpoints
{
    public static class ClienteEndpoints
    {
        public static async void Add(this WebApplication app)
        {
            await app.RunAsync();
        }
    }
}
