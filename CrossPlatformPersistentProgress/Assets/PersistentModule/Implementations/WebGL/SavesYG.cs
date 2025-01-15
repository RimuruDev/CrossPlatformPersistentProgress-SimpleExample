// ReSharper disable CheckNamespace

using RimuruDev.PersistentModule.Models;

//
// NOTE: Нельзя менять неймспейс, иначе не будет работать partial и сохранения для яндекса отвалятся.
//
namespace YG
{
    /// <summary>
    /// Файл для загрузки и сохранения игровых данных через плагин YG.
    /// </summary>
    public partial class SavesYG
    {
        //                              //
        // Тут находятся голые данные.  //
        //                              //
        public UserProgress UserProgress;
        public SkinProgress SkinProgress;
        public HalloweenEventProgress HalloweenEventProgress;
    }
}