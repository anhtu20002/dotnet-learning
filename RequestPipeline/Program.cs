using RequestPipeline.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.UseMiddleware<FirstMiddleWare>();
app.UseMiddleware<ValidateToken>();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"{context.Items["FirstMsg"]}<br>");
    await context.Response.WriteAsync($"{context.Items["TokenMsg"]}<br>");
    await context.Response.WriteAsync($"{context.Items["TokenError"]}<br>");
    await context.Response.WriteAsync($"{context.Items["FirstMiddlsExitMsg"]}<br>");
    await context.Response.WriteAsync($"{context.Items["TokenExitMsg"]}<br>");
    await context.Response.WriteAsync("đây là middleware cuối cùng, không có _next <br>");
});

//app.MapControllers();

app.Run();