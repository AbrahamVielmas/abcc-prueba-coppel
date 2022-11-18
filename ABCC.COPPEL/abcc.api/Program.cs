using abcc.repository.Infraestructure.Context;
using abcc.repository.IRepository;
using abcc.repository.Repository;
using abcc.service.IService;
using abcc.service.Service;

var builder = WebApplication.CreateBuilder(args);
var cors = "todos";

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: cors,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//context
builder.Services.AddSingleton<ContextDapper>();

//services
builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IFamiliaRepository, FamiliaRepository>();

//repository
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();
builder.Services.AddScoped<IClasesRepository, ClaseRepository>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IFamiliaService, FamiliaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors);

app.UseAuthorization();

app.MapControllers();

app.Run();
