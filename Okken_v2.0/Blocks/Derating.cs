using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class Derating
    {
        public string Name { get; set; }

        //IP31
        public int? RatedСurrent_IP31_35C { get; set; } //Номинальный ток при IP31_35C
        public int? RatedСurrent_IP31_40C { get; set; } //Номинальный ток при IP31_40C
        public int? RatedСurrent_IP31_45C { get; set; } //Номинальный ток при IP31_45C
        public int? RatedСurrent_IP31_50C { get; set; } //Номинальный ток при IP31_50C
        public int? RatedСurrent_IP31_55C { get; set; } //Номинальный ток при IP31_55C

        //IP41
        public int? RatedСurrent_IP41_35C { get; set; } //Номинальный ток при IP41_35C
        public int? RatedСurrent_IP41_40C { get; set; } //Номинальный ток при IP41_40C
        public int? RatedСurrent_IP41_45C { get; set; } //Номинальный ток при IP41_45C
        public int? RatedСurrent_IP41_50C { get; set; } //Номинальный ток при IP41_50C
        public int? RatedСurrent_IP41_55C { get; set; } //Номинальный ток при IP41_55C

        public Derating() { }

        public Derating(
            string Name,
            int? RatedСurrent_IP31_35C,
            int? RatedСurrent_IP31_40C,
            int? RatedСurrent_IP31_45C,
            int? RatedСurrent_IP31_50C,
            int? RatedСurrent_IP31_55C,
            int? RatedСurrent_IP41_35C,
            int? RatedСurrent_IP41_40C,
            int? RatedСurrent_IP41_45C,
            int? RatedСurrent_IP41_50C,
            int? RatedСurrent_IP41_55C)
        {
            this.Name = Name;
            this.RatedСurrent_IP31_35C = RatedСurrent_IP31_35C;
            this.RatedСurrent_IP31_40C = RatedСurrent_IP31_40C;
            this.RatedСurrent_IP31_45C = RatedСurrent_IP31_45C;
            this.RatedСurrent_IP31_50C = RatedСurrent_IP31_50C;
            this.RatedСurrent_IP31_55C = RatedСurrent_IP31_55C;
            this.RatedСurrent_IP41_35C = RatedСurrent_IP41_35C;
            this.RatedСurrent_IP41_40C = RatedСurrent_IP41_40C;
            this.RatedСurrent_IP41_45C = RatedСurrent_IP41_45C;
            this.RatedСurrent_IP41_50C = RatedСurrent_IP41_50C;
            this.RatedСurrent_IP41_55C = RatedСurrent_IP41_55C;
        }
    }
}
