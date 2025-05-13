try
{
    Console.WriteLine("Starting");
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();
    builder.Services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestBody |
        Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseBody |
        Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseHeaders |
        Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponseStatusCode |
        Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestHeaders;
        logging.RequestBodyLogLimit = 4096;
        logging.ResponseBodyLogLimit = 4096;
        logging.CombineLogs = true;
    });
    var app = builder.Build();
    app.UseHttpLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    //app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}