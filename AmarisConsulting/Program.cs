using AmarisConsulting.Models;
using AmarisConsulting.Repositorios;
using AmarisConsulting.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AmarisConsultingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);

builder.Services.AddScoped<ITurnosRepository, TurnosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<ISucursalesRepository, SucursalesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
            builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
        );
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
