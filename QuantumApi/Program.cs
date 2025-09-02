using Demo;
using Microsoft.Quantum.Simulation.Simulators;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/rng", async () =>
{
    using var sim = new QuantumSimulator();
    var r = await RandomBit.Run(sim);
    return Results.Json(new { result = r.ToString() });
});

app.MapGet("/measure", async (double theta) =>
{
    using var sim = new QuantumSimulator();
    var r = await FlipAndMeasure.Run(sim, theta);
    return Results.Json(new { theta, result = r.ToString() });
});

app.Run();