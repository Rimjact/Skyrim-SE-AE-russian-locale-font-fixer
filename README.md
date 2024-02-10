# Skyrim SE/AE Russian Locale Font Fixer | Skyrim SE/AE исправитель шрифта русской локализации
Исправитель шрифта для русской локализации Skyrim SE/AE. Изменяет файл Skyrim.ini в Documents/My Games/Skyrim Special Edition.

![До Skyrim SE/AE исправителя шрифта русской локализации, после](https://i.imgur.com/LdPW6nY.jpeg)

## Об приложении
Это мини-приложение я создал, чтобы ускорить процесс исправления шрифта для русской локализации Skyrim SE/AE. Всегда можно исправить вручную, однако исправитель автоматически создаёт backup версию файла перед редактированием, а также может быстро убрать исправление на случай, если вы хотите видеть английские символы (например для консоли).

Приложение разработано на .NET в Visual Studio 2022.

> [!NOTE]
> Приложение изменяет файл Skyrim.ini в Documents/My Games/Skyrim Special Edition, добавляя или уберая строки:
> ```
> [Fonts]
> sFontConfigFile=Interface\FontConfig_ru.txt
> ```

> [!NOTE]
> Исходный код доступен в архиве "source-code.zip" (проект C# .NET для Visual Studio 2022).
