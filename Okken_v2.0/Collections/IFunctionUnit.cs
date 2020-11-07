using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public interface IFunctionUnit
    {
        string Name { get; set; }
        int? NumOfPole { get; set; }
        string TypeOfInstall { get; set; }
        string Discription { get; set; }
        int? ShotCurr { get; set; }
        double? Price { get; set; }

        //Назначаемые родителем
        string NumOfUnite { get; set; } //Количество занимаемых юнитов
    }
}
