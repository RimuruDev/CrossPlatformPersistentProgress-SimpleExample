// using UnityEngine;
// using Random = UnityEngine.Random;
//
// namespace RimuruDev.PersistentModule
// {
//     public class EntryPoint : MonoBehaviour
//     {
//         private PersistentProgressService progressService;
//
//         private void Awake()
//         {
//             IStorageService storageService;
//
// #if UNITY_WEBGL
//             storageService = new YandexGameStorageService();
// #elif UNITY_ANDROID
//             storageService = new MobileGameStorageService();
// #else
//             throw new Exception("Unsupported platform");
// #endif
//             progressService = new PersistentProgressService(storageService);
//             progressService.Load();
//         }
//
//         private void OnDestroy()
//         {
//             progressService?.Dispose();
//         }
//
//         private void SaveData()
//         {
//             progressService.Save();
//         }
//
//         private void DeleteData()
//         {
//             progressService.Delete();
//         }
//
//         [ContextMenu(nameof(TestSaveData))]
//         private void TestSaveData()
//         {
//             progressService.UserProgress.Coins += Random.Range(10, 100);
//             SaveData();
//         }
//     }
// }