using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //string subscriptionId = "2da1e32a-7e3a-4497-98eb-7fa16a244301";
        string resourceGroupName = "my-sdk-rg";
        //string storageAccountName = "helloworld789809vs";
        
        //AzureLocation location = AzureLocation.WestUS2;
        string location = "westus";

        var credential = new DefaultAzureCredential();

        var armClient = new ArmClient(credential);

        SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(Azure.WaitUntil.Completed, resourceGroupName, resourceGroupData);



        Console.WriteLine("Resource Group created successfully.");
    }
}