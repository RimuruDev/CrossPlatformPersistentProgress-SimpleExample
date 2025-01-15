using System;

namespace RimuruDev.PersistentModule.Models
{
    [Serializable]
    public class UserProgress
    {
        public string UserId;
        public string UserName;
        public int Coins;
        public int Crystals;

        public override string ToString() =>
            $"UserId: {UserId} | UserName: {UserName} | Coins: {Coins} | Crystals: {Crystals}";
    }
}