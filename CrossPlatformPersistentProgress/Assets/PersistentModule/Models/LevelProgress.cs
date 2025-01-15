using System;

namespace RimuruDev.PersistentModule.Models
{
    [Serializable]
    public class LevelProgress
    {
        public int Id;
        public bool Completed;

        public override string ToString() =>
            $"Id: {Id} | Completed: {Completed}";
    }
}