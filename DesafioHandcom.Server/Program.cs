using Blazored.LocalStorage;
using DesafioHandcom;
using DesafioHandcom.Client;
using DesafioHandcom.Configuration;
using DesafioHandcom.Data;
using DesafioHandcom.Server.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adicionando Banco de dados InMemory
builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("DesafioHandcom"));

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	var dbContext = serviceProvider.GetRequiredService<AppDbContext>();

	// Adicione dados mock aqui
	dbContext.Users.Add(new UserModel { Id = 1, Name = "Exemplo", Email = "exemplo@example.com", Password = "Teste", CreatedAt = DateTime.Now });

	// Salva as alterações no banco de dados
	dbContext.SaveChanges();
}

builder.Services.AddTransient<JwtService>();

builder.Services.AddScoped<CustomAuthProvider>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
builder.Services.AddBlazoredLocalStorage();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseCors(cors => cors
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
