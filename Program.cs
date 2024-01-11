using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProfileService.Data;
using ProfileService.Data.Repository.Implementation;
using ProfileService.Data.Repository.Interface;
using ProfileService.Entities;
using ProfileService.Profiles;
using ProfileService.Services.Implementation;
using ProfileService.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<InvestDataContext>()
    .AddDefaultTokenProviders();




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InvestDataContext>( options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Investa"))
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

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
