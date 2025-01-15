using System;
using System.Collections.Generic;

namespace RimuruDev.PersistentModule.Models
{
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
}