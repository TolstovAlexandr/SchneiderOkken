using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class CB_class: IFunctionUnit
    {
        public string Name { get; set; }
        public int? NumOfPole { get; set; }
        public string Type { get; set; }
        public int? ShotCurr { get; set; }
        public int? Curr { get; set; }
        public string TypeOfInstall { get; set; }
        public string Discription { get; set; }
        public string ArtOfCB { get; set; }
        public double? Price { get; set; }


        //Назначаемые родителем
        public string NumOfUnite { get; set; } //Количество занимаемых юнитов

        public CB_class(string name, int? numOfPol, string type, int? shotCurr, int? curr, string typeOfInstall, string discription, string artOfCB, double? price)
        {
            Name = name;
            NumOfPole = numOfPol;
            Type = type;
            ShotCurr = shotCurr;
            Curr = curr;
            TypeOfInstall = typeOfInstall;
            Discription = discription;
            ArtOfCB = artOfCB;
            Price = price;
        }

    }
}
