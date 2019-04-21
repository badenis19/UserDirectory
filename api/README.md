# User API
This is a boilerplate .net core project which implements a simple API.

When running `dotnet run` from the `src` directory, an application is started on the local machine which listens on `http://localhost:5000` and returns a `200` HTTP response when making a `POST /api/users` HTTP request.

Starting from the boilerplate project, complete the following tasks.

## Tasks
#### Implement `POST /api/users` to create new users
* Only one user per request can be created 
* The user model is sent in the body as a json string and it needs to have email and password
* If the user model is valid, it is saved in a user list on the local file system for simplicity
* If the user model is not valid, the response has HTTP `400` status code and a body with a json error model specifying what validation rule is not met
* The user model is valid if
    * email is not empty
    * email contains the `@` character
    * password is at least 8 characters
    * password contains one upper-case letter, one lower-case letter, one digit and one special character

#### Implement `GET /api/users` to fetch a list of existing saved users
* A paginated list of users is returned in a json string
* The endpoint accepts the following parameters in the query string:
    * `page={number}`, to specify the page number
    * `pageSize={size}`, to specify the page size
    * `orderBy={alphabeticalAsc/alphabeticalDesc/creationDateAsc/creationDateDesc}` to order the list alphabetically or by creation date (ascending or descending order)

#### Write unit and acceptance tests
* Write unit tests to test classes in isolation
* Write at least one acceptance test per endpoint to validate the implementation against the application running on the local machine
