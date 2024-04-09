using WarehouseApp.Entities;

namespace WarehouseApp.Comunication
{
    public interface IUserComunication
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
