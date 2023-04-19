using Application.Data;
using Application.Queries;
using Application.Queries.Handlers;
using Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient<IRequestHandler<FindWalksQuery>, FindWalksHandler>();
builder.Services.AddTransient<IRequestHandler<GetWalksDataQuery>, GetWalksDataHandler>();
builder.Services.AddTransient<IRequestHandler<GetWalksDataByDateQuery>, GetWalksDataByDateHandler>();
builder.Services.AddScoped<TrackRepository>();

builder.Services.AddDbContext<TracksContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(TracksContext).Assembly.FullName)));

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization(); // Add it here
app.MapControllers();
app.Run();

