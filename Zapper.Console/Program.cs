// See https://aka.ms/new-console-template for more information
using Zapper.Console;
using Zapper.Console.Enums;
using Zapper.Console.Models;

Console.WriteLine("Hello, Zapper!");

using (var db = new ZapperDb())
{
    db.Database.ExecuteSqlCommand("truncate table profiles;");
    db.SaveChanges();

    FileInfo read = new FileInfo("./profile.json");

    if (read.Exists)
    {
        var profiles = db.FromJson<List<Profile>>(read);
        db.Profiles.AddRange(profiles);
    }
    else
    {
        DateTime today = DateTime.UtcNow;
        //mock data
        for (int i = 0; i < 10; i++)
        {
            Random rnd = new Random();
            var up = new Profile { Id = i, Settings = (SettingFlags)rnd.Next(1, 255) };

            Console.WriteLine($"Profile Id : {up.Id} Settings = {up.Settings}");

            db.Profiles.Add(up);
        }
    }

    db.SaveChanges();

    foreach (var profile in db.Profiles)
    {
        int flag = (int)profile.Settings;

        bool hasFlag = ((int)profile.Settings & 7) == 7;

        Console.WriteLine($"Profile Id: {profile.Id} Value 7: {(hasFlag ? "Match" : "Unmatch")} Setting: {profile.Settings}");

        hasFlag = ((int)profile.Settings & 4) == 4;
        Console.WriteLine($"Profile Id: {profile.Id} Value 4: {(hasFlag ? "Match" : "Unmatch")} Setting: {profile.Settings}");
    }

    db.WriteJson(db.Profiles, "./profile.json");
}


