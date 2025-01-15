using System;
using System.Collections.Generic;

namespace RimuruDev.PersistentModule.Models
{
    #region Models

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

    [Serializable]
    public class SkinProgress
    {
        public string SkinId;
        public string SkinName;
        public bool IsSelected;
        public bool IsPurchasable;

        public override string ToString() =>
            $"SkinId: {SkinId} | SkinName: {SkinName} | IsSelected: {IsSelected} | IsPurchasable: {IsPurchasable}";
    }

    [Serializable]
    public class LevelProgress
    {
        public int Id;
        public bool Completed;

        public override string ToString() =>
            $"Id: {Id} | Completed: {Completed}";
    }

    #endregion

    #region Proxy

    [Serializable]
    public class HalloweenEventProgress
    {
        public int Currency;
        public List<LevelProgress> LevelProgresses;

        public override string ToString() =>
            $"Currency: {Currency} | LevelProgresses: {LevelProgresses}";
    }

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

    public class SkinProgressProxy
    {
        public SkinProgress Origin { get; private set; }

        public SkinProgressProxy(SkinProgress origin)
        {
            Origin = origin;
        }

        public string SkinId
        {
            get => Origin.SkinId;
            set => Origin.SkinId = value;
        }

        public string SkinName
        {
            get => Origin.SkinName;
            set => Origin.SkinName = value;
        }

        public bool IsSelected
        {
            get => Origin.IsSelected;
            set => Origin.IsSelected = value;
        }

        public bool IsPurchasable
        {
            get => Origin.IsPurchasable;
            set => Origin.IsPurchasable = value;
        }

        public sealed override string ToString() =>
            Origin.ToString();
    }

    public class HalloweenEventProgressProxy
    {
        public event Action<int> OnCurrencyChanged;

        public HalloweenEventProgress Origin { get; private set; }

        public HalloweenEventProgressProxy(HalloweenEventProgress origin)
        {
            this.Origin = origin;
        }

        public int Currency
        {
            get => Origin.Currency;
            set
            {
                Origin.Currency = value;
                OnCurrencyChanged?.Invoke(Origin.Currency);
            }
        }

        public List<LevelProgress> LevelProgresses
        {
            get => Origin.LevelProgresses;
            set => Origin.LevelProgresses = value;
        }

        public sealed override string ToString() =>
            Origin.ToString();
    }

    #endregion
}