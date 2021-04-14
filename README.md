# Todoify Application
This is a simple ToDo application where users have to login and sees the list of tasks and they can add tasks with specified due date, delete task, complete a particular task.

This simple app is divided into front and backend projects. Backend projects contains the API, ClassLibrary and Data class library itself which is just bunch of classes mimicking a database and we have 
front end project contains FrontEnd UI library and WPF application itself.

### Startup guide

1. Clone the repository 
2. Open it in Visual Studio
3. 2 Projects with run (Web API and WPF Application)
4. You can use the following credentials to login 
	1. username: user@vencortex.io
	2. password: Pwd123!
5. If you do not want to use the credentials, then goto https://localhost:PORT/swagge, then click Account and POST /api/Account/Register 


### Design
The motive for this design is to loosly couple code so that if we want to change front end in the future, it would not effect the backend libraries and API. We might have more leverage in adding and removing components from a system without worrying alot about code rewrite or failure.

![design](./Images/design.png)

### Technologies & Frameworks used
1. .NET Framework 4.8 (in all ClassLibraries & WPF application)
2. Web API MVC (.NET Framework 4.8) with Swagger Implementation
3. Caliburn Micro (for MVVM, Depedency Injection, Binding, Event Aggregator etc.)
4. AutoMapper (simple library for object-to-object mapping library)



### Backend Projects
1. TodoifyData (This classlibrary just mimiks a Database and classes which contains the data).
2- TodofyDataManager.Library (This classlibrary is just a layer between API and Database i.e TodoifyData. We don't want our API to directly fetch data from Database so this layer which has DataAccess)