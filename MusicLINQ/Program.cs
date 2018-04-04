using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================

            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            var foundArtist = from artist in Artists where artist.Hometown == "Mount Vernon" select new{artist.RealName};
            foreach(var person in foundArtist)
            {
                // Console.WriteLine(person);
            }
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================

            // Solution 1
            var test = Artists.OrderBy(artist => artist.Age).First();
            // Console.WriteLine(test.ArtistName + "-" + test.Age);

            // Solution 2
            var youngestAge = Artists.Min(artist => artist.Age);
            var youngestArtist = Artists.Where( artist => artist.Age == youngestAge);
            // Console.WriteLine(youngestAge);
            // Console.WriteLine(youngestArtist);
            foreach(var artist in youngestArtist)
            {
                // Console.WriteLine($"The youngest artist is {artist.ArtistName}, who is {artist.Age}.");
            }
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            var williams = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach(var instance in williams)
            {
                // Console.WriteLine(instance.RealName);
            }

            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            var shorterThan8Char = Groups.Where(group => group.GroupName.Length < 8);

            foreach(var group in shorterThan8Char)
            {
                // Console.WriteLine(group.GroupName);
            }
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var oldestFromAtlanta = Artists
                                    .Where(artist => artist.Hometown == "Atlanta")
                                    .OrderByDescending(artist => artist.Age)
                                    .Take(3);
            
            foreach(var artist in oldestFromAtlanta)
            {
                // Console.WriteLine($"{artist.ArtistName}, Age: {artist.Age}");
            }

            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================
            var artistsWithGroup = Artists.Join(Groups,
                                            artist => artist.GroupId, 
                                            group => group.Id,
                                            (artist, group) =>
                                            {
                                                return new { Group = group.GroupName, Hometown = artist.Hometown };
                                            })
                                            .Where(artist => artist.Hometown != "New York City");

            Dictionary<string, string> notFromNY = new Dictionary<string, string>();
            foreach (var artist in artistsWithGroup)
            {
                if (!notFromNY.ContainsKey(artist.Group))
                {
                    notFromNY.Add(artist.Group, artist.Group);
                    // Console.WriteLine(artist.Group);
                }
            }
            
            // foreach (var artist in artistsWithGroup)
            // {
            //    Console.WriteLine($"Group: {artist.Group}, Hometown: {artist.Hometown}");
            // }

            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
            var wuTang = Artists.Join(Groups,
                                    artist => artist.GroupId,
                                    group => group.Id,
                                    (artist, group) =>
                                    {
                                        return new { Group = group.GroupName, Artist = artist.ArtistName };
                                    })
                                    .Where(artist => artist.Group == "Wu-Tang Clan");
            foreach (var artist in wuTang)
            {
                Console.WriteLine(artist.Artist);
            }
        }
    }
}
