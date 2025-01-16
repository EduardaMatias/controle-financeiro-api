using controle_financeiro_api.Repository;
using controle_financeiro_api.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddScoped<IUsuarioRepository>(provider =>
    new UsuarioRepository(connectionString)
);

builder.Services.AddScoped<IDespesaRepository>(provider =>
    new DespesaRepository(connectionString)
);

builder.Services.AddScoped<IReceitaRepository>(provider =>
    new ReceitaRepository(connectionString)
);

builder.Services.AddScoped<IHistoricoRepository>(provider =>
    new HistoricoRepository(connectionString)
);

builder.Services.AddScoped<IPlanejamentoRepository>(provider =>
    new PlanejamentoRepository(connectionString)
);

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IReceitaService, ReceitaService>();
builder.Services.AddScoped<IHistoricoService, HistoricoService>();
builder.Services.AddScoped<IPlanejamentoService, PlanejamentoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
