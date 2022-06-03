var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

// services.AddControllers()
//             .AddJsonOptions(options =>
//             {
//                 options.JsonSerializerOptions.WriteIndented = true;
//                 options.JsonSerializerOptions.Converters.Add(new CustomJsonConverterForType());
//             });
app.UseAuthentication();
app.UseAuthorization(); // Add it here

app.MapControllers();

app.Run();
