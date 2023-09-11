
# KillBills - SDK (C#)

The main purpose of this Software Development Kit (SDK) is to facilitate the integration of KillBills' services into C# applications. The SDK will act as an intermediary layer, allowing developers to communicate with the KillBills API and access its features in a straightforward manner. By providing a consistent and easy-to-use interface, the SDK aims to simplify & speed up the process of integrating KillBills' services into C# applications.



# Dependencies

## Features

- getStores : The method getStores returns a list of killbills integrated stores as an array of objects with relevant properties.
- sendTransaction : The method sendTransaction validates and send transaction to the killbills gate transaction.
- sendReceipt : The method sendReceipt validates and send a receipt to the killbills gate receipt.




## Usage/Examples
#### Installation:
```shell
   dotnet add KillBills_SDK
```
#### Import:
Add to your .csproj file
```xml
<ItemGroup>
  <PackageReference Include="KillBills_SDK" Version="0.0.1" />
</ItemGroup>
```
Import in your project 
```csharp
    var sdk = new KillBills_Sdk();
```
#### Method getStores :
```csharp
    var sdk = new KillBills_Sdk();
    var result = sdk.GetStores('prod','your-api-key');
    Console.WriteLine(result);
```
##### Output:
```yaml
[
  {
    "id": "id",
    "billing_descriptor": "store billing descriptor",
    "store_name": "store name",
    "merchant_name": "merchant name",
    "full_address": "00 street, 00000, city",
    "siret": 00000000000000
  },
   {
    "id": "id",
    "billing_descriptor": "store billing descriptor",
    "store_name": "store name",
    "merchant_name": "merchant name",
    "full_address": "00 street, 00000, city",
    "siret": 00000000000000
  },
  //...other results
]
```
# 
#### Method sendTransaction :

##### note that the transactionData object only contains minimal required values see (insert link to all possibilities)
```csharp
 string env = "prod";
    TransactionDto transactionData = new()
    {
        ...yourPayloadData
    };
        
    string hmacKey = "your-hmac-key";
    string result = await sdk.SendTransactionAsync(env, transactionData, hmacKey);

    Console.WriteLine($"Résultat: {result}");
```
##### Output: 
```yaml
{
"status": "success",
"message": "published to gate transaction",
"messageId": "xxxxxxxxxxxxxxxxx",
"previewLink": "https://banks.killbills.co/payloads/xxxxxxxxxxxxxxxxx"
}
```
# 
#### Method sendReceipt :
##### note that the receiptData object only contains minimal required values see (insert link to all possibilities)
```csharp
    string env = "prod";
    ReceiptDto receiptData = new()
    {
        ...yourPayloadData
    };
        
    string hmacKey = "your-hmac-key";
    string result = await sdk.SendReceipt(env, receiptData, hmacKey);

    Console.WriteLine($"Résultat: {result}");

```
##### Output: 
```yaml
{
"status": "success",
"message": "published to gate receipt",
"messageId": "xxxxxxxxxxxxxxxxx",
"previewLink": "https://merchants.killbills.co/payloads/xxxxxxxxxxxxxxxxx"
}
```

## Transaction & Receipt Architecture

#### TRANSACTION :
```csharp
TransactionDto transactionData = new()
{
    BankId = "", // string (36 caractères uuid)
    CallbackUrl = "", // string url
    PartnerName = "", // string
    ReceiptFormat = "", // string ('json', 'pdf', 'svg', 'png')
    Transaction = new TransactionDetailDto {
        ReferenceId = "", // string
        Amount = , // number
        CustomerId = "", // string
        TransactionDate = "", // date (au format chaîne de caractères)
        StoreName = "", // string ou vide
        BillingDescriptor = "", // string
        Siret = "", // string ou vide
        Payment = new PaymentDto {
            Bin = "",
            LastFour = "",
            AuthCode = "",
            Scheme = "",
            TransactionId = "",
        }, 
        Currency = "", // string ou vide
        PosName = "", // string ou vide
        MerchantName = "" // string ou vide
    }
};
```
#### RECEIPT :
```csharp
ReceiptDto receiptData = new() 
{
    ReferenceId = "", // string (alphanumérique)
    Amount = 0, // number
    TotalTaxAmount = "", // number ou vide
    Currency = "", // string ('EUR' ou 'USD')
    Date = "", // string (au format 'YYYY-MM-DDTHH:mm:ss')
    Covers = 0, // number ou vide
    Table = "", // string ou vide
    Invoice = 0, // number ou vide
    TotalDiscount = 0, // number ou vide
    Mode = 0, // number ou vide
    PartnerName = "", // string
    Merchant = new Merchant {
        MerchantName = "", // string ou vide
        ReferenceId = "", // string (required)
        MerchantId = 0 // number ou vide
    },
    Store = new Store {
        StoreName = "", // string
        ReferenceId = "", // string
        BillingDescriptor = "", // string
        Siret = "", // string (14 caractères)
        CodeApe = "", // string ou vide
        TvaIntra = "", // string ou vide
        Address = {
            PostalCode = 0, // number
            StreetAddress = "", // string ou vide
            Country = "", // string ou vide
            City = "", // string ou vide
            FullAddress = "", // string ou vide
            Number = 0 // number ou vide
        }
    },
    Taxes = new List<Tax> [{ 
        Description = "", // string ou vide
        Amount = 0, // number
        Rate = 550 // number (550, 1000 ou 2000) ou vide
    }],
    Items = new List<Item> [{
        ReferenceId = "", // string ou vide
        Name = "", // string
        Description = "", // string ou vide
        Type = "", // string ou vide
        Quantity = 0, // number
        Price = 0, // number
        Discount = 0, // number ou vide
        TotalAmount = 0, // number ou vide
        Tax = new Tax {
            Description = "", // string ou vide
            Amount = 0, // number
            Rate = 550 // number (550, 1000 ou 2000) ou vide
        },
        Subitems = [{
            ReferenceId = "", // string ou vide
            Name = "", // string
            Description = "", // string ou vide
            Quantity = 0, // number ou vide
            Price = 0, // number ou vide
            Discount = 0, // number ou vide
            TotalAmount = 0, // number ou vide
            Tax = {
                Description = "", // string ou vide
                Amount = 0, // number
                Rate = 550 // number (550, 1000 ou 2000) ou vide
            }
        }]
    }],
    Payments = [{
        Bin = "", // string ou vide
        LastFour = "", // string ou vide
        AuthCode = "", // string ou vide
        Scheme = "", // string ou vide
        Amount = 0, // number
        TransactionDate = "", // string (au format 'YYYY-MM-DDTHH:mm:ss')
        TransactionId = "", // string ou vide
        PaymentType = "" // string ou vide
    }]
};
```

## Run Locally

Clone the project

```bash
  git clone https://github.com/killbillsdev/c-sharp-sdk
```

Go to the project directory

```bash
  cd c-sharp-sdk
```

Install dependencies
```bash
make
```



## Running Tests

To run tests, run the following command

```bash
make test
```


## Feedback / Feature request

If you have any feedback, please reach out to us at contact@killbills.co
## License

[MIT](https://choosealicense.com/licenses/mit/) [![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


