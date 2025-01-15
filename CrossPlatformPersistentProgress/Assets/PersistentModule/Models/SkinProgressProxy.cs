namespace RimuruDev.PersistentModule.Models
{
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
}