using RST_InvestTZ.Models;
using RST_InvestTZ.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RST_InvestTZ
{
    public partial class Inventory : Form
    {
        private InventoryCatalog catalog;

        public Inventory(InventoryCatalog inventoryCatalog)
        {
            InitializeComponent();
            dgvInventory.UserDeletingRow += DgvInventory_UserDeletingRow; // Подписка на событие UserDeletingRow для удаления строк
            catalog = inventoryCatalog;

            catalog.OnErrorOccurred += ShowErrorMessage; // Подписка на таргет ошибок класса InventoryCatalog
            LoadDataIntoGrid();
        }

        // Кнопка Добавления Элемента
        private void btnInventoryAdd_Click(object sender, EventArgs e)
        {
            string id = textInventoryId.Text.Trim();
            string name = textInventoryName.Text.Trim();

            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста заполните поля Наименование и Идетнификатор!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Добавление элемента в каталог и обновление таблицы
            catalog.AddItem(id, name);

            if (!catalog.HasErrors)
            {
                MessageBox.Show("Обьект добавлен", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataIntoGrid();
            }
            // Очистка полей ввода
            textInventoryId.Clear();
            textInventoryName.Clear();

        }

        // Обработчик для удаления данных при удалении строки
        private void DgvInventory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string id = e.Row.Cells["InventoryId"].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(id))
            {
                catalog.RemoveItem(id); // Удаляем элемент из каталога
                MessageBox.Show("Обьект удален!");
            }
        }

        // Поиск по ID или Name
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadDataIntoGrid(); // Отображаем все элементы, если поле поиска пустое
            }
            else
            {
                var filteredItems = catalog.GetAllItems()
                    .Where(item => item.Id.ToLower().Contains(searchTerm) || item.Name.ToLower().Contains(searchTerm));
                LoadDataIntoGrid(filteredItems);
            }
        }
        
        // Загрузка данных из файла
        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите файл для загрузки инвентаря";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // Вызываем метод импорта и получаем список ошибок
                    catalog.ImportFromTextFile(filePath);

                    LoadDataIntoGrid(); // Обновление интерфейса после загрузки
                    if (!catalog.HasErrors)
                    {
                        MessageBox.Show("Инвентарь успешно загружен из файла!", "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
            }
        }

        // Харузка данных в файл
        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Выберите место для сохранения инвентаря";
                saveFileDialog.FileName = "inventory.txt"; // Предложение имени файла по умолчанию

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    catalog.ExportToTextFile(filePath);
                    if (!catalog.HasErrors)
                    {
                        MessageBox.Show("Инвентарь успешно сохранен в файл!", "Сохранение завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Загрузка обновленной информации в таблицу
        private void LoadDataIntoGrid(IEnumerable<InventoryItem> items = null)
        {
            dgvInventory.Rows.Clear();

            // Если items не указан, загружаем все элементы
            if (items is null)
            {
                items = catalog.GetAllItems();
            }

            foreach (var item in items)
            {
                dgvInventory.Rows.Add(item.Id, item.Name);
            }
        }

        // Генерация ошибок
        private void ShowErrorMessage(string errorMessage)
        {
            // Выводим сообщение об ошибке в MessageBox
            MessageBox.Show(errorMessage, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    }
