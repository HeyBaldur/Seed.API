# Seed.API 💻
API Seed asp.net core 3.1 will help developers to create faster applications

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
