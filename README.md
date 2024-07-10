TopUpPhone API
Overview
TopUpPhone API is a service that allows users to manage their balance, perform top-ups, and manage beneficiaries. It is built using ASP.NET Core and uses an InMemory database for demonstration purposes. The API supports Hypermedia as the Engine of Application State (HATEOAS) for easy navigation between resources.

Endpoints
User Endpoints
Get User By Id

URL: /api/user/{id}
Method: GET
Description: Retrieves a user by their ID.
Response:
json
Copy code
{
  "id": 1,
  "userName": "string",
  "status": "active",
  "isVerified": true,
  "balance": 1000,
  "links": [
    {
      "href": "http://localhost:5000/api/user/1",
      "rel": "self",
      "method": "GET"
    },
    {
      "href": "http://localhost:5000/api/beneficiary/user/1",
      "rel": "user-beneficiaries",
      "method": "GET"
    }
  ]
}
Create User

URL: /api/user/create
Method: POST
Description: Creates a new user.
Request Body:
json
Copy code
{
  "name": "string",
  "balance": 1000,
  "status": "active"
}
Response:
json
Copy code
{
  "message": "USER_CREATED_WITH_SUCCESS: 1",
  "data": {
    "id": 1,
    "userName": "string",
    "status": "active",
    "isVerified": false,
    "balance": 1000,
    "links": [...]
  }
}
Update User Verification Status

URL: /api/user/verify-user
Method: PATCH
Description: Updates the verification status of a user.
Request Body:
json
Copy code
{
  "isVerified": true
}
Increment User Balance

URL: /api/user/increment-balance
Method: PATCH
Description: Increments the balance of a user.
Request Body:
json
Copy code
{
  "amount": 500
}
Beneficiary Endpoints
Get Beneficiary By Id

URL: /api/beneficiary/{id}
Method: GET
Description: Retrieves a beneficiary by their ID.
Get Beneficiaries By User Id

URL: /api/beneficiary/user/{id}
Method: GET
Description: Retrieves all beneficiaries associated with a user.
Create Beneficiary

URL: /api/beneficiary/create
Method: POST
Description: Creates a new beneficiary.
Request Body:
json
Copy code
{
  "nickname": "string",
  "status": "active",
  "phoneNumber": "string",
  "userId": 1
}
Response:
json
Copy code
{
  "message": "BENEFICIARY_CREATED_WITH_SUCCESS: 1",
  "data": {
    "id": 1,
    "nickname": "string",
    "status": "active",
    "phoneNumber": "string",
    "userId": 1,
    "links": [...]
  }
}
Update Beneficiary

URL: /api/beneficiary/update
Method: PUT
Description: Updates an existing beneficiary.
Top-Up Item Endpoints
Get Top-Up Item By Id

URL: /api/topupitem/{id}
Method: GET
Description: Retrieves a top-up item by its ID.
Get All Top-Up Items

URL: /api/topupitem/all
Method: GET
Description: Retrieves all top-up items.
Create Top-Up Item

URL: /api/topupitem/create
Method: POST
Description: Creates a new top-up item.
Request Body:
json
Copy code
{
  "description": "string",
  "amount": 10,
  "transactionFee": 1,
  "status": "active"
}
Update Top-Up Item Status

URL: /api/topupitem/update-status
Method: PATCH
Description: Updates the status of a top-up item.
Request Body:
json
Copy code
{
  "status": "inactive"
}
Transaction Endpoints
Create Transaction

URL: /api/transaction/create
Method: POST
Description: Creates a new transaction.
Request Body:
json
Copy code
{
  "userId": 1,
  "beneficiaryId": 1,
  "topUpItemId": 1
}
Validation Rules
User Verification:

A user must be verified (isVerified = true) to perform certain actions.
Non-verified users have a limit of 500 in total top-ups per beneficiary per month.
Verified users have a limit of 1000 in total top-ups per beneficiary per month.
A user can perform a total of 3000 in top-ups across all beneficiaries per month.
Beneficiary:

Each user can have a maximum of 5 active beneficiaries.
The status of a beneficiary must be either active or inactive.
Top-Up Item:

The status of a top-up item must be either active or inactive.
Transactions:

A user can only perform transactions for beneficiaries associated with them.
The user's balance must be sufficient to cover the transaction amount and fee.
Hyperlinks (HATEOAS)
The API responses include hyperlinks to relevant resources to facilitate easy navigation between them.

