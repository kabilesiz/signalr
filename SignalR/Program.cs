using SignalR.Hubs;
using SignalR.SignalRBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ChatBusiness>();

builder.Services.AddCors(x => x.AddDefaultPolicy(policy =>

    policy.AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(x => true)));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.UseAuthorization();



app.Run();