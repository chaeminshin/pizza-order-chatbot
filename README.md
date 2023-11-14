----------------------------------------------------------------------------
Pizza Order Chatbot

* Logic
PizzaOrder/OrderBot/Order.cs

* Database Connection
PizzaOrder/OrderBot/PizzaData.cs

* Database File
PizzaOrder/Pizza.db
----------------------------------------------------------------------------
* Run Chatbot Command
PizzaOrder> dotnet run --project OrderBotPage

* Chatbot URL
http://localhost:5000/

* Run Unit Test Command
PizzaOrder> dotnet test

* Generate Coverage Reports
reportgenerator -reports:.\Orderbot.tests\TestResults\7f7c9963-bf4f-4344-b473-9daf2cffe08b\coverage.cobertura.xml -targetdir:coveragereport -reporttypes:Html

* Coverage Report
PizzaOrder/coveragereport/index.html