using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Rira.BackEnd.SeniorTask.RepositoryEFImpl;
using Rira.BackEnd.SeniorTask.gRPC.Services;
using Rira.BackEnd.SeniorTask.gRPC.WebApplicationBuilderServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.RepositoryServices();
builder.LogicServices();

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
}));

var app = builder.Build();

app.UseCors();

app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.MapGrpcService<PersonGrpcServcie>().EnableGrpcWeb().RequireCors("AllowAll");

app.MapGet("/", () => "This gRPC service is gRPC-Web enabled, CORS enabled, and is callable from browser apps using the gRPC-Web protocol");

app.Run();