var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });

}
string dbConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.UseCors();
    app.Run();
}
