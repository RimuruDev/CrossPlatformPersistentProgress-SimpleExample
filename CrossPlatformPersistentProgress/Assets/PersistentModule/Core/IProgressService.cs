using System;
using RimuruDev.PersistentModule.Models;

namespace RimuruDev.PersistentModule.Core
{
    public interface IProgressService : IDisposable
    {
        public UserProgressProxy UserProgress { get; }
        public SkinProgressProxy SkinProgress { get; }
        public HalloweenEventProgressProxy HalloweenEventProgress { get; }

        public void Save();
        public void Load();
        public void Delete();
    }
}