using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderProcess.Function.Models;
using Microsoft.Azure.WebJobs.ServiceBus;
using OrderProcess.Function.Dto;

namespace OrderProcess.Function.Functions
{
    public class OrderFunction
    {
        [FunctionName("OrderFunction")]
        public async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] OrderRequest orderRequest,
                [Table("Order", Connection = "AzureWebJobsStorage")] IAsyncCollector<Order> outputOrder,
                [ServiceBus("notificationtopic", Connection = "ServiceBusConnection", EntityType = EntityType.Topic)]IAsyncCollector<string> queueOrder, 
                ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var order = new Order
            {
                // Entity'leri Email'ler ile gruplamak için PartitionKey'lere Email bilgisi setleniyor.
                PartitionKey = orderRequest.EMail, 
                Price = orderRequest.Price,
                ProductName = orderRequest.ProductName,
                EMail = orderRequest.EMail,
                PhoneNumber = orderRequest.PhoneNumber
            };

            await outputOrder.AddAsync(order);

            await queueOrder.AddAsync(JsonConvert.SerializeObject(order));


            return new OkObjectResult(order);
        }
    }
}
