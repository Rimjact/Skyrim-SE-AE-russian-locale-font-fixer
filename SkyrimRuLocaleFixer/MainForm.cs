using System;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.IO.Pipes;
using System.Linq;
using System.Drawing;

namespace SkyrimRuLocaleFixer
{
    public partial class MainForm : Form
    {
        private enum FormButtonType
        {
            All = 0,
            Fix = 1,
            BackToDefault = 2 
        }

        /// <summary>
        /// Хранит имя пользователя компьютера для доступа к папке Documents
        /// </summary>
        private string _userName = string.Empty;
        /// <summary>
        /// Хранит путь к файлу Skyrim.ini
        /// </summary>
        private string _skyrimIniFilePath = string.Empty;
        /// <summary>
        /// Хранит путь к файлу Skyrim_backup.ini
        /// </summary>
        private string _skyrimIniBackupFilePath = string.Empty;
        /// <summary>
        /// Хранит строку исправления шрифтра русской локализации для Skyrim.ini
        /// </summary>
        private string _fixString = @"[Fonts]
sFontConfigFile=Interface\FontConfig_ru.txt";

        public MainForm()
        {
            InitializeComponent();

            // Получаем имя пользователя
            _userName = Environment.UserName;
            _skyrimIniFilePath = $@"c:\Users\{_userName}\Documents\My Games\Skyrim Special Edition\Skyrim.ini";
            _skyrimIniBackupFilePath = $@"c:\Users\{_userName}\Documents\My Games\Skyrim Special Edition\Skyrim_backup.ini";

            CheckSkyrimIniFile();
        }

        /// <summary>
        /// Обновляет текст и его цвет на StatusLabel элементе формы.
        /// </summary>
        /// <param name="statusText">Текст статуса</param>
        /// <param name="statusColor">Цвет статуса</param>
        private void UpdateStatusLable(string statusText, Color statusColor)
        {
            StatusLabel.Text = $"——————— СТАТУС ———————\n{statusText}";
            StatusLabel.ForeColor = statusColor;
        }

        /// <summary>
        /// Блокирует/разблокирует выбранную кнопку (или все).
        /// </summary>
        /// <param name="button">Кнопка: All, Fix, ToDefault</param>
        private void SetEnabledForButton(FormButtonType button, bool enabled)
        {
            switch (button)
            {
                case FormButtonType.All:
                    FixButton.Enabled = enabled;
                    BackToDefaultButton.Enabled = enabled;
                    break;
                case FormButtonType.Fix:
                    FixButton.Enabled = enabled;
                    break;
                case FormButtonType.BackToDefault:
                    BackToDefaultButton.Enabled = enabled;
                    break;
            }
        }

