using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Sheeld
    {
        public Panel panel;
        public Base @base;

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование щита
        /// </summary>
        public string Name { get; set; }

        //********************************Секция 1*********************************************************************************************************
        public Stack<Colomn_70_2> Sect1_stackOfColomns_70_2 { get; set; } //Стэк колонн 70-2 для секции 1
        public Stack<Colomn_115> Sect1_stackOfColomns_115 { get; set; } //Стэк колонн 115 для секции 1

        //********************************Секция 1*********************************************************************************************************
        public Stack<Colomn_70_2> Sect2_stackOfColomns_70_2 { get; set; } //Стэк колонн 70-2 для секции 2
        public Stack<Colomn_115> Sect2_stackOfColomns_115 { get; set; } //Стэк колонн 115 для секции 2

        /// <summary>
        /// Конструктор для щита - здесь будет происходить основная магия расчета ***************************************************************************
        /// </summary>
        /// <param name="panel">ссылка на панель</param>
        /// <param name="base">ссылка на базу</param>
        public Sheeld(ref Panel panel, ref Base @base)
        {
            Sect1_stackOfColomns_70_2 = new Stack<Colomn_70_2>();

            this.Id = panel.Id;
            this.Name = panel.Name;
        }
    }
}
