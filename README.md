# PizzaOrderApp
A simple Pizza ordering application to showcase skills with Microsoft Azure resources.

1. Orders come through servicebus message (manual)
2. Function receives order message (servicebus trigger)
3. Function processes received order (data manipulation)
4. Function sends processed order to WebApp (HttpClient)
5. WebApp Controller receives order calls (HTTP GET)
6. WebApp validates received object (Validation)
7. WebApp creates pizza order on Web App (Output)