        /// <summary>
        /// Выполняет проверки при старте програмы.
        /// </summary>
        private void CheckSkyrimIniFile()
        {
            // Проверяем наличие файла Skyrim.ini
            if (!IsSkyrimIniFileExist())
            {
                UpdateStatusLable($"Ошибка! Файл Skyrim.ini не найден по пути:\n{_skyrimIniFilePath}", Color.DarkRed);
                SetEnabledForButton(FormButtonType.All, false);
                return;
            }

            // Проверяем возможность редактирования файла Skyrim.ini
            if (!IsProgramCanEditiSkyrimIniFile())
            {
                UpdateStatusLable($"Ошибка! Программа не может редактировать\nфайл Skyrim.ini по пути:\n{_skyrimIniFilePath}.", Color.DarkRed);
                SetEnabledForButton(FormButtonType.All, false);
                return;
            }

            // Проверяем наличие исправления в файле Skyrim.ini
            if (IsFixAlredyExistInSkyrimIniFile())
            {
                UpdateStatusLable($"В файле Skyrim.ini уже содержится исправление\n шрифта русской локализации.", Color.DarkGreen);
                SetEnabledForButton(FormButtonType.Fix, false);
                return;
            }
            else
            {
                UpdateStatusLable($"В файле Skyrim.ini отсутствует исправление шрифта русской локализации.", Color.BlueViolet);
                SetEnabledForButton(FormButtonType.BackToDefault, false);
                return;
            }
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на кнопку исправления.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixButton_Click(object sender, EventArgs e)
        {
            // Создаём файл бэкапа перед изменением файла
            CreateBackupSkyrimIniFile();

            // Добавляем текст исправления в начало файла Skyrim.ini
            var oldLines = File.ReadAllText(_skyrimIniFilePath);
            var newLines = $"{oldLines}\n{_fixString}";
            File.WriteAllText(_skyrimIniFilePath, newLines);

            UpdateStatusLable($"Исправление шрифта русской локализации\nуспешно добавлено в Skyrim.ini.\nSkyrim_backup.ini создан в той же папке.", Color.DarkGreen);

            SetEnabledForButton(FormButtonType.Fix, false);
            SetEnabledForButton(FormButtonType.BackToDefault, true);
        }
        
        /// <summary>
        /// Метод, вызываемый при нажатии на кнопку возвращения поумолчанию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToDefaultButton_Click(object sender, EventArgs e)
        {
            // Создаём файл бэкапа перед изменением файла
            CreateBackupSkyrimIniFile();

            // Заменяем текст исправления на пустую строку в файле Skyrim.ini
            var oldLines = File.ReadAllLines(_skyrimIniFilePath);
            var newLines = oldLines.Where(line => !line.Contains("[Fonts]")).Where(line => !line.Contains(@"sFontConfigFile=Interface\FontConfig_ru.txt"));
            File.WriteAllLines(_skyrimIniFilePath, newLines);

            UpdateStatusLable($"Исправление шрифта русской локализации\nуспешно удалено из Skyrim.ini!\nSkyrim_backup.ini создан в той же папке.", Color.BlueViolet);

            SetEnabledForButton(FormButtonType.Fix, true);
            SetEnabledForButton(FormButtonType.BackToDefault, false);
        }

        /// <summary>
        /// Проверяет существует ли Skyrim.ini файл в документах пользователя.
        /// </summary>
        /// <returns>true/false</returns>
        private bool IsSkyrimIniFileExist()
        {
            return File.Exists(_skyrimIniFilePath);
        }

        /// <summary>
        /// Проверяет может ли програма изменять файл Skyrim.ini 
        /// </summary>
        /// <returns>true/false</returns>
        private bool IsProgramCanEditiSkyrimIniFile()
        {
            // Устанавливает разрешение на запись для файла Skyrim.ini
            var permissionSet = new PermissionSet(PermissionState.None);
            var writePermission = new FileIOPermission(FileIOPermissionAccess.Write, _skyrimIniFilePath);
            permissionSet.AddPermission(writePermission);

            return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
        }

        /// <summary>
        /// Проверяет существует ли исправление шрифта в файле Skyrim.ini для избежания ошибок
        /// </summary>
        /// <returns>true/false</returns>
        private bool IsFixAlredyExistInSkyrimIniFile()
        {
            using (FileStream fileStream = new FileStream(_skyrimIniFilePath, FileMode.Open))
            using (TextReader reader = new StreamReader(fileStream)) 
            {
                return reader.ReadToEnd().Contains(_fixString);   
            }
        }

        /// <summary>
        /// Создаёт резеврную копию Skyrim.ini с названием Skyrim_backup.ini в той же папке
        /// </summary>
        private void CreateBackupSkyrimIniFile()
        {
            // Перезаписывать файл через File.Copy не разрешено, по этому просто удаляем старый файл бэкапа
            if (File.Exists(_skyrimIniBackupFilePath))
                File.Delete(_skyrimIniBackupFilePath);

            // Создаём файл бэкапа путём копирования изначального Skyrim.ini
            File.Copy(_skyrimIniFilePath, _skyrimIniBackupFilePath);
        }
    }
}
