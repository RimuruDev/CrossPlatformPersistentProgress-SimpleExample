using System.Collections.Generic;
using RimuruDev.PersistentModule.Models;

namespace RimuruDev.PersistentModule.Utils
{
    public static class DefaultProgressFactory
    {
        public static UserProgress CreateUserProgress()
        {
            var userProgress = new UserProgress
            {
                UserId = "8-800-555-xx-xx",
                UserName = "NekoBoy",
                Coins = 20,
                Crystals = 0,
            };

            return userProgress;
        }

        public static SkinProgress CreateSkinProgress()
        {
            var skinProgress = new SkinProgress
            {
                SkinId = "Nami",
                SkinName = "Toma",
                IsSelected = false,
                IsPurchasable = false
            };

            return skinProgress;
        }

        public static HalloweenEventProgress CreateHalloweenEventProgress()
        {
            var halloweenProgress = new HalloweenEventProgress
            {
                Currency = 0,
                LevelProgresses = new List<LevelProgress>
                {
                    new LevelProgress { Id = 1, Completed = false },
                    new LevelProgress { Id = 2, Completed = false },
                    new LevelProgress { Id = 3, Completed = false },
                    new LevelProgress { Id = 4, Completed = false },
                    new LevelProgress { Id = 5, Completed = false },
                }
            };

            return halloweenProgress;
        }
    }
}