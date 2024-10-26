namespace NecroManagement.Inventories {
    public interface IHasInventory {
        bool IsClosed();
        Inventory GetInventory();
    }
}