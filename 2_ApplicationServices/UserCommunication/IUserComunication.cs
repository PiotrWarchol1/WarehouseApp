using WarehouseApp.Entities;

namespace WarehouseApp.UserCommunication
{
    public interface IUserCommunication
    {
        void AddHelmet();
        void InsertData();
        void OnItemAdded(object? sender, Helmet e);
        void OnItemRemove(object? sender, Helmet e);
        void ReadAllHelmetsFromDb();
        void RemoveHelmet();
        void UpdateHelmet();
    }
}
