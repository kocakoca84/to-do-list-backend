# to-do-list-backend
* I've spent about 5h on the solution
* The backend (this) solution was written in Visual Studio 2019. It should build and run out-of-the-box.
* Picked the design that i use in everyday job
* Spent most of the time figuring out why does WebAPI turn controllers' input argument into nulls. 
Turned out that it handles primitive types differently, hence I've passed in a complex type (ToDoTask). Also, spent some time with problem with CORS.
In the next iteration, I would set the return type to be a complex type (ToDoTask) and handle it in frontend.
Also, I'd separate the frontend React code into components and put them in separate parts.
Didn't use Typescript as never worked with it and thought I'd go with what I know.

