using System;

namespace RimuruDev.PersistentModule.Models
{
    public class UserProgressProxy
    {
        public event Action<int> OnCoinsChanged;
        public event Action<int> OnCrystalsChanged;
        public event Action<string> OnUserNameChanged;
        public event Action<string> OnUserIdChanged;

        public UserProgress Origin { get; }

        public UserProgressProxy(UserProgress origin)
        {
            Origin = origin;
        }

        public string UserId
        {
            get => Origin.UserId;
            set
            {
                Origin.UserId = value;
                OnUserIdChanged?.Invoke(value);
            }
        }

        public string UserName
        {
            get => Origin.UserName;
            set
            {
                Origin.UserName = value;
                OnUserNameChanged?.Invoke(value);
            }
        }

        public int Coins
        {
            get => Origin.Coins;
            set
            {
                Origin.Coins = value;
                OnCoinsChanged?.Invoke(Origin.Coins);
            }
        }

        public int Crystals
        {
            get => Origin.Crystals;
            set
            {
                Origin.Crystals = value;
                OnCrystalsChanged?.Invoke(Origin.Crystals);
            }
        }

        public sealed override string ToString() =>
            Origin.ToString();
    }
}