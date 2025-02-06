using Microsoft.EntityFrameworkCore;
using Maintainace_system_BACKEND.Models;
using Maintainace_system_BACKEND.Services;
using Maintainace_system_BACKEND.Interface;
using AutoMapper;
using Maintainace_system_BACKEND.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Pievieno MVC kontrolierus
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Reģistrē AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Konfigurē datu bāzes kontekstu ar MySQL savienojumu
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 4, 3)) // MySQL versija
    )
);

// Reģistrē pakalpojumus (Services) atkarību injekcijai
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeIdentService, EmployeeIdentService>();
builder.Services.AddScoped<IFilesService, FilesService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<IEmployeeRolesService, EmployeeRolesService>();

// CORS Konfigurācija
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") // Atļaut tikai Angular frontend savienojumu
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Attīstības vidē aktivizē Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

// Middleware konfigurācija
app.UseRouting();
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.MapControllers();

// Norāda API darbības portu
app.Urls.Add("http://*:5086");

// Palaiž API lietotni
app.Run();
