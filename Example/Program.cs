var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// đăng kí service vào, để ASP.Net inject nó vào BookController
builder.Services.AddScoped<IBookService, BookService>();

// đăng kí các filter
builder.Services.AddScoped<MyAuthFilter>();
builder.Services.AddScoped<MyResourceFilter>();
builder.Services.AddScoped<MyActionFilter>();
builder.Services.AddScoped<MyExceptionFilter>();
builder.Services.AddScoped<MyResultFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();


app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware: Request vào");
    await next();
    Console.WriteLine("Middleware: Response ra");
});

app.MapControllers();

app.Run();
