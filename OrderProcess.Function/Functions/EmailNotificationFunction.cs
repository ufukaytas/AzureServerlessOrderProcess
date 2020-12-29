using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderProcess.Function.Models;

namespace OrderProcess.Function.Functions
{
    public  class EmailNotificationFunction
    {

        [FunctionName("EmailNotificationFunction")]
        public void Run(
            [ServiceBusTrigger("notificationtopic", "emailnotification", Connection = "ServiceBusConnection")] string message, ILogger log)
        {
            log.LogInformation("EMail Notification function processed a request.");

            Order order = JsonConvert.DeserializeObject<Order>(message);

            // Logic  Send Email
             
        }
    }
}
