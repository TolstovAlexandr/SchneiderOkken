using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    interface ICubicle
    {
        /// <summary>
        /// Наименование панели
        /// </summary>
        string Name { get; }

        //----------------------------------------------Application----------------------------------------//
        /// <summary>
        /// Содержит ли распределение (PCC)
        /// </summary>
        bool IsContainDistribution { get; }

        /// <summary>
        /// Содержит ли управление двигателями (MCC)
        /// </summary>
        bool IsContainMotor { get; }

        //----------------------------------------------Function-------------------------------------------//
        /// <summary>
        /// Может ли использоваться как вводная ячейка
        /// </summary>
        bool IsIncomingCubicle { get; }

        /// <summary>
        /// Может ли использоваться как распределительная ячейка
        /// </summary>
        bool IsDistributionCubicle { get; }

        //----------------------------------------------Type-------------------------------------------//
        /// <summary>
        /// Возможность установки втычных блоков
        /// </summary>
        bool IsDisconnectable { get; }

        /// <summary>
        /// Возможность устновки выдвижных блоков
        /// </summary>
        bool IsWithdrawable { get; }

        /// <summary>
        /// Возможность установки фиксированных блоков
        /// </summary>
        bool IsFixed { get; }

        //----------------------------------------------Specific-------------------------------------------//
        /// <summary>
        /// Является ли ячейкой только для одного MasterpactNW
        /// </summary>
        bool IsContainSingleNW { get; }

        /// <summary>
        /// Является ли ячейкой только для одного Compact NT/NS
        /// </summary>
        bool IsContainSingleNT_NS { get; }

        /// <summary>
        /// Применяется ли в специальных условиях
        /// </summary>
        bool IsSpecificApplication { get; }

        /// <summary>
        /// Может ли содержать систему Polifast
        /// </summary>
        bool IsPolifast { get; }

        /// <summary>
        /// Предназначен для компенсаии или нет
        /// </summary>
        bool IsPowerFactor { get; }

        /// <summary>
        /// Является ли ячейкой для предохранитедей (Jean Muller)
        /// </summary>
        bool IsFuse { get; }


        //----------------------------------------------Списки для характеристик-------------------------------------------//
        /// <summary>
        /// Список токов распределительных шин
        /// </summary>
        List<int> CurrentsOfBusBar { get; }

        /// <summary>
        /// Список допустимых типов вводных аппаратов
        /// </summary>
        List<string> TypeOfIncomers { get; }

        /// <summary>
        /// Список допустимых фидеров >630A
        /// </summary>
        List<string> TypeOfFiders { get; }

        //----------------------------------------------Основная логика-------------------------------------------//
    }
}
