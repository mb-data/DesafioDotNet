namespace ApiDotNetCore.Config
{
    public static class Configuration
    {
        public static string ConnectionString { get; set; } = "Data Source=localhost,1433;Initial Catalog=DB_DESAFIO_DOTNET_CORE;Integrated Security=False;User Id=sa;Password=1q2w3e4r@;MultipleActiveResultSets=True";
    }
}
