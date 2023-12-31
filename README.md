# Тестовое задание (junior)

## Описание

Если ты играл в билд игры, то наверняка заметил такую штуку, как "дневник". Изначально код там был плохой, костыльный, и в какой-то момент времени я решил его зарефакторить. Данное задание чем-то похоже на это - я накидал базовых вещей, с помощью которых дневник должен соединяться с внешним игровым миром, и тебе предстоит реализовать функционал в части отображения контента и логики перехода между страницами.

Чтобы понять, чего я от тебя жду, достаточно посмотреть, что находится в `build.zip`. Я жду максимально приближенный к тому, что там реализовано, вариант.

Цель задания - подготовить префаб `Diary`, который можно независимо вставлять на другую сцену, который не имеет связей с другими объектами сцены, а общение происходит через ивенты.

## Содержимое проекта

Рассматриваются важные подпапки и файлы внутри `\Assets`.

* `\Code\Events` - чтобы понять, что это такое и как этим пользоваться, необходимо посмотреть видео: https://www.youtube.com/watch?v=raQ3iHhE_Kk. Это важно, потому что на его идеях о ScriptableObject-based events построена игровая архитектура.
* `\Code\Utils.cs` - статичный класс с реализованной функцией для эффекта анимации fade-in/fade-out (открытие дневника через изменение прозрачности). Рекомендуется использовать её как корутину, вместо того, чтобы анимировать это в аниматоре.
* `\Data\*` - данные в виде ScriptableObject'ов, которые необходимо отобразить в дневнике.
* `\Diary\Events` - ивенты, используемые для общения с дневником:
  * `OnDiaryOpenCharacter` - сигнал открытия дневникана странице с персонажем. Вопрос реализации передачи данных о том, какого персонажа следует открыть, остается на исполнителе.
  * `OnDiaryOpenOptions` - сигнал открытия дневника на странице опций
  * `OnDiaryClose` - сигнал закрытия дневника
  * `OnDiaryPageChanged` - уведомление об изменении страницы дневника
  * `OnDiaryOpened` - уведомление об открытии дневника
  * `OnDiaryClosed` - уведомление о закрытии дневника
* `\Diary\Diary` - префаб дневника, основная работа должна быть внутри него
* `\Diary\Code\DiaryHandler.cs` - Заглушка с пустыми функциями, забинженные на листенеры соответствующих ивентов.

## Требования

* Реализовать функционал как в билде внутри архива `build.zip`
* В верхней части экрана три кнопки:
  * Иконка Артаса - открывается дневник на странице с информацией об Артасе
  * Иконка Джайны - открывается дневник на странице с информацией об Джайне
  * Иконка с шестеренкой - открывается дневник на странице с одной кнопкой выхода из игры
* В левой части дневника должно быть две закладки на страницы с Артасом и Джайной. При наведении на них должна проигрываться анимация "увеличения", при отведении - возврат к исходному размеру. Если страница открыта, то должно фиксироваться состояние "нажатой" (увеличенной) кнопки. Прочие закладки должны при этом "отжиматься". Описанные правила поведения закладок так же распростряются и на случай, когда когда открытие дневника произошло через кнопку в верхней части экрана.
* В правой части должна быть закладка на страницу с опцией выхода из игры. Поведение аналогично.
* При открытии дневника фон должен затемняться. Чтобы закрыть дневник - нужно кликнуть за пределами дневника. При закрытии фон должен оттемняться обратно.
* При открытии страницы персонажа должны отображаться данные из ScriptableObjects'ов, расположенных в `\Data\*` 
* При открытии страницы опций должна отображаться кнопка выхода из игры.
* Ивенты `OnDiaryOpened`, `OnDiaryClosed`, `OnDiaryPageChanged` должны посылаться корректно. Для их отслеживания используется объект `Informer`, который пишет в лог об этих событиях. Ивент `OnDiaryPageChanged` должен посылаться только в случае смены страницы. Следует предполагать, что в будущем эти ивенты будут использоваться, чтобы на них вешать звуки - не должно быть двойного срабатывания и т.п.
* Ивенты `OnDiaryOpen*`, `OnDiaryClose` должны использоваться для управления дневником, и должны посылаться из кнопок в верхней части экрана.
* Для выхода из игры использовоать функцию `GameOver`, определенную в `\Code\Utils.cs`
* В лог не должно писаться никаких лишних сообщений, не должно быть Warning'ов, ни тем более Error'ов.

### Что нельзя менять

* Все спрайты внутри проекта
* Содержимое папки `\Assets\Data`
* Содержимое папки `\Assets\Diary\Events`
* Общую структуру объектов на сцене
* Объект `Informer`

### Что можно менять

* `Main\Canvas\Diary` - внутрь префаба нужно добавить объекты, связанные с отображением страниц и закладок
* `Main\Canvas\Topbar` - можно изменить код вызова нажатий кнопок, поделить на префабы, добавить скрипты
* Можно добавлять новые вспомогательные объекты, например такой может потребоваться для создания "Зоны закрытия дневника" (затемнение экрана на фоне дневника + возможность клика для закрытия)
* Можно добавлять новые ивенты, если необходимо
* Ассеты анимациий, связанные с дневником, помещать в папку `Assets\Diary\Animations`
* Можно изменять ивент `OnDiaryOpenCharacter`, по желанию можно реализовать новый тип ивента.
* Исходной точкой работы можно считать пустые функции в `Assets\Diary\`

## Код-стайл

```
tl;dr

* Allman style braces
* CamelCase for type (class/struct/enum) names, public methods, public fields, enum values
* camelCase for private fields, local variables
```

Используется [Microsoft C# Coding Style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md), но со следующими изменениями:

* Приватные поля в `camelCase`, без `_`, `s_`, `t_` и прочих префиксов
* Слово `private` писать не обязательно

