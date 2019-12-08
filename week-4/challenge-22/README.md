# Challenge 22: Winter Solstice &ndash; Protect Secrets from Grim Reaper!

![porridge](https://res.cloudinary.com/jen-looper/image/upload/v1575489111/images/challenge-22_glk8t3.jpg)

Welcome to Korea in this festive season! It's Winter Solstice today. Traditionally in Korea, it's the day that many grim reapers are seeking for young kids to take their souls. But they won't be able to find out our children who eat red-bean porridge before going to sleep.

![porridge](red-bean-porridge.png)

Oh no! Cheol-soo missed the porridge tonight. He's in danger to get caught by the grim reaper! We need to keep him in a safe place and lock the door until the next day; the Sun is rising. His best friend Young-hee locked the door and got the secret code to open it. Then she managed to store the secret into Azure Key Vault, but how smart the grim reaper is!!

The grim reaper is trying to destroy the Key Vault so that Cheol-soo can't get out of the safe place forever! If Young-hee can't find out how to backup and restore the Key Vault, he will die in there!

She needs to back it up before the grim reaper destroys it. And she also needs to restore it even if the grim reaper demolishes the Key Vault. How can we help Young-hee backup and restore Key Vault secret?

## Resources/Tools Used 🚀

### Common

-   **[Postman](https://www.getpostman.com/downloads/)**
-   **[PowerShell Core](https://docs.microsoft.com/powershell/scripting/install/installing-powershell?view=powershell-6&WT.mc_id=25daysofserverless-github-cxa)**
-   **[PowerShell Module for Azure](https://docs.microsoft.com/powershell/azure/install-az-ps?view=azps-3.1.0&WT.mc_id=25daysofserverless-github-cxa)**
-   **[Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest&WT.mc_id=25daysofserverless-github-cxa)**
-   **[Azurite (Blob Storage Emulator)](https://docs.microsoft.com/azure/storage/common/storage-use-azurite?WT.mc_id=25daysofserverless-github-cxa)**
-   **[Azure Functions Core Tools](https://docs.microsoft.com/azure/azure-functions/functions-run-local?WT.mc_id=25daysofserverless-github-cxa)**

### Windows

-   **[Visual Studio Community](https://visualstudio.microsoft.com/vs/?WT.mc_id=25daysofserverless-github-cxa)**
-   **[Azure Functions and Web Jobs Tools Extension](https://marketplace.visualstudio.com/items?itemName=VisualStudioWebandAzureTools.AzureFunctionsandWebJobsTools&WT.mc_id=25daysofserverless-github-cxa)**

### Mac/Linux

-   **[Visual Studio Code](https://code.visualstudio.com/?WT.mc_id=25daysofserverless-github-cxa)**
-   **[Azure Functions Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions&WT.mc_id=25daysofserverless-github-cxa)**

## Getting Started 🔥

In order to run Azurite to emulate Blob Storage locally, you need to follow a few steps below:

1. Run Azurite

```bash
> mkdir ~/azurite
> azurite --silent --location ~/azurite --debug ~/azurite/debug.log
```

In order to run the function app locally with the Managed Identity feature enabled, you need to follow a few steps below:

1. Login to Azure using Azure CLI

```bash
> az login
```

2. Run the function app

```bash
> func host start
```

## Next Steps 🏃

Learn more about serverless with a Free Training!

-   ✅ **[Serverless Free Courses](https://docs.microsoft.com/learn/browse/?term=azure%20functions&WT.mc_id=25daysofserverless-github-cxa)**

## Important Resources ⭐️

-   ✅ **[Azure Functions documentation](https://docs.microsoft.com/azure/azure-functions/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Azure Key Vault documentation](https://docs.microsoft.com/azure/key-vault/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Managed Identities for Azure Resources documentation](https://docs.microsoft.com/azure/active-directory/managed-identities-azure-resources/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Azure SDK for JavaScript Documentation](https://docs.microsoft.com/azure/javascript/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Azure SDK for Java Documentation](https://docs.microsoft.com/azure/java/?view=azure-java-stable&WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Azure SDK for Python Documentation](https://docs.microsoft.com/azure/python/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Azure SDK for .NET/.NET Core Documentation](https://docs.microsoft.com/dotnet/azure/?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Create your first function using Visual Studio Code](https://docs.microsoft.com/azure/azure-functions/functions-create-first-function-vs-code?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Create your first function using Visual Studio](https://docs.microsoft.com/azure/azure-functions/functions-create-your-first-function-visual-studio?WT.mc_id=25daysofserverless-github-cxa)**
-   ✅ **[Free E-Book - Azure Serverless Computing Cookbook, Second Edition](https://azure.microsoft.com/resources/azure-serverless-computing-cookbook/?WT.mc_id=25daysofserverless-github-cxa)**

## Questions? Comments? ❓

If you have any doubts about the challenges, feel free to open an **[ISSUE HERE](https://github.com/simonaco/serverless-challenges/issues)**. As soon as possible we will be answering any questions/doubts that you may have!
