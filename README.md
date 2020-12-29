# Azure Serverless Order Process


# Project Overview:
 
 ![Screenshot](/docs/azurefunctions.png)


#  Workflow will be as below.
1. The user creates an order in the E-Commerce system.
2. The order comes to the Order Function through different channels (Website, Mobile App, etc.).
3. Order information is written in the Order Table in Storage Account.
4. The message is transmitted to the Service Bus so that the order details can be sent as a notification.
5. Subscribers read the message received by Azure Service Bus Topic (SMS Notification and EMail Notification) and send the result of the order as a notification.

# Prerequisites

* Azure Subscription with Azure Service Bus Queue.
* VS 2019

# Requires
1. Connection string to the Azure Service Bus should have Listen-and-read access role 
2. You need to create a Topic to send  message for Notification. 
3. You need to create a Table as a "Order" in Storage Account.
