CREATE PROCEDURE [dbo].[checkAdjacency] 
	@comboBox1MapId nvarchar(50), 
	@comboBox2MapId nvarchar(50)
AS
BEGIN

	SELECT * FROM Counties WHERE mapId = @comboBox1MapId AND mapId LIKE '%'+@comboBox2MapId+'%'
END
