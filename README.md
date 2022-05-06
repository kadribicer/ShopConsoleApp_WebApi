<h2>The Retail Store Discounts</h2>
<details>
  <summary>Expand for detail</summary>
<br>
  
-	If the user is an employee of the store, he gets a 30% discount
-	If the user is an affiliate of the store, he gets a 10% discount
- If the user has been a customer for over 2 years, he gets a 5% discount.
-	For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount).
-	The percentage based discounts do not apply on groceries.
-	A user can get only one of the percentage based discounts on a bill.
- Create a RESTful API that returns the final invoice amount including discount when an invoice is issued.

</details>

#
<h3>Instructions and General Information</h3>
  
It is a small console application created to simulate store discounts. Used technologies.

- .NET Console Application
- .NET Class Libraries
- RESTful API - Asp .NET Core

#
<h3>Materials used for the test</h3>

- XUnit Unit tests
- SonarQube (Screenshot added)
- Postman (API Tests) (Screenshot added.)
- Swagger (API Tests) (Screenshot added.)
- VS Code Analyzer

#
<h3>General Information regarding the solution</h3>

- You can run the project by following the Visual Studio or debug/release path.
- You can run unit tests with the Visual Studio test explorer.
- Informative notes regarding the methods have been written in the application.

#
<h3>API Endpoint</h3>

- Http Method - GET
- Endpoint - https://localhost:7288/GetInvoices

Example request

```
{
  "totalPrice": 549,
  "groceryPrice": 44,
  "otherPrice": 505,
  "discountPrice": 166.5,
  "finalPrice": 382.5
}
```

Net amount payable
```
382.5
```

The net amount to be paid is calculated according to the discount rates given in the scenario and the users.

#

<h3>Other Information</h3>


- The given scenario was developed not only as a console application but also as a web application.
- You can access the web application from the link here. [Web Application](https://github.com/kadribicer/ShopWebApp_WebApi).
