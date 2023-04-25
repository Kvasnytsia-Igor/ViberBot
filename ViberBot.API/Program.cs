using Application.Data;
using Application.Requsts;
using Application.Requsts.Handlers;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ViberBot.API.Validators;
using ViberBot.Application.Requests;
using ViberBot.Application.Requests.Handlers;
using ViberBot.Application.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IRequestHandler<WalksListRequest>, WalksListHandler>();
builder.Services.AddScoped<IRequestHandler<GeneralWalksDataRequest>, GeneralWalksDataHandler>();
builder.Services.AddScoped<IRequestHandler<InvalidInputRequest>, InvalidInputHandler>();
builder.Services.AddScoped<TrackService>();
builder.Services.AddScoped<MessagesService>();
builder.Services.AddScoped<InputValidator>();

builder.Services.AddDbContext<TracksContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(TracksContext).Assembly.FullName)));

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();
app.MapControllers();
app.Run();

