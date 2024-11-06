using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RST_InvestTZ.Models;

namespace RST_InvestTZ.Services
{
    internal class TransferCatalog
    {
        private Dictionary<string, List<InventoryItem>> items; // Хранит список идентификаторов по имени элемента
        private readonly string jsonFilePath;
        // Флаг, указывающий на наличие ошибок
        public bool HasErrors { get; private set; } = false;
        // Определение события для ошибок
        public event Action<string> OnErrorOccurred;

        public TransferCatalog(string json_file_path)
        {
            items = new Dictionary<string, List<InventoryItem>>();
            jsonFilePath = json_file_path;
            LoadFromJson(); // Загрузка данных из Json при инициализации
        }

        // Добавление InventoryItem с проверкой наличия в другом каталоге
        public void AddItem(InventoryItem item, TransferCatalog otherCatalog)
        {
            HasErrors = false;
            // Если идентификатор уже есть в другом каталоге, перемещаем его в текущий каталог
            if (otherCatalog.ContainsItem(item.Id))
            {
                otherCatalog.RemoveItem(item.Id);
            }

            if (!items.ContainsKey(item.Name))
            {
                items[item.Name] = new List<InventoryItem>();
            }

            // Добавляем InventoryItem, если он еще не существует
            if (!items[item.Name].Any(i => i.Id == item.Id))
            {
                items[item.Name].Add(item);
            }
            else
            {
                TriggerError($"Идентификатор '{item.Id}' Уже добавлен в таблицу.");
            }
            SaveToJson();
        }

        // Проверка, содержится ли InventoryItem с данным Id
        public bool ContainsItem(string id)
        {
            return items.Values.Any(itemList => itemList.Any(i => i.Id == id));
        }

        // Удаление InventoryItem по идентификатору
        public void RemoveItem(string id)
        {
            foreach (var itemList in items.Values)
            {
                var item = itemList.FirstOrDefault(i => i.Id == id);
                if (item != null)
                {
                    itemList.Remove(item);
                    break;
                }
            }

            // Удаляем имя из словаря, если больше нет элементов
            foreach (var key in items.Keys.ToList())
            {
                if (items[key].Count == 0)
                {
                    items.Remove(key);
                }
            }
            SaveToJson();
        }

        // Метод для очистки всех данных
        public void Clear()
        {
            items.Clear();
            SaveToJson();
        }

        // Метод для получения количества идентификаторов по каждому наименованию
        public Dictionary<string, int> GetItemCounts()
        {
            // Возвращаем словарь, где ключ — имя элемента, а значение — количество идентификаторов
            return items.ToDictionary(item => item.Key, item => item.Value.Count);
        }

        // Сохранение данных в JSON-файл
        public void SaveToJson()
        {
            // Создаем папку, если она отсутствует
            Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath) ?? string.Empty);
            
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize(items, options);
            File.WriteAllText(jsonFilePath, jsonData);
        }

        // Загрузка данных из JSON-файла
        public void LoadFromJson()
        {
            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                items = JsonSerializer.Deserialize<Dictionary<string, List<InventoryItem>>>(jsonData) 
                    ?? new Dictionary<string, List<InventoryItem>>();
            }
        }

        // Тригер Ошибки
        private void TriggerError(string errorMessage)
        {
            HasErrors = true; // Устанавливаем флаг в true при ошибке
            OnErrorOccurred?.Invoke(errorMessage); // Вызываем событие ошибки
        }
    }
}
