# PizzaOrderApp
A simple Pizza ordering application to showcase skills with Microsoft Azure resources.

Orders come through servicebus message (manual)
Function receives order message (servicebus trigger)
Function processes received order (data manipulation)
Function sends processed order to WebApp (HttpClient)
WebApp Controller receives order calls (HTTP GET)
WebApp validates received object (Validation)
WebApp creates pizza order on Web App (Output)
