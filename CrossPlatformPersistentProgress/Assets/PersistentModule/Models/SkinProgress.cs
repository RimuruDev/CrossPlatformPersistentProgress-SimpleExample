using System;

namespace RimuruDev.PersistentModule.Models
{
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
}