# FoodaryTest 
Tools Used:  .Net Core 2.0, EF core 2.0, SQL Server, Swagger, VS2017,MS Tests, Moq

Steps to run the API
---------------------
1. Change the instance name in the  connection string "DBConnection" in appsettings.json. The database need not to be there and it will be created and seeded with initial data on the first run automatically by EF Core Code first approach.

2. Build the API in Visual Studio 2017 or higher and run. The first run will take a while, as it creates and seeds data.

3. Use Swagger screen to run the Calculate method. The below is the sample request.

{
   "CustomerId":"8e4e8991-aaee-495b-9f24-52d5d0e509c5",
   "LoyaltyCard":"CTX0000001",
   "TransactionDate":"06-Jan-2020",
   "Basket":[
      {
         "ProductId":"PRD01",
         "UnitPrice":"1.2",
         "Quantity":"3"
      },
      {
         "ProductId":"PRD02",
         "UnitPrice":"2.0",
         "Quantity":"2"
      },
      {
         "ProductId":"PRD03",
         "UnitPrice":"5.0",
         "Quantity":"1"
      }
   ]
}
 
