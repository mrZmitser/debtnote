using DebtNote.Database;
using DebtNote.Models;
using DebtNote.Repositories.Implimentations;
using DebtNote.Repositories.Interfaces;
using DebtNote.Services.Interfaces;
using DebtNote.Services.Implimentations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));//
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<IUserRepository<User>, UserRepository<User>>();
builder.Services.AddTransient<IPaymentRepository<Payment>, PaymentRepository<Payment>>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapGet("/testpage", () => "new page");

app.Run();
