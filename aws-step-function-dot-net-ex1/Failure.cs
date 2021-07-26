using System.Collections.Generic;

namespace aws_step_function_dot_net_ex1
{
    public class Failure
    {
        public User User {get; set; }
        public  List<string> Messages  { get; set; }
    }
}