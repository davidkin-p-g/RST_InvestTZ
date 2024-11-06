using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using RST_InvestTZ.Models;
using System.Text.Json;
using System.Windows.Forms;

namespace RST_InvestTZ.Services
{
    public class InventoryCatalog
    {
        private List<InventoryItem> items;
        // Путь к JSON-файлу в ProgramData\RstInvest
        private readonly string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "RstInvest", "inventory.json");
        //private readonly string jsonFilePath = "inventory.json"; // Путь к файлу JSON

        // Флаг, указывающий на наличие ошибок
        public bool HasErrors { get; private set; } = false;
        // Определение события для ошибок
        public event Action<string> OnErrorOccurred;

        public InventoryCatalog()
        {
            items = new List<InventoryItem>();
            LoadFromJson(); // Загрузка данных из Json при инициализации
        }

        // Добавление элемента в инвентарь
        public void AddItem(string id, string name, bool triggerError = true)
        {
            HasErrors = false;
            // Проверка на дубликаты 
            if (items.Any(item => item.Id == id.ToUpper()))
            {
                if (triggerError)
                {
                    TriggerError($"Идентификатор '{id}' Уже добавлен в таблицу.");
                }
                else
                {
                    throw new ArgumentException($"Идентификатор '{id}' уже добавлен в таблицу.");
                }
                return;
            }
            // Проверка на корректность ID
            try
            {
                items.Add(new InventoryItem(id, name));
            }
            catch (ArgumentException ex)
            {
                if (triggerError)
                {
                    TriggerError(ex.Message);
                }
                else
                {
                    throw; // Пробрасываем ошибку ниже;
                }
            }
            SaveToJson();
        }

        // Удаление элемента по ID
        public void RemoveItem(string id)
        {
            var item = items.FirstOrDefault(i => i.Id == id.ToUpper());
            if (item != null)
            {
                items.Remove(item);
                SaveToJson();
            }
        }

        // Изменение элемента по ID
        public void UpdateItem(string id, string newName)
        {
            var item = items.FirstOrDefault(i => i.Id == id.ToUpper());
            if (item != null)
            {
                item.Name = newName;
                SaveToJson();
            }
        }

        // Загрузка данных из JSON
        private void LoadFromJson()
        {
            HasErrors = false;
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string json = File.ReadAllText(jsonFilePath);
                    items = JsonSerializer.Deserialize<List<InventoryItem>>(json) ?? new List<InventoryItem>();
                }
                else
                {
                    TriggerError("Ошибка: JSON-файл не найден.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                TriggerError("Ошибка: Доступ к JSON-файлу запрещен.");
            }
            catch (IOException ex)
            {
                TriggerError($"Ошибка ввода/вывода при загрузке JSON: {ex.Message}");
            }
            catch (JsonException ex)
            {
                TriggerError($"Ошибка десериализации данных JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                TriggerError($"Неизвестная ошибка: {ex.Message}");
            }
        }

        // Сохранение данных в JSON
        private void SaveToJson()
        {
            HasErrors = false;
            try
            {
                // Создаем папку, если она отсутствует
                Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath) ?? string.Empty);

                string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFilePath, json);
            }
            catch (UnauthorizedAccessException)
            {
                TriggerError("Ошибка: Доступ к JSON-файлу запрещен при сохранении.");
            }
            catch (IOException ex)
            {
                TriggerError($"Ошибка ввода/вывода при сохранении JSON: {ex.Message}");
            }
            catch (Exception ex)
            {
                TriggerError($"Неизвестная ошибка при сохранении JSON: {ex.Message}");
            }
        }

        // Импорт данных из текстового файла
        // Можно мы разделить на 2 метода что бы 1 вытаскивал сформированный список из файла а второй добавлял итемы
        public void ImportFromTextFile(string filePath)
        {
            HasErrors = false;
            var failedItems = new List<string>(); // Список для хранения ошибок добавления

            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    try
                    {
                        var parts = line.Split(';');
                        if (parts.Length == 2)
                        {
                            AddItem(parts[0], parts[1], false);
                        }
                        else
                        {
                            failedItems.Add($"Неверный формат строки: {line}"); // Неверный формат
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        // Не верный ID
                        failedItems.Add($"Ошибка добавления позиции в строке '{line}': {ex.Message}");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                failedItems.Add("Ошибка: Файл не найден.");
            }
            catch (UnauthorizedAccessException)
            {
                failedItems.Add("Ошибка: Нет доступа к файлу.");
            }
            catch (IOException ex)
            {
                failedItems.Add($"Произошла ошибка ввода/вывода: {ex.Message}");
            }
            catch (Exception ex)
            {
                failedItems.Add($"Неизветная ошибка: {ex.Message}");
            }
            
            if (failedItems.Count > 0)
            {
                string errorMessage;
                HasErrors = true;

                if (failedItems.Count > 10)
                {
                    var firstTenErrors = failedItems.Take(10);
                    errorMessage = "Некоторые позиции не были добавлены:\n" + string.Join("\n", firstTenErrors) +
                                   $"\n...и еще {failedItems.Count - 10} ошибок.";
                }
                else
                {
                    errorMessage = "Некоторые позиции не были добавлены:\n" + string.Join("\n", failedItems);
                }
                TriggerError(errorMessage);
            }
        }

        // Экспорт данных в текстовый файл
        public void ExportToTextFile(string filePath)
        {
            HasErrors = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var item in items)
                    {
                        writer.WriteLine($"{item.Id};{item.Name}");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                TriggerError("Ошибка: Доступ к файлу запрещен при экспорте.");
            }
            catch (IOException ex)
            {
                TriggerError($"Ошибка ввода/вывода при экспорте в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                TriggerError($"Неизвестная ошибка при экспорте в файл: {ex.Message}");
            }
        }

        // Получение всех элементов
        public List<InventoryItem> GetAllItems()
        {
            return new List<InventoryItem>(items);
        }

        // Метод для получения элемента по ID
        public InventoryItem GetItemById(string id)
        {
            return items.FirstOrDefault(item => item.Id == id); // Возвращаем элемент или null, если не найден
        }

        // Тригер Ошибки
        private void TriggerError(string errorMessage)
        {
            HasErrors = true; // Устанавливаем флаг в true при ошибке
            OnErrorOccurred?.Invoke(errorMessage); // Вызываем событие ошибки
        }

    }
}
