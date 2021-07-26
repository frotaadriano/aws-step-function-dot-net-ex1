using System.Collections.Generic;

namespace aws_step_function_dot_net_ex1
{
    public class UserBalance
    {
        public decimal?  Amount{ get; set; }
        public List<Stock> StockList { get; set; }
    }
}