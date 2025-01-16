var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5183/");
app.Urls.Add("http://*:5183");


List<Teacher> teachers = [
    new(){Name = "Micke"},
    new(){Name = "Hugo"},
    new(){Name = "martin"},
    new(){Name = "Hugo2"},
];


app.MapGet("/", () => "Hello World");
app.MapGet("/orb", () => "Hi, orb!");
app.MapGet("/hugo", () => "Hej hugo");
app.MapGet("Maxi", () => "Maxi är upptagen med tyrone, lämna en snus så återkommer jag efter jag blivit full");
app.MapGet("/micke", GetMicke);
app.MapPost("/Post", SayHello);
app.MapGet("teachers", GetTeachers);
app.MapGet("/teachers/{n}", GetTeacher);

app.Run();



List<Teacher> GetTeachers()
{
    return teachers;
}
IResult GetTeacher(int n)
{
    if (n <= 0 && n < teachers.Count)
    {
        return Results.Ok(teachers[n]);
    }
    else
    {
        return Results.NotFound();
    }
}

static Teacher GetMicke()
{
    Teacher micke = new() { Name = "Micke" };
    return micke;
}

static void SayHello(string message)
{
    Console.WriteLine(message);
}

public class Teacher()
{
    public string Name { get; set; }
}
