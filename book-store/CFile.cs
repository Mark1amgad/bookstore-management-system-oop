using System;
using System.IO;
using System.Linq; // Needed for deletion
using System.Collections.Generic;

namespace book_store
{
    public class CFile : IClientFileManager
    {
        const string filePath = "FileClient.txt";

        // SAVING: Converts Enum to Int so it saves safely (e.g., Regular -> 0)
        public string ConvertToLine(Client p) => $"{p.Id}#{p.Name}#{p.Phone}#{p.Email}#{(int)p.EMembershipType}#{(int)p.FavBook}";

        public void AddDataLineToFile(string line) => File.AppendAllText(filePath, line + Environment.NewLine);

        public List<Client> LoadDataFromFile()
        {
            List<Client> list = new List<Client>();
            if (!File.Exists(filePath)) return list;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var p = line.Split('#');
                if (p.Length >= 6) // Check for 6 parts to include Type and Genre
                {
                    list.Add(new Client
                    {
                        Id = p[0],
                        Name = p[1],
                        Phone = p[2],
                        Email = p[3],
                        // LOADING: Converts Int back to Enum (e.g., 0 -> Regular)
                        EMembershipType = (ENMembershipType)int.Parse(p[4]),
                        FavBook = (ENGenre)int.Parse(p[5])
                    });
                }
            }
            return list;
        }

        // DELETE: Reads all lines, keeps the ones that DON'T match the ID, and saves back
        public void Delete(string id)
        {
            if (!File.Exists(filePath)) return;
            var lines = File.ReadAllLines(filePath).Where(line => !line.StartsWith(id + "#")).ToArray();
            File.WriteAllLines(filePath, lines);
        }

        public bool Update(string id, Client p) { return true; } // Placeholder
    }
}