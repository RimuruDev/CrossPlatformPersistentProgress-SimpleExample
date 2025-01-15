using RimuruDev.PersistentModule.Models;

namespace RimuruDev.PersistentModule.Core
{
    //
    // Вариант использование без монобеха, к примеру прокидывать через Zenject или ServiceLocator. 
    // Но перед регистрацией зависимости нужно прокинуть в него стратегию IStorageService в конструктор.
    //
    public class PersistentProgressService : IProgressService
    {
        private readonly IStorageService storageService;

        public UserProgressProxy UserProgress => storageService.UserProgress;
        public SkinProgressProxy SkinProgress => storageService.SkinProgress;
        public HalloweenEventProgressProxy HalloweenEventProgress => storageService.HalloweenEventProgress;

        public PersistentProgressService(IStorageService storageService) =>
            this.storageService = storageService;

        public void Save() =>
            storageService.SaveProgress();

        public void Load() =>
            storageService.LoadProgress();

        public void Delete() =>
            storageService.DeleteAllProgress();

        public void Dispose() =>
            storageService?.Dispose();
    }
}