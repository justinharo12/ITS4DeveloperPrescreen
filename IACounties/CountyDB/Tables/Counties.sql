CREATE TABLE [dbo].[Counties] (
    [countyName]  NVARCHAR (50)  NOT NULL,
    [fipsId]      TINYINT        NOT NULL,
    [countySeat]  NVARCHAR (50)  NOT NULL,
    [id]          TINYINT        NOT NULL,
    [established] DATE           NOT NULL,
    [formedFrom]  NVARCHAR (100) NOT NULL,
    [etymology]   NVARCHAR (200) NOT NULL,
    [mapId]       TINYINT        NOT NULL,
    [population]  NVARCHAR (50)  NOT NULL,
    [area]        NVARCHAR (50)  NOT NULL,
    [mapImage]    NVARCHAR (1)   NULL
);

