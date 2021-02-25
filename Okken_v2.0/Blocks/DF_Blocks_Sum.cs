using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public class DF_Blocks_Sum
    {
        public DF_Block dF_block { get; set; }
        public int NumOfBlock { get; set; }
        public double SumPrice { get; set; }

        public DF_Blocks_Sum(DF_Block dF_block, int NumOfBlock)
        {
            this.dF_block = dF_block;
            this.NumOfBlock = NumOfBlock;

            SumPrice = (double)dF_block.PriceOfUnit * NumOfBlock;
        }
    }
}
