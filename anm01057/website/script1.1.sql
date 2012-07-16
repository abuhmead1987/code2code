SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_GetCommentsAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_GetCommentsAll] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [anm_Comments] ORDER BY idcomment DESC
END
' 
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_InsertComment] (
    @idnews int,
    @commentator nvarchar(256),
    @comment ntext,
    @ip nvarchar(16),
    @approved bit
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_Comments] (idnews,commentator,date,comment,ip,approved) VALUES (@idnews,@commentator,GetDate(),@comment,@ip,@approved)
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'idfather'  
            and Object_ID = Object_ID(N'anm_Categories')) 
BEGIN
ALTER TABLE [dbo].[anm_Categories] 
ADD [idfather] [int] NOT NULL
CONSTRAINT [subcat_idfather_default] DEFAULT 0
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ordercat'  
            and Object_ID = Object_ID(N'anm_Categories')) 
BEGIN
ALTER TABLE [dbo].[anm_Categories] 
ADD [ordercat] [int] NOT NULL
CONSTRAINT [subcat_ordercat_default] DEFAULT 0
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_InsertCategory] (
    @category nvarchar(256),
	@idfather int,
	@ordercat int
) 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_Categories] ([category],[idfather],[ordercat]) VALUES (@category,@idfather,@ordercat)
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_getCategories] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_Categories
	ORDER BY category ASC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_SelectCategory] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [anm_Categories] ORDER BY [idfather],[ordercat] ASC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_UpdateCategory] (
    @category nvarchar(256),
    @idcategory int,
    @ordercat int
) 
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_Categories] SET [category] = @category,[ordercat] = @ordercat WHERE [idcategory] = @idcategory
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getSonCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getSonCategories] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_categories 
	WHERE anm_Categories.idfather = @idcategory 
	ORDER BY ordercat ASC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getMainCategories]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getMainCategories] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_Categories
	WHERE idfather = 0
	ORDER BY ordercat ASC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_GetRssByCat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_GetRssByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 10 * FROM anm_News,anm_Categories WHERE anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' ORDER BY date DESC

END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getRss]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getRss] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 10 * FROM anm_News WHERE [published] = ''true'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_LastComments]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_LastComments] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 20 anm_News.idnews,anm_News.Title,anm_News.Comments,anm_Comments.commentator,anm_Comments.date FROM anm_News,anm_Comments WHERE anm_Comments.idNews = anm_News.idNews and [approved] = ''true'' ORDER BY idcomment DESC
END
' 
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'NumArticles'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add NumArticles int NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ApproveArticles'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add ApproveArticles bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'NumComments'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add NumComments int NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ApproveComments'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add ApproveComments bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'BBCode'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add BBCode bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'Copyright'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add Copyright bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ViewNarticles'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add ViewNarticles bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'Validator'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add Validator bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'LastNews'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add LastNews bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'LastComments'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add LastComments bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'CaptchaNewUser'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add CaptchaNewUser bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'CaptchaComments'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add CaptchaComments bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'Version'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add Version nvarchar(10) COLLATE Latin1_General_CI_AS NULL
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ArchiveType'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add ArchiveType int NULL
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_UpdateSettings]') AND type in (N'P', N'PC'))
BEGIN
	DROP PROCEDURE anm_UpdateSettings
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER OFF
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_UpdateArticle]') AND type in (N'P', N'PC'))
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
	@postedby bit
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_News] SET [title] = @title, [author] = @author, [image] = @image, [summary] = @summary, [news] = @news, [idcategory] = @idcategory, [commentcheck] = @commentcheck, [published] = @published, [highlight] = @highlight, [sidenews] = @sidenews, [postedby] = @postedby WHERE [idnews] = @idnews
END
' 
END