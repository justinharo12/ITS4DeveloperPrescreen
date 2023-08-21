CREATE PROCEDURE getCountyMapIds 
	@comboBox1Text nvarchar(50), 
	@comboBox2Text nvarchar(50)
AS
BEGIN

	SELECT Counties.mapId FROM Counties WHERE countyname = @comboBox1Text OR countyName = @comboBox2Text
END
