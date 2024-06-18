namespace RealEstateApi.Helpers
{
    public class SecretsHelper
    {
        public static string GetDatabaseConnectionString(WebApplicationBuilder builder)
        {
            var host = builder.Configuration["ConnectionStrings:AppCasasDB:Host"];
            var port = builder.Configuration["ConnectionStrings:AppCasasDB:Port"];
            var dataBase = builder.Configuration["ConnectionStrings:AppCasasDB:Database"];
            var userName = builder.Configuration["ConnectionStrings:AppCasasDB:Username"];
            var password = builder.Configuration["ConnectionStrings:AppCasasDB:Password"];

            return $"Server={host};Port={port};Database={dataBase};Username={userName};Password={password};";
        }
    }
}
