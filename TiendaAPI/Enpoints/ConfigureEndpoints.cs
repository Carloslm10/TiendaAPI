namespace TiendaAPI.Enpoints
{
    public static class ConfigureEndpoints
    {
        public static void UseEndpointd(this WebApplication app)
        {
            ClienteEndpoints.Add(app);
        }
    }
}
