using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IPersonelDal, EfPersonelDal>();
builder.Services.AddScoped<IPersonelService, PersonelManager>();

builder.Services.AddScoped<IAssignmentDal, EfAssignmentDal>();
builder.Services.AddScoped<IAssignmentService, AssignmentManager>();

builder.Services.AddScoped<IRepairRequestDal, EfRepairRequestDal>();
builder.Services.AddScoped<IRepairRequestService, RepairRequestManager>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("EnvanterApiCors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();
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


app.UseHttpsRedirection();

app.UseCors("EnvanterApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
