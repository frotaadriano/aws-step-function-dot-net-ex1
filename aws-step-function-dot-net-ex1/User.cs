namespace aws_step_function_dot_net_ex1
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Balance { get; set; }

        public string Email { get; set; }

        public decimal GetUserBalance(int ID)
        {
            return 1000;
        }
    }
}