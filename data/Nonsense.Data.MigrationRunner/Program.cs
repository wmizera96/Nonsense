// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Nonsense.Data.MigrationRunner;

Console.WriteLine("Executing migrations...");
var stopwatch = Stopwatch.StartNew();

var dataContext = new DataContextFactory().CreateDbContext(args);

await MigrationRunner.MigrateAsync(dataContext);

Console.WriteLine($"Migrations executed successfully in {stopwatch.Elapsed:hh\\:mm\\:ss\\.fff}.");