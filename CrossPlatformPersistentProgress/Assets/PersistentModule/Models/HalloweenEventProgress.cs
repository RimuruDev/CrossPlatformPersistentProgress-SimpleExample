using System;
using System.Collections.Generic;

namespace RimuruDev.PersistentModule.Models
{
    [Serializable]
    public class HalloweenEventProgress
    {
        public int Currency;
        public List<LevelProgress> LevelProgresses;

        public override string ToString() =>
            $"Currency: {Currency} | LevelProgresses: {LevelProgresses}";
    }
}