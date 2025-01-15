using System;
using System.IO;
using RimuruDev.PersistentModule.Core;
using RimuruDev.PersistentModule.Models;
using UnityEngine;
using static RimuruDev.PersistentModule.Utils.DefaultProgressFactory;

namespace RimuruDev.PersistentModule.Implementations.Mobile
{
    /// <summary>
    /// Сервис для мобильных платформ (например, Android) с сохранением в отдельные JSON-файлы)))
    /// </summary>
    public class MobileGameStorageService : IStorageService
    {
        // Я обычно выношу в отдельный класс констант, но можно просто тут инкастылировать)
        private const string UserProgressKey = "user_progress.json";
        private const string SkinProgressKey = "skin_progress.json";
        private const string HalloweenEventProgressKey = "halloween_event_progress.json";

        private readonly string userProgressFilePath;
        private readonly string skinProgressFilePath;
        private readonly string halloweenEventProgressFilePath;

        public UserProgressProxy UserProgress { get; private set; }
        public SkinProgressProxy SkinProgress { get; private set; }
        public HalloweenEventProgressProxy HalloweenEventProgress { get; private set; }

        //
        // Пока конвертить не буду
        //
        public MobileGameStorageService()
        {
            userProgressFilePath = Path.Combine(Application.persistentDataPath, UserProgressKey);
            skinProgressFilePath = Path.Combine(Application.persistentDataPath, SkinProgressKey);
            halloweenEventProgressFilePath = Path.Combine(Application.persistentDataPath, HalloweenEventProgressKey);
        }

        public void SaveProgress()
        {
            SaveToFile(userProgressFilePath, UserProgress.Origin);
            SaveToFile(skinProgressFilePath, SkinProgress.Origin);
            SaveToFile(halloweenEventProgressFilePath, HalloweenEventProgress.Origin);
        }

        public void LoadProgress()
        {
            var userProgress = LoadFromFile(userProgressFilePath, CreateUserProgress());
            UserProgress = new UserProgressProxy(userProgress);

            var skinProgress = LoadFromFile(skinProgressFilePath, CreateSkinProgress());
            SkinProgress = new SkinProgressProxy(skinProgress);

            var halloweenProgressProxy = LoadFromFile(halloweenEventProgressFilePath, CreateHalloweenEventProgress());
            HalloweenEventProgress = new HalloweenEventProgressProxy(halloweenProgressProxy);

            Debug.Log($"UserProgress: {UserProgress.Origin}");
            Debug.Log($"SkinProgress: {SkinProgress.Origin}");
            Debug.Log($"HalloweenEventProgress: {HalloweenEventProgress.Origin}");
        }

        public void DeleteAllProgress()
        {
            DeleteFile(userProgressFilePath);
            DeleteFile(skinProgressFilePath);
            DeleteFile(halloweenEventProgressFilePath);
        }

        private void SaveToFile<TData>(string filePath, TData data) //where TData : class
        {
            try
            {
                var json = JsonUtility.ToJson(data);

                File.WriteAllText(filePath, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error saving file at {filePath}: {e.Message}");
            }
        }

        private TData LoadFromFile<TData>(string filePath, TData defaultData = default) // where TData : class
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);

                    return JsonUtility.FromJson<TData>(json);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error loading file at {filePath}: {e.Message}");
            }

            return defaultData;
        }

        private void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error deleting file at {filePath}: {e.Message}");
                }
            }
        }

        public void Dispose() { }
    }
}