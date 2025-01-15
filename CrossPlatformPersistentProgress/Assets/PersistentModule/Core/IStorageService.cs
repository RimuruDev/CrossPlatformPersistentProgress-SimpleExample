using System;
using RimuruDev.PersistentModule.Models;

namespace RimuruDev.PersistentModule.Core
{
    public interface IStorageService : IDisposable
    {
        public UserProgressProxy UserProgress { get; }
        public SkinProgressProxy SkinProgress { get; }
        public HalloweenEventProgressProxy HalloweenEventProgress { get; }

        public void SaveProgress();
        public void LoadProgress();
        public void DeleteAllProgress();
    }
}