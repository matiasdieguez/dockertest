// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var dbContext = new DockerTestDbContext();

dbContext.Dummies.Add(new Dummy { Name = Guid.NewGuid().ToString() });
dbContext.SaveChanges();

foreach (var dummy in dbContext.Dummies.ToList())
{
    Console.WriteLine($"Dummy {dummy.Name}");
}

Console.WriteLine("Bye!");
