SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_getNews] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT idnews,title,author,date,comments FROM anm_News ORDER BY date DESC
END
' 
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN
EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[anm_GetRssComments] (
    @idn int
) 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 15 idcomment,date,comment FROM anm_Comments Where anm_Comments.idnews = @idn and anm_Comments.approved = ''true'' ORDER BY idcomment DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_Reports]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[anm_Reports](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](256) NOT NULL,
	[idreported] [int] NOT NULL,
	[reason] [nvarchar](max) NOT NULL,
	[date] [datetime] NOT NULL
) ON [PRIMARY]
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Exists(select * from sys.columns where Name = N'comment'  
            and Object_ID = Object_ID(N'anm_Comments')) 
BEGIN
alter table anm_Comments
ALTER COLUMN comment nvarchar(MAX) NOT NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Exists(select * from sys.columns where Name = N'summary'  
            and Object_ID = Object_ID(N'anm_News')) 
BEGIN
alter table anm_News
ALTER COLUMN summary nvarchar(MAX) NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Exists(select * from sys.columns where Name = N'news'  
            and Object_ID = Object_ID(N'anm_News')) 
BEGIN
alter table anm_News
ALTER COLUMN news nvarchar(MAX) NOT NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_getReports]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_getReports] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_Reports ORDER BY id DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_DeleteReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_DeleteReport] (
    @id int
) 
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM [anm_Reports] WHERE [id] = @id
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_InsertReport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_InsertReport] (
    @username nvarchar(256),
	@idreported int,
	@reason nvarchar(MAX),
	@date datetime
) 
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [anm_Reports] ([username],[idreported],[reason],[date]) VALUES (@username,@idreported,@reason,@date)
END
' 
END