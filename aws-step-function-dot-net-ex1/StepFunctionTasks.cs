using Amazon.Lambda.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
// [assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

[assembly: Amazon.Lambda.Core.LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

//[assembly: LambdaSerializer(typeof(JsonSerializer))]
//[assembly: Amazon.Lambda.Core.LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace aws_step_function_dot_net_ex1
{
    public class StepFunctionTasks
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public StepFunctionTasks()
        {
        }

        /*
         user buy a stock

         */

        public State BuyStocksFillData(JObject state, ILambdaContext context)
        {
            var myDeserializedClass = JsonConvert.DeserializeObject<State>(state.ToString());

            var _state = JsonConvert.DeserializeObject<State>(state.ToString());

            _state.HasCredit = false;
            _state.User.Balance = _state.User.GetUserBalance(_state.User.ID);
            _state.FailureMessages = new Failure();
            _state.FailureMessages.User = _state.User;
            return _state;
        }

        public State Validations(State state, ILambdaContext context)
        {
            if (string.IsNullOrEmpty(state.Stock.Name))
            {
                state.FailureMessages.Messages.Add(
                    "Stock Name not found!");
            }

            if (state.Stock.Quantity <= 0)
            {
                state.FailureMessages.Messages.Add("Please Input a value greater than 0");
            }

            var stocksToBuyAmount = state.Stock.Price * state.Stock.Quantity;

            if (stocksToBuyAmount < state.User.Balance)
            {
                state.FailureMessages.Messages.Add("Insuficient credits to do this operation!");
            }

            if (state.FailureMessages.Messages.Count > 0)
            {
                return state;
            }

            return state;
        }

        public void FailueOperation(State state, ILambdaContext context)
        {
            string msgs = string.Join(" , ", state.FailureMessages.Messages.Select(x => x));

            context.Logger.Log($"erro: {msgs}");
        }

        public State ProceedToBuy(State state, ILambdaContext context)
        {
            return state;
        }

        public void SendConfirmation(State state, ILambdaContext context)
        {
            context.Logger.Log($"Confirmation sent!");
        }

        public class Root
        {
            public User User { get; set; }
            public Stock Stock { get; set; }
        }
    }
}