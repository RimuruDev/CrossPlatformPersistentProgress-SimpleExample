#if UNITY_WEBGL
using RimuruDev.PersistentModule.Implementations.WebGL;
#endif

#if UNITY_ANDROID
using RimuruDev.PersistentModule.Implementations.Mobile;
#endif

using UnityEngine;

namespace RimuruDev.PersistentModule.Core
{
    public static class StaticProgressService
    {
        private static PersistentProgressService instance;

        public static PersistentProgressService Instance
        {
            get
            {
                if (instance != null) 
                    return instance;
                
                var storageService = CreateStorageService();
                instance = new PersistentProgressService(storageService);

                var obj = new GameObject("[PersistentProgressService]");
                Object.DontDestroyOnLoad(obj);

                return instance;
            }
        }

        private static IStorageService CreateStorageService()
        {
#if UNITY_WEBGL
            return new YandexGameStorageService();
#elif UNITY_ANDROID
            return new MobileGameStorageService();
#else
            throw new System.NotSupportedException("Unsupported platform");
#endif
        }
    }
}