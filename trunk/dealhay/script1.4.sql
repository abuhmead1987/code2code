set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'idrootcat'  
            and Object_ID = Object_ID(N'anm_Categories')) 
BEGIN
alter table anm_Categories
	add idrootcat int NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getComment]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getComment] (
    @idcomment int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_Comments WHERE [idcomment] = @idcomment
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_UpdateArticle] (
	@idnews int,
    @title nvarchar(256),
    @author nvarchar(256),
    @image nvarchar(256),
    @summary ntext,
    @news ntext,
	@idcategory int,
	@commentcheck bit,
	@published bit,
	@highlight bit,
	@sidenews bit,
	@postedby bit,
	@date datetime,
	@tags nvarchar(256),
	@homeslide bit
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_News] SET [title] = @title, [author] = @author, [image] = @image, [summary] = @summary, [news] = @news, [idcategory] = @idcategory, [commentcheck] = @commentcheck, [published] = @published, [highlight] = @highlight, [sidenews] = @sidenews, [postedby] = @postedby, [date] = @date, [tags] = @tags, [homeslide] = @homeslide Where [idnews] = @idnews
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showAllNewsByCat] (
    @idcategory int,
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showAllNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int,
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_GetRssComments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_GetRssComments] (
    @idn int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 15 idcomment,date,comment FROM anm_Comments Where anm_Comments.idnews = @idn ORDER BY idcomment DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_InsertCategory] (
    @category nvarchar(256),
	@idfather int,
	@ordercat int,
	@idrootcat int
) 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_Categories] ([category],[idfather],[ordercat],[idrootcat]) VALUES (@category,@idfather,@ordercat,@idrootcat)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_LastComments]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 20 anm_News.idnews,anm_News.Title,anm_News.Comments,anm_Comments.commentator,anm_Comments.idcomment,anm_Comments.date,anm_Comments.comment FROM anm_News,anm_Comments WHERE anm_Comments.idNews = anm_News.idNews and [approved] = ''true'' ORDER BY idcomment DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_archiveAllNewsByDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_archiveAllNewsByDate] (
    @year int,
    @month int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT idnews,date,Title FROM anm_News Where date<GETDATE() and  published = ''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_archiveAllNewsByCatDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_archiveAllNewsByCatDate] (
    @year int,
    @month int,
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT idnews,date,Title FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and published = ''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_UpdateArticle] (
	@idnews int,
    @title nvarchar(256),
    @image nvarchar(256),
    @summary ntext,
    @news ntext,
	@idcategory int,
	@commentcheck bit,
	@published bit,
	@highlight bit,
	@sidenews bit,
	@postedby bit,
	@date datetime,
	@tags nvarchar(256),
	@homeslide bit
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_News] SET [title] = @title, [image] = @image, [summary] = @summary, [news] = @news, [idcategory] = @idcategory, [commentcheck] = @commentcheck, [published] = @published, [highlight] = @highlight, [sidenews] = @sidenews, [postedby] = @postedby, [date] = @date, [tags] = @tags, [homeslide] = @homeslide Where [idnews] = @idnews
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_getNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT idnews,title,author,date FROM anm_News ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsPaged] (
	@highlight bit,
	@sidenews bit,
	@startRowIndex int, 
	@maximumRows int	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News Where date<GETDATE() and published = ''true'' and sidenews=@sidenews and highlight=@highlight) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByCatPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByCatPaged] (
    	@idcategory int,
	@highlight bit,
	@sidenews bit,
	@startRowIndex int, 
	@maximumRows int	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT anm_News.*, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News,anm_Categories Where date<GETDATE() and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByCatDatePaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByCatDatePaged] (
    @year int,
    @month int,
    @idcategory int,
	@highlight bit,
	@sidenews bit,
	@startRowIndex int, 
	@maximumRows int	
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT anm_News.*, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight and DATEPART(year,date)=@year and DATEPART(month,date)=@month) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByDatePaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByDatePaged] (
    @year int,
    @month int,
	@highlight bit,
	@sidenews bit,
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=@sidenews and highlight=@highlight and DATEPART(year,date)=@year and DATEPART(month,date)=@month) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getNewsByAuthorPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getNewsByAuthorPaged] (
    @author nvarchar(256),
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News Where date<GETDATE() and  [author] = @author and [published] = ''true'') AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getNewsByTagPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getNewsByTagPaged] (
    @tag nvarchar(256),
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY date DESC) AS RowNumber FROM anm_News WHERE [tags] LIKE ''%'' + @tag + ''%'' and [published] = ''true'') AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_GetPCommentsByIdnPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_GetPCommentsByIdnPaged] (
    @idnews int,
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY idcomment DESC) AS RowNumber FROM [anm_Comments] WHERE [idnews] = @idnews and [approved] = ''true'') AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_SearchNewsPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_SearchNewsPaged] (
    @title nvarchar(128),
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews DESC) AS RowNumber FROM [anm_News] WHERE (([title] LIKE ''%'' + @title + ''%'') OR ([news] LIKE ''%'' + @title + ''%'') OR ([summary] LIKE ''%'' + @title + ''%'')) and published=''true'' and date<GETDATE()) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_SearchNewsbyCatPaged]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_SearchNewsbyCatPaged] (
    @title nvarchar(128),
@idcategory int,
	@startRowIndex int, 
	@maximumRows int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT title,idnews,image,Summary,news FROM (SELECT title,idnews,image,Summary,news, ROW_NUMBER() OVER(ORDER BY idnews DESC) AS RowNumber FROM [anm_News],[anm_Categories] WHERE (([title] LIKE ''%'' + @title + ''%'') OR ([news] LIKE ''%'' + @title + ''%'') OR ([summary] LIKE ''%'' + @title + ''%'')) and published=''true'' and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory or anm_Categories.idrootcat = @idcategory) and date<GETDATE()) AS NewsWithRowNumbers WHERE RowNumber > @startRowIndex AND RowNumber <= (@startRowIndex + @maximumRows)
END
' 
END