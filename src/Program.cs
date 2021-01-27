using System;
using Azure.Communication;
using Azure.Communication.Sms;

namespace SmsQuickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            // ref: https://docs.microsoft.com/en-us/azure/communication-services/quickstarts/telephony-sms/send?pivots=programming-language-csharp
            // ref: https://github.com/Azure-Samples/communication-services-dotnet-quickstarts/blob/main/SendSMS/Program.cs
            
            // smsConnectionString: you get this info from the key of "Connection string" of your Communication service in the Azure portal 
            // setx COMMUNICATION_SERVICES_CONNECTION_STRING "<connection string ofyour Communication service>", e.g.,
            // setx COMMUNICATION_SERVICES_CONNECTION_STRING "endpoint=https://xyz.communication.azure.com/;accesskey=asfsaasasfasfawrewqrwerw+oFS61OVhUiv3T+etretudfdsgfsdgdsgfsgsddsf=="
            // run the above command to store the connection string in the environment variable
            Console.WriteLine("This is the SMS test.");

            //fetch your connection string from an environment variable.
            string smsConnectionString = Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");
            
            SmsClient smsClient = new SmsClient(smsConnectionString);

            var response = smsClient.Send(
                from: new PhoneNumber("+18008887777"),  // Acquire phone number on your Azure Communication resource
                to: new PhoneNumber("+17778887878"),     // the phone number to which you want to send SMS.
                message: "Hello 👋🏻 SMS from the quickstart at "+DateTime.Now.ToString("o"),  //the SMS message
                new SendSmsOptions { EnableDeliveryReport = true } // optional, ref: https://docs.microsoft.com/en-us/dotnet/api/azure.communication.sms.sendsmsoptions?view=azure-dotnet-preview
            );

            Console.WriteLine($"Message id {response.Value.MessageId}");           
        }
    }
}
