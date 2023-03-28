namespace ClientConsole
{
    using InstantLicenses.DataLayer;
    using InstantLicenses.DataLayer.DbModels;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Metadata;

    public class Program
    {
        static async Task Main(string[] args)
        {
            var db = new License_Context();
            Console.WriteLine($"Database path: {db.DbPath}.");
            // Create
            //Console.WriteLine("Inserting a new blog");
            //db.Add(new License { Id = 2, Name = "300ABC" });
            //db.Add(new License { Id = 3, Name = "123456" });
            //db.Add(new License { Id = 4, Name = "ABCDEF" });
            //db.Add(new License { Id = 5, Name = "StevesSpecial" });
            //db.Add(new License { Id = 6, Name = "FAN666" });
            //db.Add(new License { Id = 7, Name = "HiThere" });
            //await db.SaveChangesAsync();
            //Console.Write("Done");
            //Console.ReadKey();

            //var licList = db.Licenses
            //    .OrderBy(x => x.Id)
            //    .ToList();



            //var item = await db.Licenses.FirstOrDefaultAsync(x => x.Id == 5);
            //if(item is null)
            //{
            //    Console.WriteLine("Item not found");
            //}
            //else
            //{
            //    Console.WriteLine(item.Name);
            //}



            //foreach(var lic in licList)
            //    Console.WriteLine($"Found Id:{lic.Id} Name:{lic.Name}");


            //IQueryable<License> licenses = db.Licenses.Where(x => x.Name.Length < 7);

            //IQueryable<License> licenses = db.Licenses
            //    .OrderByDescending(x => x.Id)
            //    .Take(4);

            IQueryable<License> licenses = db.Licenses
                .OrderBy(x => x.Name)
                .Skip(3)
                .Take(4);

            var licResult = await licenses.AsNoTracking().ToListAsync();
            foreach (var license in licenses)
            {
                Console.WriteLine(license.Name);
            }
            db.Dispose();
        }   
    }
}