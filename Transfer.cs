using RST_InvestTZ.Models;
using RST_InvestTZ.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RST_InvestTZ
{
    public partial class Transfer : Form
    {
        private TransferCatalog shipmentCatalog; // Каталог для "Отгрузка"
        private TransferCatalog receptionСatalog; // Каталог для "Прием"
        private InventoryCatalog inventoryCatalog; // Общий каталог
        // Путь к JSON-файлу в ProgramData\RstInvest
        private readonly string jsonFilePathShipment = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "RstInvest", "shipment.json");
        // Путь к JSON-файлу в ProgramData\RstInvest
        private readonly string jsonFilePathReception = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "RstInvest", "reception.json");
        public Transfer()
        {
            InitializeComponent();
            addShipment.KeyPress += addShipment_KeyPress; // Подписка на событие для Отгрузки
            addReception.KeyPress += addReception_KeyPress; // Подписка на событие  для Приема
            shipmentCatalog = new TransferCatalog(jsonFilePathShipment);
            receptionСatalog = new TransferCatalog(jsonFilePathReception);
            shipmentCatalog.OnErrorOccurred += ShowErrorMessage; // Подписка на таргет ошибок экземпляра класса shipmentCatalog
            receptionСatalog.OnErrorOccurred += ShowErrorMessage; // Подписка на таргет ошибок класса receptionСatalog

            inventoryCatalog = new InventoryCatalog(); // Основной каталог

            // Загрузка данных в таблицы
            LoadDataIntoGrid();
        }

        // Обработчик для добавления элемента табл. Отгрузка по нажатию Enter
        private void addShipment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ProcessIdentifiers(addShipment.Text.Trim().ToUpper(), shipmentCatalog, receptionСatalog);
                e.Handled = true; // Предотврящение отклика на Enter
            }
        }

        // Обработчик для добавления элемента по нажатию Enter
        private void addReception_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ProcessIdentifiers(addReception.Text.Trim().ToUpper(), receptionСatalog, shipmentCatalog);
                e.Handled = true; // Предотврящение отклика на Enter
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите очистить таблицы Прием и Отгрузка?? ", "Подтвердить очистку", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                shipmentCatalog.Clear(); // Очистка каталога "Отгрузка"
                receptionСatalog.Clear(); // Очистка каталога "Прием"
                ClearTextFields();
                LoadDataIntoGrid();     // Обновление таблиц
            }
        }

        private void btnOpenInventory_Click(object sender, EventArgs e)
        {
            // Создаем экземпляр второй формы
            Inventory inventory = new Inventory(inventoryCatalog);

            // Открываем вторую форму как отдельное окно
            inventory.Show();
        }

        // Заполнение Таблиц
        private void LoadDataIntoGrid()
        {
            dgvShipment.Rows.Clear();

            foreach (var item in shipmentCatalog.GetItemCounts())
            {
                dgvShipment.Rows.Add(item.Key, item.Value);
            }

            dgvReception.Rows.Clear();

            foreach (var item in receptionСatalog.GetItemCounts())
            {
                dgvReception.Rows.Add(item.Key, item.Value);
            }
        }

        // Метод добавления идентификаторов
        private void ProcessIdentifiers(string inputText, TransferCatalog targetCatalog, TransferCatalog otherCatalog)
        {

            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Пожалуйста впишите идентификатор.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ids = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var id in ids)
            {

                // Получаем InventoryItem из InventoryCatalog по Id
                InventoryItem item = inventoryCatalog.GetItemById(id);

                if (item == null)
                {
                    MessageBox.Show("Такого идентификатора нет в списке.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                // Добавляем InventoryItem в каталог "Отгрузка" с автоматическим перемещением из "Прием", если нужно
                targetCatalog.AddItem(item, otherCatalog);
            }

            LoadDataIntoGrid();
            ClearTextFields();
        }

        private void ClearTextFields()
        {
            addReception.Clear();
            addShipment.Clear();
        }

        // Генерация ошибок
        private void ShowErrorMessage(string errorMessage)
        {
            // Выводим сообщение об ошибке в MessageBox
            MessageBox.Show(errorMessage, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
