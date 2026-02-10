using System.Collections.Generic;

namespace book_store
{
    public interface IPersonActions
    {
        decimal ApplyDiscount(decimal price, ENMembershipType membershipType);
    }

    public interface IClientFileManager
    {
        void AddDataLineToFile(string dataLine);
        List<Client> LoadDataFromFile();
        string ConvertToLine(Client person);
        void Delete(string accountNumber);
        bool Update(string accountNumber, Client newData);
    }
}