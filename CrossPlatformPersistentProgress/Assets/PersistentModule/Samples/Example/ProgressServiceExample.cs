using RimuruDev.PersistentModule.Core;
using UnityEngine;

namespace RimuruDev.PersistentModule.Samples.Example
{
    [DisallowMultipleComponent]
    public sealed class ProgressServiceExample : MonoBehaviour
    {
        private void Awake()
        {
            //
            // NOTE: Использование Static Progress Service туть :3
            //
            // ***NOTE: Load не стоит вызывать для YandexGamePlugin
            // Но для всех остальных платформ, это обязательно вызвать нужно!!!!! Тут без вариантов.
            StaticProgressService.Instance.Load();
        }

        private void Start()
        {
            StaticProgressService.Instance.UserProgress.OnCoinsChanged += UserProgressOnOnCoinsChanged;
        }

        private void OnDestroy()
        {
            StaticProgressService.Instance.UserProgress.OnCoinsChanged -= UserProgressOnOnCoinsChanged;
        }

        //
        // NOTE: В инспекторе нажми на многоточие у скрипта, и там найдешь кнопочку с названием TestSave, жмякни на нее для теста :3
        //
        [ContextMenu("TestSave")]
        private void TestSave()
        {
            StaticProgressService.Instance.UserProgress.Coins += 100;
            StaticProgressService.Instance.Save();
        }

        private void UserProgressOnOnCoinsChanged(int coins)
        {
            Debug.Log($"UserProgress: {StaticProgressService.Instance.UserProgress}");
        }
    }
}