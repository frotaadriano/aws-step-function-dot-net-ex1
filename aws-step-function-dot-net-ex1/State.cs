using System;
using System.Collections.Generic;
using System.Text;

namespace aws_step_function_dot_net_ex1
{
    /// <summary>
    /// The state passed between the step function executions.
    /// </summary>
    public class State
    {
        public User User { get; set; }

        public Stock Stock { get; set; }


        public UserBalance UserBalance { get; set; }

        public Failure FailureMessages { get; set; }

        public bool HasCredit { get; set; }

        public bool OperationComplete { get; set; }

    }
}
