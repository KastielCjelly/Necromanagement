using System;

namespace NecroManagement.Resources {
    public class Wallet {
        public event Action<int> OnBalanceChanged;
        public int Amount { get; private set; }

        public void Earn(int amount) {
            Amount += amount;
            OnBalanceChanged?.Invoke(Amount);
        }

        public bool Spend(int amount) {
            if (amount > Amount) 
                return false;
            Amount -= amount;
            OnBalanceChanged?.Invoke(Amount);
            return true;
        }
    }
}