// See https://aka.ms/new-console-template for more information

using Nonsense.Data.MigrationRunner;

var dataContext = new DataContextFactory().CreateDataContext();

await MigrationRunner.MigrateAsync(dataContext);
