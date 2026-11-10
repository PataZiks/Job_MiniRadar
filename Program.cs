using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using MiniRadar;


var text = File.ReadAllText("jobs.json");
var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
var jobs = System.Text.Json.JsonSerializer.Deserialize<List<Job>>(text, options) ?? new List<Job>();

var badWords = new List<string> { "Senior", "praktikum", "lead" };

var goodJobs = new List<Job>();

foreach (var job in jobs)
{
    var title = job.Title.ToLower();

    if (title.Contains("junior")) job.Score += 3;
    if (title.Contains("trainee")) job.Score += 3;
    if (title.Contains("c#")) job.Score += 2;
    if (job.Location == "Wien") job.Score += 1;

    var isBad = badWords.Any(word => job.Title.Contains(word));
    if (!isBad)
    {
        goodJobs.Add(job);
    }
}

var sorted = goodJobs.OrderByDescending(job => job.Score);

foreach (var job in sorted)
{
    Console.WriteLine($"{job.Score} Punkte - {job.Title} bei {job.Company} in {job.Location}");
}
Console.WriteLine("Insgesammt: " + jobs.Count + " Jobs");


