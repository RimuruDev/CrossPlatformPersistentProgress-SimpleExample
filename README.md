# Руководство по работе с модулем сохранений

## Основные термины

### Модель
Модель — это **чистые данные**.  
Это класс или структура, которые содержат только поля и свойства, без методов и логики.

**Пример:**
```csharp
[Serializable]
public class UserProgress
{
    public string UserId;
    public string UserName;
    public int Coins;
    public int Crystals;
}
```

### Прокси
**Прокси** — это обертка над моделью, которая полностью повторяет её интерфейс.  
Прокси используется для:
1. **Валидации данных** перед их изменением.
2. **Подписки на изменения данных** через события.
3. **Безопасного управления источником данных**.

**Пример:**
```csharp
public class UserProgressProxy
{
    public event Action<int> OnCoinsChanged;
    
    public UserProgress Origin { get; private set; }

    public UserProgressProxy(UserProgress origin)
    {
        Origin = origin;
    }

    public int Coins
    {
        get => Origin.Coins;
        set
        {
            Origin.Coins = value;
            OnCoinsChanged?.Invoke(value);
        }
    }
}
```

---

## Устройство модуля

### Основная идея
Модуль разделяет **данные (модели)** и **логику работы с данными (прокси)**.  
Кроме того, он построен на принципах **абстракции** и **расширяемости**.

### Этапы работы
1. **Определяем данные, которые нужно сохранять (модели).**
2. **Создаем прокси для работы с этими данными.**
3. **Реализуем `IStorageService` — интерфейс для управления сохранением.**

---

### Интерфейс API: `IStorageService`
Интерфейс описывает базовые операции для работы с сохранениями:
- `SaveProgress()` — сохранить данные.
- `LoadProgress()` — загрузить данные.
- `DeleteAllProgress()` — удалить данные.

**Пример интерфейса:**
```csharp
public interface IStorageService : IDisposable
{
    public UserProgressProxy UserProgress { get; }
    ...
    public void SaveProgress();
    public void LoadProgress();
    public void DeleteAllProgress();
}
```

**Расширение интерфейса:**  
Если нужно добавить новый тип данных, достаточно:
1. Создать новую модель.
2. Написать для неё прокси (по желанию).
3. Добавить её в `IStorageService` как новое свойство.

---

### Реализации интерфейса

#### 1. `MobileGameStorageService`
Класс для сохранения данных на Android и iOS.  
**Методы:**
- `SaveProgress()` — сохраняет данные на диск в формате JSON.
- `LoadProgress()` — загружает данные с диска и оборачивает их в прокси.
- `DeleteAllProgress()` — удаляет файлы данных с диска.

#### 2. `YandexGameStorageService`
Класс для интеграции с API Яндекс Игр (WebGL).  
**Методы:**
- `SaveProgress()` — вызывает метод сохранения в плагине Яндекса.
- `LoadProgress()` — не используется (данные загружаются автоматически через плагин).
- `DeleteAllProgress()` — вызывает сброс прогресса через API плагина.

---

## Как всё это работает?

Модуль использует **единый интерфейс** для всех платформ.  
**Класс `StaticProgressService`** автоматически выбирает нужную реализацию (например, `MobileGameStorageService` для Android) на основе текущей платформы.

### Как создается нужная реализация?
**Пример:**
```csharp
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
```

### Как использовать модуль в коде?
#### Загрузка данных:
```csharp
StaticProgressService.Instance.Load();
```

#### Сохранение данных:
```csharp
StaticProgressService.Instance.Save();
```

#### Изменение данных:
```csharp
StaticProgressService.Instance.UserProgress.Coins += 100;
```

#### Подписка на изменения:
```csharp
StaticProgressService.Instance.UserProgress.OnCoinsChanged += coins =>
{
    Debug.Log($"Монеты изменились: {coins}");
};
```

---

## Преимущества модуля

1. **Единый API**  
   Не важно, где и как ты сохраняешь данные — структура интерфейса остаётся неизменной.

2. **Расширяемость**  
   Легко добавить новый способ сохранения (например, удалённый сервер или SD-карту).

3. **Гибкость**  
   Поддерживает как один класс для всех данных (`GameData`), так и множество отдельных моделей.

4. **Лёгкость замены**  
   Можно легко заменить способ сериализации (например, с `JsonUtility` на `Newtonsoft.Json`) в одном месте.

5. **Поддержка событий**  
   Удобно отслеживать изменения данных через прокси.

---

## Минимальный пример для небольших проектов

Если ты используешь всего один класс данных (например, `GameData`), то достаточно:
1. Создать модель:
```csharp
[Serializable]
public class GameData
{
    public int Coins;
    public string PlayerName;
}
```

2. Добавить её в реализацию `IStorageService`:
```csharp
public GameDataProxy GameData { get; private set; }
```

3. Всё! Ты можешь использовать этот модуль даже с одним классом.

---
