using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryAccountingLib
{
    public enum StatusDay
    {
        Working,// Рабочий день
        PreWorking,// Праздничный день
        SickLeave,// Больничный
        DisrespectfulSash,// Отсутвие по неуважительной причине
        Holiday// Отпуск
    }
}
