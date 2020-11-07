﻿using Okken;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Okken
{
    public class Panel
    {
        //Для ссылки на саму себя и проверки соответствия параметров допустимым спискам
        CollectionOfPanels CollectionOfPanels;

        public Panel()
        {
        }

        //Установка ссылки на материнский класс
        public void SetLinkToSelf(CollectionOfPanels collectionOfPanels)
        {
            CollectionOfPanels = collectionOfPanels;
        }

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование щита
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полюстность аппаратов
        /// </summary>
        public string NumOfPole { get; set; }

        /// <summary>
        /// Тип обслуживания
        /// </summary>
        public string TypeOfService { get; set; }

        /// <summary>
        /// Типи установки
        /// </summary>
        public string TypeOfInstall { get; set; }

        /// <summary>
        /// Тип автоматизации
        /// </summary>
        public string TypeOfAutomation { get; set; }

        /// <summary>
        /// Ток КЗ (кА)
        /// </summary>
        public int ShotCurr { get; set; }

        /// <summary>
        /// Система заземления
        /// </summary>
        public string GrSystem { get; set; }

        /// <summary>
        /// Степень защиты
        /// </summary>
        public string DegreeIP { get; set; }

        /// <summary>
        /// Тип подвода питания
        /// </summary>
        public string PowerSupply { get; set; }

        /// <summary>
        /// Металлизированное покрытия шин
        /// </summary>
        public string MetalBusCoating { get; set; }

        /// <summary>
        /// Эпоксидное покрытия шин
        /// </summary>
        public string EpoxyBusCoating { get; set; }

        /// <summary>
        /// Тип покраски
        /// </summary>
        public string Painting { get; set; }

        /// <summary>
        /// Запас пространства в панеле
        /// </summary>
        public string SpaceReserve { get; set; }

        /// <summary>
        /// Наличие АВР
        /// </summary>
        private bool ATSPresent_Bool { get; set; }

        private string atsPresent;
        /// <summary>
        /// Наичие АВР
        /// </summary>
        public string ATSPresent
        {
            get
            {
                return atsPresent;
            }
            set
            {
                atsPresent = value;

                //Проверка оба ли вводных апарата выбраны
                if (StringIncomerCurrent_Sect1 == "НЕТ" || StringIncomerCurrent_Sect2 == "НЕТ" || StringIncomerCurrent_Sect1 == null || StringIncomerCurrent_Sect2 == null)
                    atsPresent = "НЕТ";

                if (atsPresent == "ДА")
                    ATSPresent_Bool = true;
                else ATSPresent_Bool = false;
            }
        }

        /// <summary>
        /// Расположение вводов
        /// </summary>
        public string IncomerLocation { get; set; }

        /// <summary>
        /// Способ подключения
        /// </summary>
        public string TypeOfConnection { get; set; }

        private int incomerCurrent1 = 0;

        private string stringIncomerCurrent_Sect1;
        /// <summary>
        /// Ток вводного аппарата Секции 1 в формате string
        /// </summary>
        public string StringIncomerCurrent_Sect1
        {
            get
            {
                return stringIncomerCurrent_Sect1;
            }
            set
            {
                if (value == "НЕТ")
                    StringBustieCurrent = value;
                stringIncomerCurrent_Sect1 = value;

                if (stringIncomerCurrent_Sect1 == "НЕТ")
                {
                    incomerCurrent1 = 0;
                }
                else
                {
                    int Inc1;
                    bool BoolInc1 = Int32.TryParse(StringIncomerCurrent_Sect1, out Inc1);
                    if (BoolInc1)
                    {
                        incomerCurrent1 = Inc1;
                    }
                }

                //Исключение АВР если убираем вводной аппарет
                if (stringIncomerCurrent_Sect1 == "НЕТ")
                {
                    ATSPresent = "НЕТ";
                    StringIncomerCurrent_Sect3 = "НЕТ";
                }
            }
        }

        private int incomerCurrent2 = 0;

        private string stringIncomerCurrent_Sect2;
        /// <summary>
        /// Ток вводного аппарата Секции 1 в формате string
        /// </summary>
        public string StringIncomerCurrent_Sect2
        {
            get
            {
                return stringIncomerCurrent_Sect2;
            }
            set
            {
                if (value == "НЕТ")
                    StringBustieCurrent = value;
                stringIncomerCurrent_Sect2 = value;

                if (stringIncomerCurrent_Sect1 == "НЕТ")
                {
                    incomerCurrent2 = 0;
                }
                else
                {
                    int Inc2;
                    bool BoolInc2 = Int32.TryParse(StringIncomerCurrent_Sect2, out Inc2);
                    if (BoolInc2)
                    {
                        incomerCurrent2 = Inc2;
                    }
                }

                //Исключение АВР если убираем вводной аппарет
                if (stringIncomerCurrent_Sect2 == "НЕТ")
                {
                    ATSPresent = "НЕТ";
                }
            }
        }

        private int incomerCurrent3 = 0;
        private string stringIncomerCurrent_Sect3;
        /// <summary>
        /// Дополнительный вводной аппарат
        /// </summary>
        public string StringIncomerCurrent_Sect3
        {
            get
            {
                if (StringIncomerCurrent_Sect1 == "НЕТ" || StringIncomerCurrent_Sect2 == "НЕТ" || StringIncomerCurrent_Sect1 == null || StringIncomerCurrent_Sect2 == null)
                {
                    stringIncomerCurrent_Sect3 = "НЕТ";
                    incomerCurrent3 = 0;
                }

                return stringIncomerCurrent_Sect3;
            }
            set
            {
                stringIncomerCurrent_Sect3 = value;
                int Inc3;
                bool BoolSect = Int32.TryParse(value, out Inc3);

                if (BoolSect)
                {
                    incomerCurrent3 = Inc3;
                }


                if (stringIncomerCurrent_Sect3 == "НЕТ")
                    incomerCurrent3 = 0;

                if (StringIncomerCurrent_Sect1 == "НЕТ" || StringIncomerCurrent_Sect2 == "НЕТ" || StringIncomerCurrent_Sect1 == null || StringIncomerCurrent_Sect2 == null)
                {
                    stringIncomerCurrent_Sect3 = "НЕТ";
                    incomerCurrent3 = 0;
                }
                else if (incomerCurrent3 > incomerCurrent1 && incomerCurrent3 > incomerCurrent2)
                {
                    if (incomerCurrent1 > incomerCurrent2)
                    {
                        incomerCurrent3 = incomerCurrent1;
                    }
                    else
                    {
                        incomerCurrent3 = incomerCurrent2;
                    }
                    stringIncomerCurrent_Sect3 = incomerCurrent3.ToString();
                }
            }
        }


        private int bustieCurrent = 0;

        private string stringBustieCurrent;
        /// <summary>
        /// Ток вводного аппарата Секции 1 в формате string
        /// </summary>
        public string StringBustieCurrent
        {
            get
            {
                if (StringIncomerCurrent_Sect1 == "НЕТ" || StringIncomerCurrent_Sect2 == "НЕТ" || StringIncomerCurrent_Sect1 == null || StringIncomerCurrent_Sect2 == null)
                {
                    stringBustieCurrent = "НЕТ";
                    bustieCurrent = 0;
                }

                return stringBustieCurrent;
            }
            set
            {
                stringBustieCurrent = value;
                int Sect;
                bool BoolSect = Int32.TryParse(value, out Sect);

                if (BoolSect)
                {
                    bustieCurrent = Sect;
                }


                if (stringBustieCurrent == "НЕТ")
                    bustieCurrent = 0;

                if (StringIncomerCurrent_Sect1 == "НЕТ" || StringIncomerCurrent_Sect2 == "НЕТ" || StringIncomerCurrent_Sect1 == null || StringIncomerCurrent_Sect2 == null)
                {
                    stringBustieCurrent = "НЕТ";
                    bustieCurrent = 0;
                }
                else if (bustieCurrent > incomerCurrent1 && bustieCurrent > incomerCurrent2)
                {
                    if (incomerCurrent1 > incomerCurrent2)
                    {
                        bustieCurrent = incomerCurrent1;
                    }
                    else
                    {
                        bustieCurrent = incomerCurrent2;
                    }
                    stringBustieCurrent = bustieCurrent.ToString();
                }
            }
        }

        /// <summary>
        /// Тип секционного аппарата
        /// </summary>
        public string TypeOfSectApp { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Токи фидеров
        private int CurrenOfFider1 { get; } = 100;
        private int CurrenOfFider2 { get; } = 160;
        private int CurrenOfFider3 { get; } = 250;
        private int CurrenOfFider4 { get; } = 400;
        private int CurrenOfFider5 { get; } = 630;
        private int CurrenOfFider6 { get; } = 800;
        private int CurrenOfFider7 { get; } = 1000;
        private int CurrenOfFider8 { get; } = 1200;
        private int CurrenOfFider9 { get; } = 1600;
        private int CurrenOfFider10 { get; } = 2000;
        private int CurrenOfFider11 { get; } = 2500;
        private int CurrenOfFider12 { get; } = 3200;
        private int CurrenOfFider13 { get; } = 4000;
        private int CurrenOfFider14 { get; } = 5000;
        private int CurrenOfFider15 { get; } = 6300;

        //Количество фидеров секция 1
        public int Sect1NumOfFider1 { get; set; }
        public int Sect1NumOfFider2 { get; set; }
        public int Sect1NumOfFider3 { get; set; }
        public int Sect1NumOfFider4 { get; set; }
        public int Sect1NumOfFider5 { get; set; }
        public int Sect1NumOfFider6 { get; set; }
        public int Sect1NumOfFider7 { get; set; }
        public int Sect1NumOfFider8 { get; set; }
        public int Sect1NumOfFider9 { get; set; }
        public int Sect1NumOfFider10 { get; set; }
        public int Sect1NumOfFider11 { get; set; }
        public int Sect1NumOfFider12 { get; set; }
        public int Sect1NumOfFider13 { get; set; }
        public int Sect1NumOfFider14 { get; set; }
        public int Sect1NumOfFider15 { get; set; }

        //Количество фидеров секция 2
        public int Sect2NumOfFider1 { get; set; }
        public int Sect2NumOfFider2 { get; set; }
        public int Sect2NumOfFider3 { get; set; }
        public int Sect2NumOfFider4 { get; set; }
        public int Sect2NumOfFider5 { get; set; }
        public int Sect2NumOfFider6 { get; set; }
        public int Sect2NumOfFider7 { get; set; }
        public int Sect2NumOfFider8 { get; set; }
        public int Sect2NumOfFider9 { get; set; }
        public int Sect2NumOfFider10 { get; set; }
        public int Sect2NumOfFider11 { get; set; }
        public int Sect2NumOfFider12 { get; set; }
        public int Sect2NumOfFider13 { get; set; }
        public int Sect2NumOfFider14 { get; set; }
        public int Sect2NumOfFider15 { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Управление двигателями Мощности
        private double PowerMCC1 { get; } = 4;
        private double PowerMCC2 { get; } = 7.5;
        private double PowerMCC3 { get; } = 15.0;
        private double PowerMCC4 { get; } = 22.0;
        private double PowerMCC5 { get; } = 37.0;
        private double PowerMCC6 { get; } = 75.0;
        private double PowerMCC7 { get; } = 110.0;
        private double PowerMCC8 { get; } = 160.0;
        private double PowerMCC9 { get; } = 250.0;

        //Количество в Секции 1
        public int Sect1NumOfMCC1 { get; set; }
        public int Sect1NumOfMCC2 { get; set; }
        public int Sect1NumOfMCC3 { get; set; }
        public int Sect1NumOfMCC4 { get; set; }
        public int Sect1NumOfMCC5 { get; set; }
        public int Sect1NumOfMCC6 { get; set; }
        public int Sect1NumOfMCC7 { get; set; }
        public int Sect1NumOfMCC8 { get; set; }
        public int Sect1NumOfMCC9 { get; set; }

        //Количество в Секции 2
        public int Sect2NumOfMCC1 { get; set; }
        public int Sect2NumOfMCC2 { get; set; }
        public int Sect2NumOfMCC3 { get; set; }
        public int Sect2NumOfMCC4 { get; set; }
        public int Sect2NumOfMCC5 { get; set; }
        public int Sect2NumOfMCC6 { get; set; }
        public int Sect2NumOfMCC7 { get; set; }
        public int Sect2NumOfMCC8 { get; set; }
        public int Sect2NumOfMCC9 { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Плавный пуск SS
        private double PowerSS1 { get; } = 5.5;
        private double PowerSS2 { get; } = 18.5;
        private double PowerSS3 { get; } = 45;
        private double PowerSS4 { get; } = 110;
        private double PowerSS5 { get; } = 250;
        private double PowerSS6 { get; } = 400;

        //Количество в Секции 1
        public int Sect1NumOfSS1 { get; set; }
        public int Sect1NumOfSS2 { get; set; }
        public int Sect1NumOfSS3 { get; set; }
        public int Sect1NumOfSS4 { get; set; }
        public int Sect1NumOfSS5 { get; set; }
        public int Sect1NumOfSS6 { get; set; }

        //Количество в Секции 2
        public int Sect2NumOfSS1 { get; set; }
        public int Sect2NumOfSS2 { get; set; }
        public int Sect2NumOfSS3 { get; set; }
        public int Sect2NumOfSS4 { get; set; }
        public int Sect2NumOfSS5 { get; set; }
        public int Sect2NumOfSS6 { get; set; }

        //---------------------------------------------------------------------------------------------------------------------------------
        //Частотный преобразователь VSD
        private double PowerVSD1 { get; } = 5.5;
        private double PowerVSD2 { get; } = 18.5;
        private double PowerVSD3 { get; } = 45;
        private double PowerVSD4 { get; } = 110;
        private double PowerVSD5 { get; } = 250;
        private double PowerVSD6 { get; } = 400;

        //Количество в Секции 1
        public int Sect1NumOfVSD1 { get; set; }
        public int Sect1NumOfVSD2 { get; set; }
        public int Sect1NumOfVSD3 { get; set; }
        public int Sect1NumOfVSD4 { get; set; }
        public int Sect1NumOfVSD5 { get; set; }
        public int Sect1NumOfVSD6 { get; set; }

        //Количество в Секции 2
        public int Sect2NumOfVSD1 { get; set; }
        public int Sect2NumOfVSD2 { get; set; }
        public int Sect2NumOfVSD3 { get; set; }
        public int Sect2NumOfVSD4 { get; set; }
        public int Sect2NumOfVSD5 { get; set; }
        public int Sect2NumOfVSD6 { get; set; }

        //Компенсация реактивной мощности секция 1
        private double CompPowerSect1 { get; set; }
        private string strCompPowerSect1;

        /// <summary>
        /// Значение реактивной мощности секция 1
        /// </summary>
        public string StrCompPowerSect1
        {
            get
            {
                return strCompPowerSect1;
            }
            set
            {
                strCompPowerSect1 = value;

                double Power;
                bool BoolPower = Double.TryParse(value, out Power);

                if (BoolPower)
                {
                    CompPowerSect1 = Power;
                }

                if (strCompPowerSect1 == "НЕТ")
                    CompPowerSect1 = 0.0;
            }
        }

        //Компенсация реактивной мощности секция 2
        private double CompPowerSect2 { get; set; }
        private string strCompPowerSect2;

        /// <summary>
        /// Значение реактивной мощности секция 2
        /// </summary>
        public string StrCompPowerSect2
        {
            get
            {
                return strCompPowerSect2;
            }
            set
            {
                strCompPowerSect2 = value;

                double Power;
                bool BoolPower = Double.TryParse(value, out Power);

                if (BoolPower)
                {
                    CompPowerSect2 = Power;
                }

                if (strCompPowerSect2 == "НЕТ")
                    CompPowerSect2 = 0.0;
            }
        }

    }
}