# ASP.NET Core Seed API ✅
API Seed asp.net core 3.1 will help developers to create faster applications [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

This project is an application skeleton for a typical ASP.NET Core app. You can use it to quickly bootstrap your ASP.NET Core projects and dev environment for these projects.

The seed contains a sample ASP.NET Core application and is preconfigured to install any other dependency.
The seed app doesn't do much, just shows a couple of controllers, error handling strategy, and well architectured, the basics for starting an ASP.NET Core application. This sample used Angular 2+ for the front end and also it uses xUnit for the UnitTest. 

```
git clone https://github.com/HeyBaldur/Seed.API
```
Open Seed.API and run the Seed.API.sln

You will need to create a Database called SolutionsDB or any other name you want and configure the appsettings.json to connect properly to your DataBase. 
Remember to run the command using PowerShell or cmd in the root of your API which should be Seed.API\Seed.API
Once you have connected and configured correctly your appsetting.json you need to run the first migration which needs to be:

```
dotnet ef migrations add InitialCreate
```

We should add the following SP to our database, basically we will work with SP in the API to make it work easier and practice more about all the back-end environment💻
```
USE [SolutionsDB]
GO
/****** Object:  StoredProcedure [dbo].[GetSolutions]    Script Date: 5/29/2021 9:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HeyBaldur
-- Create date: 5-29-2020
-- Description:	Gets all the solutions by solution ID and DIM solution ID
-- =============================================
ALTER PROCEDURE [dbo].[GetSolutions]
	@DimSolutionID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT * FROM [SolutionsDB].[dbo].[DimSolutionFilters]
	WHERE DimSolutionId = @DimSolutionID AND SolutionId != 0
END

```
If you have any questions please feel free to contact/follow me [on twitter](https://twitter.com/HeyBaldur) and I will be glad to help you out.
Also you can take a look at my Gitbooks and check them out, I am still working on them so please be pacient with the results. 
[Gitbook](https://baldur.gitbook.io/angular/)

The updated Angular project template provides a convenient starting point for ASP.NET Core apps using Angular and the Angular CLI to implement a rich, client-side user interface (UI).

The template is equivalent to creating an ASP.NET Core project to act as an API backend and an Angular CLI project to act as a UI. The template offers the convenience of hosting both project types in a single app project. Consequently, the app project can be built and published as a single unit.

### Run ng commands
In a command prompt, switch to the ClientApp subdirectory:

```
cd ClientApp
```
If you have the ng tool installed globally, you can run any of its commands. For example, you can run ng lint, ng test, or any of the other Angular CLI commands. There's no need to run ng serve though, because your ASP.NET Core app deals with serving both server-side and client-side parts of your app. Internally, it uses ng serve in development.

If you don't have the ng tool installed, run npm run ng instead. For example, you can run npm run ng lint or npm run ng test.

### Install npm packages
To install third-party npm packages, use a command prompt in the ClientApp subdirectory. For example:

```
cd ClientApp
npm install --save <package_name>
```
# **Coding tips and paths to learn**

- Design patterns
  - Abstract factory
  - Adapter
  - Builder
  - Composite
  - Factory method
  - Singleton
- Behavioral patterns
  - Command
  - Iterator
  - Visitor

Other patterns

**CQRS and Mediator pattern**

CQRS = Command Query Responsibility Segregation. Basically its purpose is the CQRS is separating the reading operations and updating of the data. This pattern allows us to improve scalability, security and performance. It allows to avoid conflict fusions at domain level.

**What problem it solves?**

In traditional architectures, the same data is used to query and update a database. That's simple and works fine for basic CRUD operations.

In more complex apps, however, this approach can become unwieldy. For example, on the read side, the app can perform many different queries, returning data transfer objects (DTOs) with different forms.

Object mapping can get tricky. On the writing side, the model can implement complex validation and business logics. As a result, you may end up with an overly complex model that does too much.

**Benefits of the CQRS pattern**

- Separation of interests. Separating the read and write sides can result in models that are easier to maintain and more flexible. Most of the complex business logic goes into the script model. The reading model can be relatively simple.
- Simpler queries. By storing a materialized view in the read database, the app can avoid complex joins when performing queries.

![](RackMultipart20221010-1-tlptgr_html_91cfa024f96ebc5f.png)

## **Angular journey**

- Angular version: [https://angular.io/guide/releases](https://angular.io/guide/releases)
- Content projection: [https://angular.io/guide/content-projection](https://angular.io/guide/content-projection)
- Built-in directives: [https://angular.io/guide/built-in-directives](https://angular.io/guide/built-in-directives)
- Renderer2: [https://angular.io/api/core/Renderer2](https://angular.io/api/core/Renderer2)
- Attribute directives: [https://angular.io/guide/attribute-directives](https://angular.io/guide/attribute-directives)
- HttpInterceptor: [https://angular.io/api/common/http/HttpInterceptor](https://angular.io/api/common/http/HttpInterceptor)
- Angular x Jest Snapshot Testing 📸: [https://medium.com/@aaaronnte/angular-x-jest-snapshot-testing-1ae13e2b68fd](https://medium.com/@aaaronnte/angular-x-jest-snapshot-testing-1ae13e2b68fd)
- Specflow: [https://specflow.org/](https://specflow.org/)
- io: [https://jestjs.io/](https://jestjs.io/)

**Interview questions Angular**

- [https://www.edureka.co/blog/interview-questions/top-angularjs-interview-questions-2016/](https://www.edureka.co/blog/interview-questions/top-angularjs-interview-questions-2016/)

**Interview questions JavaScript**

- [https://www.edureka.co/blog/interview-questions/javascript-interview-questions/](https://www.edureka.co/blog/interview-questions/javascript-interview-questions/)
- [https://css-tricks.com/understanding-immutability-in-javascript/](https://css-tricks.com/understanding-immutability-in-javascript/)

**Interview questions C#**

- [https://www.edureka.co/blog/interview-questions/c-sharp-interview-questions/](https://www.edureka.co/blog/interview-questions/c-sharp-interview-questions/)

**Interview questions CSS**

- [https://www.edureka.co/blog/interview-questions/css-interview-questions/](https://www.edureka.co/blog/interview-questions/css-interview-questions/)

