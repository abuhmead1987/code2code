SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showSideNewsByDate] (
    @year int,
    @month int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  [published] = ''true'' and [highlight]=''false'' and [sidenews]=''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showSideNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  [idcategory] = @idcategory and [published] = ''true'' and [highlight]=''false'' and [sidenews]=''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showSideNewsByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [sidenews]=''true'' and highlight=''false'' ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showSideNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=''true'' and highlight=''false'' ORDER BY date DESC
END

' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showNewsByDate] (
    @year int,
    @month int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  [published] = ''true'' and [highlight]=''false'' and [sidenews]=''false'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [highlight]=''false'' and [sidenews]=''false'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showNewsByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [highlight]=''false'' and [sidenews]=''false'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=''false'' and highlight=''false'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHSideNewsByDate] (
    @year int,
    @month int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  [published] = ''true'' and [highlight]=''true'' and [sidenews]=''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHSideNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [highlight]=''true'' and [sidenews]=''true'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHSideNewsByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [sidenews]=''true'' and [highlight]=''true'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHSideNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=''true'' and highlight=''true'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHNewsByDate] (
    @year int,
    @month int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  [published] = ''true'' and [highlight]=''true'' and [sidenews]=''false'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [highlight]=''true'' and [sidenews]=''false'' and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHNewsByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' and [highlight] = ''true'' and [sidenews]=''false'' ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_showHNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=''false'' and highlight=''true'' ORDER BY date DESC
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
	SELECT * FROM anm_News ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_getRss] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 10 idnews,title,summary,news,date,idcategory,commentcheck,comments FROM anm_News Where date<GETDATE() and [published] = ''true'' ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_GetRssByCat] (
    @idcategory int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 10 idnews,title,summary,news,date,anm_News.idcategory,commentcheck,comments FROM anm_News,anm_Categories Where date<GETDATE() and anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and [published] = ''true'' ORDER BY date DESC

END
' 
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'Tags'  
            and Object_ID = Object_ID(N'anm_News')) 
BEGIN
alter table anm_News
	add Tags nvarchar(256) NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'homeslide'  
            and Object_ID = Object_ID(N'anm_News')) 
BEGIN
alter table anm_News
	add homeslide bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'CaptchaType'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add CaptchaType nvarchar(2) NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_Tags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[anm_Tags](
	[Tag] [nvarchar](50) NOT NULL,
	[Size] [int] NOT NULL,
 CONSTRAINT [PK_anm_Tags] PRIMARY KEY CLUSTERED 
(
	[Tag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getTags]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getTags] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_Tags ORDER BY Tag ASC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_DeleteTag]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_DeleteTag] (
    @Tag nvarchar(50)
) 
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [anm_Tags] WHERE [Tag] = @Tag
END' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_UpdateTag]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_UpdateTag] (
    @tag nvarchar(50),
	@size int
)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_Tags] SET [tag] = @tag, [size] = @size WHERE [tag] = @tag
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_InsertTag]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_InsertTag] (
    @tag nvarchar(50),
	@size int
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_Tags] (tag,size) VALUES (@tag,@size)
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
	UPDATE [anm_News] SET [title] = @title, [author] = @author, [image] = @image, [summary] = @summary, [news] = @news, [idcategory] = @idcategory, [commentcheck] = @commentcheck, [published] = @published, [highlight] = @highlight, [sidenews] = @sidenews, [postedby] = @postedby, [date] = @date, [tags] = @tags, [homeslide] = @homeslide Where date<GETDATE() and  [idnews] = @idnews
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_InsertArticle] (
    @title nvarchar(256),
    @author nvarchar(256),
    @image nvarchar(256),
    @summary ntext,
    @news ntext,
	@idcategory int,
	@comments int,
	@commentcheck bit,
	@published bit,
	@highlight bit,
	@sidenews bit,
	@postedby bit,
	@tags nvarchar(256),
	@homeslide bit
)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_News] (title,author,image,summary,news,idcategory,comments,commentcheck,published,highlight,sidenews,postedby,tags,homeslide) VALUES (@title,@author,@image,@summary,@news,@idcategory,@comments,@commentcheck,@published,@highlight,@sidenews,@postedby,@tags,@homeslide)
END
' 
END


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'TagBox'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add TagBox bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'Anonymous'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add Anonymous bit NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showSlideshowNews]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showSlideshowNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and published = ''true'' and homeslide=''true'' ORDER BY date DESC
END
' 
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'url'  
            and Object_ID = Object_ID(N'anm_Categories')) 
BEGIN
alter table anm_Categories
	add url nvarchar(256) NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_UpdateCategory] (
    @category nvarchar(256),
    @idcategory int,
    @ordercat int,
    @url nvarchar(256)
) 
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [anm_Categories] SET [category] = @category,[ordercat] = @ordercat,[url]=@url WHERE [idcategory] = @idcategory
END
' 
END