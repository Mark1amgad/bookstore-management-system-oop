using System.IO;
using System.Collections.Generic;

namespace book_store
{
    public class CFile : IClientFileManager
    {
        const string filePath = "FileClient.txt";

        public string ConvertToLine(Client p)
        {
            // Professional hashtag separation
            return $"{p.Id}#{p.Name}#{p.Phone}#{p.Email}#{(int)p.EMembershipType}#{(int)p.FavBook}";
        }

        public void AddDataLineToFile(string line)
        {
            File.AppendAllLines(filePath, new[] { line });
        }
    }
}