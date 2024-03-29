set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'UsersOnline'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add OnlineUsers bit NULL
END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
if Not Exists(select * from sys.columns where Name = N'ArtImageWidth'  
            and Object_ID = Object_ID(N'anm_Settings')) 
BEGIN
alter table anm_Settings
	add ArtImageWidth int NULL
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNews]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNews] (
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and published = ''true'' and sidenews=@sidenews and highlight=@highlight ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByCat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByCat] (
    @idcategory int,
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByCatDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByCatDate] (
    @year int,
    @month int,
	@idcategory int,
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News,anm_Categories Where date<GETDATE() and  anm_News.idcategory = anm_Categories.idcategory and (anm_News.idcategory = @idcategory or anm_Categories.idfather = @idcategory) and published = ''true'' and sidenews=@sidenews and highlight=@highlight and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
END
' 
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[anm_showAllNewsByDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[anm_showAllNewsByDate] (
    @year int,
    @month int,
	@highlight bit,
	@sidenews bit
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM anm_News Where date<GETDATE() and  published = ''true'' and sidenews=@sidenews and highlight=@highlight and DATEPART(year,date)=@year and DATEPART(month,date)=@month ORDER BY date DESC
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
	SELECT TOP 20 anm_News.idnews,anm_News.Title,anm_News.Comments,anm_Comments.commentator,anm_Comments.idcomment,anm_Comments.date FROM anm_News,anm_Comments WHERE anm_Comments.idNews = anm_News.idNews and [approved] = ''true'' ORDER BY idcomment DESC
END
' 
END

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHNews]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHNews
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHNewsByCat]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHNewsByCat
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHNewsByCatDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHNewsByCatDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHNewsByDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHNewsByDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHSideNews]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHSideNews
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHSideNewsByCat]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHSideNewsByCat
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHSideNewsByCatDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHSideNewsByCatDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showHSideNewsByDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showHSideNewsByDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showNews]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showNews
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showNewsByCat]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showNewsByCat
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showNewsByCatDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showNewsByCatDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showNewsByDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showNewsByDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showSideNews]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showSideNews
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showSideNewsByCat]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showSideNewsByCat
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showSideNewsByCatDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showSideNewsByCatDate
END


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_showSideNewsByDate]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_showSideNewsByDate
END

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_getNewsByCat]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_getNewsByCat
END

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[anm_admin_settings]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE dbo.anm_admin_settings
END