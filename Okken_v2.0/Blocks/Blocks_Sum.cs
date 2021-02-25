using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    /// <summary>
    /// Суммарный класс блоков
    /// </summary>
    public class Blocks_Sum
    {
        public IBlock block { get; set; }
        public int NumOfBlock { get; set; }
        public double SumPrice { get; set; }

        public Blocks_Sum(IBlock dF_block, int NumOfBlock)
        {
            this.block = dF_block;
            this.NumOfBlock = NumOfBlock;

            SumPrice = (double)dF_block.PriceOfUnit * NumOfBlock;
        }
    }
}
