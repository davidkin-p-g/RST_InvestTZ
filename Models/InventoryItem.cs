using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RST_InvestTZ.Models
{
    public class InventoryItem
    {
        private string id;

        // Регулярное выражение для проверки, что Id — 24-значное шестнадцатеричное число
        private static  readonly Regex hex24Regex = new Regex("^[A-Fa-f0-9]{24}$", RegexOptions.Compiled);
        public string Id
        {
            get => id;
            set
            {
                // Проверка значения на соответствие 24-значному HEX-формату
                if (!hex24Regex.IsMatch(value))
                {
                    throw new ArgumentException("Идентификатор должен являтся 24-значным HEX-числом!");
                }
                // Сохраняем значение в поле id в верхнем регистре
                id = value.ToUpper();
            }
        }
        public string Name { get; set; }

        public InventoryItem ( string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
