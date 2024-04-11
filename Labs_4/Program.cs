using Labs_4.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Database>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (Database dataBase) => Results.Ok(dataBase.GetAnimals()));

app.MapGet("/animals/{id}", (Database database, int id) =>
{
    var animal = database.GetAnimal(id);
    return animal == null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/animals", (Database database, Animal animal) =>
{
    database.AddAnimal(animal);
    return Results.Created();
});

app.MapPut("/animals{id}", (Database database, int id, Animal futureAnimal) =>
{
    var currentAnimal = database.GetAnimal(id);
    if (currentAnimal == null) return Results.NotFound();
    database.EditAnimal(currentAnimal, futureAnimal);
    return Results.NoContent();
});

app.MapDelete("/animals{id}", (Database database, int id) =>
{
    var animal = database.GetAnimal(id);
    if (animal == null) return Results.NotFound();
    database.DeleteAnimal(animal);
    return Results.NoContent();
});

app.MapGet("/appointments/{id}", (Database database, int id) => 
    database.GetAnimal(id) == null ? Results.NotFound() : Results.Ok(database.GetAppointments(id)));

app.MapPost("/appointments", (Database database, Appointment appointment) =>
{
    database.AddAppointment(appointment);
    return Results.Created();
});

app.Run();