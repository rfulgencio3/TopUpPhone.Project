<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>

<h1>TopUpPhone API</h1>

<h2>Overview</h2>
<p>TopUpPhone API is a service that allows users to manage their balance, perform top-ups, and manage beneficiaries. It is built using ASP.NET Core and uses an InMemory database for demonstration purposes. The API supports Hypermedia as the Engine of Application State (HATEOAS) for easy navigation between resources.</p>

<h2>Endpoints</h2>

<h3>User Endpoints</h3>

<ul>
    <li><strong>Get User By Id</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/user/{id}</code></li>
            <li><strong>Method:</strong> <code>GET</code></li>
            <li><strong>Description:</strong> Retrieves a user by their ID.</li>
            <li><strong>Response:</strong>
                <pre><code>{
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
}</code></pre>
            </li>
        </ul>
    </li>
    <li><strong>Create User</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/user/create</code></li>
            <li><strong>Method:</strong> <code>POST</code></li>
            <li><strong>Description:</strong> Creates a new user.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "name": "string",
    "balance": 1000,
    "status": "active"
}</code></pre>
            </li>
            <li><strong>Response:</strong>
                <pre><code>{
    "message": "USER_CREATED_WITH_SUCCESS: 1",
    "data": {
        "id": 1,
        "userName": "string",
        "status": "active",
        "isVerified": false,
        "balance": 1000,
        "links": [...]
    }
}</code></pre>
            </li>
        </ul>
    </li>
    <li><strong>Update User Verification Status</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/user/verify-user</code></li>
            <li><strong>Method:</strong> <code>PATCH</code></li>
            <li><strong>Description:</strong> Updates the verification status of a user.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "isVerified": true
}</code></pre>
            </li>
        </ul>
    </li>
    <li><strong>Increment User Balance</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/user/increment-balance</code></li>
            <li><strong>Method:</strong> <code>PATCH</code></li>
            <li><strong>Description:</strong> Increments the balance of a user.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "amount": 500
}</code></pre>
            </li>
        </ul>
    </li>
</ul>

<h3>Beneficiary Endpoints</h3>

<ul>
    <li><strong>Get Beneficiary By Id</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/beneficiary/{id}</code></li>
            <li><strong>Method:</strong> <code>GET</code></li>
            <li><strong>Description:</strong> Retrieves a beneficiary by their ID.</li>
        </ul>
    </li>
    <li><strong>Get Beneficiaries By User Id</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/beneficiary/user/{id}</code></li>
            <li><strong>Method:</strong> <code>GET</code></li>
            <li><strong>Description:</strong> Retrieves all beneficiaries associated with a user.</li>
        </ul>
    </li>
    <li><strong>Create Beneficiary</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/beneficiary/create</code></li>
            <li><strong>Method:</strong> <code>POST</code></li>
            <li><strong>Description:</strong> Creates a new beneficiary.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "nickname": "string",
    "status": "active",
    "phoneNumber": "string",
    "userId": 1
}</code></pre>
            </li>
            <li><strong>Response:</strong>
                <pre><code>{
    "message": "BENEFICIARY_CREATED_WITH_SUCCESS: 1",
    "data": {
        "id": 1,
        "nickname": "string",
        "status": "active",
        "phoneNumber": "string",
        "userId": 1,
        "links": [...]
    }
}</code></pre>
            </li>
        </ul>
    </li>
    <li><strong>Update Beneficiary</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/beneficiary/update</code></li>
            <li><strong>Method:</strong> <code>PUT</code></li>
            <li><strong>Description:</strong> Updates an existing beneficiary.</li>
        </ul>
    </li>
</ul>

<h3>Top-Up Item Endpoints</h3>

<ul>
    <li><strong>Get Top-Up Item By Id</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/topupitem/{id}</code></li>
            <li><strong>Method:</strong> <code>GET</code></li>
            <li><strong>Description:</strong> Retrieves a top-up item by its ID.</li>
        </ul>
    </li>
    <li><strong>Get All Top-Up Items</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/topupitem/all</code></li>
            <li><strong>Method:</strong> <code>GET</code></li>
            <li><strong>Description:</strong> Retrieves all top-up items.</li>
        </ul>
    </li>
    <li><strong>Create Top-Up Item</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/topupitem/create</code></li>
            <li><strong>Method:</strong> <code>POST</code></li>
            <li><strong>Description:</strong> Creates a new top-up item.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "description": "string",
    "amount": 10,
    "transactionFee": 1,
    "status": "active"
}</code></pre>
            </li>
        </ul>
    </li>
    <li><strong>Update Top-Up Item Status</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/topupitem/update-status</code></li>
            <li><strong>Method:</strong> <code>PATCH</code></li>
            <li><strong>Description:</strong> Updates the status of a top-up item.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "status": "inactive"
}</code></pre>
            </li>
        </ul>
    </li>
</ul>

<h3>Transaction Endpoints</h3>

<ul>
    <li><strong>Create Transaction</strong>
        <ul>
            <li><strong>URL:</strong> <code>/api/transaction/create</code></li>
            <li><strong>Method:</strong> <code>POST</code></li>
            <li><strong>Description:</strong> Creates a new transaction.</li>
            <li><strong>Request Body:</strong>
                <pre><code>{
    "userId": 1,
    "beneficiaryId": 1,
    "topUpItemId": 1
}</code></pre>
            </li>
        </ul>
    </li>
</ul>

<h2>Validation Rules</h2>

<ol>
    <li><strong>User Verification:</strong>
        <ul>
            <li>A user must be verified (<code>isVerified = true</code>) to perform certain actions.</li>
            <li>Non-verified users have a limit of 500 in total top-ups per beneficiary per month.</li>
            <li>Verified users have a limit of 1000 in total top-ups per beneficiary per month.</li>
            <li>A user can perform a total of 3000 in top-ups across all beneficiaries per month.</li>
        </ul>
    </li>
    <li><strong>Beneficiary:</strong>
        <ul>
            <li>Each user can have a maximum of 5 active beneficiaries.</li>
            <li>The <code>status</code> of a beneficiary must be either <code>active</code> or <code>inactive</code>.</li>
        </ul>
    </li>
    <li><strong>Top-Up Item:</strong>
        <ul>
            <li>The <code>status</code> of a top-up item must be either <code>active</code> or <code>inactive</code>.</li>
        </ul>
    </li>
    <li><strong>Transactions:</strong>
        <ul>
            <li>A user can only perform transactions for beneficiaries associated with them.</li>
            <li>The user's balance must be sufficient to cover the transaction amount and fee.</li>
        </ul>
    </li>
</ol>

<h2>Hyperlinks (HATEOAS)</h2>
<p>The API responses include hyperlinks to relevant resources to facilitate easy navigation between them.</p>

</body>
</html>
