
CREATE PROCEDURE USP_GetAllDatabaseDetails
(
 @ColumName VARCHAR(50),
 @TableName VARCHAR(50),
 @ViewName VARCHAR(50),
 @SPName VARCHAR(50)
 )
 AS
 SET NOCOUNT ON
 BEGIN
 DECLARE @FieldName VARCHAR(50)
 DECLARE @sType CHAR(1)

 IF ISNULL(@ColumName,'') <> ''
	BEGIN
		SET @FieldName ='''U''' + ' AND syscolumns.name LIKE ''%' +  @ColumName + '%'''
		--SET @sType ='U'
	END
ELSE IF ISNULL(@ViewName,'') <> ''
	BEGIN
		SET @FieldName ='''V''' + ' AND sysobjects.name LIKE ''%' +  @ViewName + '%'''
		--SET @sType ='V'
	END
ELSE IF ISNULL(@SPName,'') <> ''
	BEGIN
		SET @FieldName = '''P''' + ' AND sysobjects.name LIKE ''%' +  @SPName + '%'''
		--SET @sType ='P'
	END
ELSE IF ISNULL(@TableName,'') <>''
	BEGIN
		SET	@FieldName ='''U''' + ' AND sysobjects.name LIKE ''%' +  @TableName + '%'''
	END 


IF ISNULL(@FieldName,'') <>'' 
BEGIN 

DECLARE @SQL NVARCHAR(MAX)
SET @SQL ='SELECT	sysobjects.name AS [TableName],
        syscolumns.name AS [ColumnName],
        systypes.name AS [DataType],
		sep.value AS [Description],
		case when systypes.name = ''nvarchar''' + ' THEN syscolumns.prec
			else '''' END AS [nvarcharSize],
		case when isnullable = 0 then ''N''' + 'else ''Y''' + ' end as [AllowNulls],
		ISNULL(substring(ic.CONSTRAINT_NAME,1,2),'''') as [Constraints],
		case when ISNULL(substring(ic.CONSTRAINT_NAME,1,2),'''') = ''PK'''  + 
			' THEN CASE WHEN COLUMNPROPERTY(syscolumns.id, syscolumns.name,''IsIdentity''' + ')  = 1 THEN ''Yes''' +
			' ELSE ''No''' + ' END ELSE '''' END AS [IsIdentity],
		ISNULL(object_name(fk.referenced_object_id), '''') AS [ReferenceTable]
	FROM	sysobjects 
			JOIN	syscolumns ON sysobjects.id = syscolumns.id 
			JOIN	systypes ON syscolumns.xtype=systypes.xtype and systypes.name <> ''sysname''' +
			' LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ic on sysobjects.name = ic.TABLE_NAME and syscolumns.name = ic.COLUMN_NAME
				AND (ic.CONSTRAINT_NAME like ''PK%''' + ' or ic.CONSTRAINT_NAME like ''FK%''' + ')
			LEFT JOIN sys.foreign_keys fk on fk.name = ic.CONSTRAINT_NAME
			LEFT OUTER JOIN sys.extended_properties sep ON sep.major_id = sysobjects.id AND sep.minor_id = syscolumns.id
    WHERE sysobjects.xtype= ' + @FieldName
	+'	ORDER BY sysobjects.name '

	EXEC SP_EXECUTESQL @SQL

END
END 







