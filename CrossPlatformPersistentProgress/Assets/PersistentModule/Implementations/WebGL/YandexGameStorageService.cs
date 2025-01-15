using RimuruDev.PersistentModule.Core;
using RimuruDev.PersistentModule.Models;

namespace RimuruDev.PersistentModule.Implementations.WebGL
{
    public class YandexGameStorageService : IStorageService
    {
        public UserProgressProxy UserProgress { get; private set; }
        public SkinProgressProxy SkinProgress { get; private set; }
        public HalloweenEventProgressProxy HalloweenEventProgress { get; private set; }

        public YandexGameStorageService()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL
            YG2.onGetSDKData += OnGetSDKData;
#endif
        }

        public void SaveProgress()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL
            YG2.SaveProgress();
#endif
        }

        public void LoadProgress()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL
            // Нежелательно использовать!!!
            // YGInsides.LoadProgress();
#endif
        }

        public void DeleteAllProgress()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL
            YG2.SetDefaultSaves();
#endif
        }

        public void Dispose()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL
            YG2.onGetSDKData -= OnGetSDKData;
#endif
        }

        private void OnGetSDKData()
        {
#if PLUGIN_YG_2 && UNITY_WEBGL

            ValidateProgress();
            InitializeProgressService();

            UnityEngine.Debug.Log($"OnGetSDKData: {UserProgress} |\n {SkinProgress} |\n {HalloweenEventProgress}");

            void ValidateProgress()
            {
                YG2.saves.UserProgress ??= DefaultProgressFactory.CreateUserProgress();
                YG2.saves.SkinProgress ??= DefaultProgressFactory.CreateSkinProgress();
                YG2.saves.HalloweenEventProgress ??= DefaultProgressFactory.CreateHalloweenEventProgress();
            }

            void InitializeProgressService()
            {
                UserProgress = new UserProgressProxy(YG2.saves.UserProgress);
                SkinProgress = new SkinProgressProxy(YG2.saves.SkinProgress);
                HalloweenEventProgress = new HalloweenEventProgressProxy(YG2.saves.HalloweenEventProgress);
            }
#endif
        }
    }
}