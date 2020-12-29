using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderProcess.Function.Models;


namespace OrderProcess.Function.Functions
{
    public class SmsNotificationFunction
    {

        [FunctionName("SmsNotificationFunction")]
        public void Run(
           [ServiceBusTrigger("notificationtopic", "smsnotification", Connection = "ServiceBusConnection")] string message, ILogger log)
        {
            log.LogInformation("Sms Notification function processed a request.");

            Order order = JsonConvert.DeserializeObject<Order>(message);

            // Logic Send SMS 


        }


    }
}
