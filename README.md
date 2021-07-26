# ASP.NET Core Seed API ✅
API Seed asp.net core 3.1 will help developers to create faster applications

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


