namespace Catalog.API
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string CatalogApiConnection { get; set; }
    }
}
