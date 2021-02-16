DROP TABLE IF EXISTS Trade
go
DROP TABLE IF EXISTS Sector
go
DROP FUNCTION  IF EXISTS ReturnRisk
go
DROP VIEW IF EXISTS VW_TradeCategories 
GO
DROP PROCEDURE IF EXISTS ReturnTradeCategories
go

CREATE TABLE Sector(
    SectorID SmallInt NOT NULL,
    Name varchar(255) NOT NULL,
	TypeSector char(1) NOT NULL,
	PRIMARY KEY (SectorID)
);

GO

CREATE TABLE Trade (
    TradeID Int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Value decimal  NOT NULL,
    SectorID SmallInt NOT NULL,
    CONSTRAINT FK_Trade FOREIGN KEY (SectorID)
    REFERENCES Sector(SectorID)
); 

Go 


CREATE FUNCTION dbo.ReturnRisk (@TypeSector char(1), @Value decimal)
RETURNS Varchar(200)
AS
BEGIN
    DECLARE @Ret as varchar(200)
	Set @Ret='undefined';

	  SET @Ret =   
        CASE   
            WHEN   @TypeSector='P' and @Value<1000000  THEN 'LOWRISK'  
	 	    WHEN   @TypeSector='P' and @Value>1000000  THEN 'MEDIUMRISK'  
		    WHEN   @TypeSector='V' and @Value>1000000  THEN 'HIGHRISK'  
			ELSE 'undefined'
        END; 
    RETURN @ret;  
END

GO 
CREATE VIEW VW_TradeCategories  
AS  
select b.Name,a.Value ,dbo.ReturnRisk(b.TypeSector,a.Value) as TradeCategories from trade a (nolock)
                inner join Sector (nolock) b on a.SectorID=b.SectorID


GO

CREATE PROCEDURE ReturnTradeCategories
AS

SELECT tradeCategories = STUFF((
         SELECT ',' + TradeCategories
            FROM  VW_TradeCategories
            FOR XML PATH('')
         ), 1, 1, '')
GO

insert into Sector values (1,'Public Sector','P')
insert into Sector values (2,'Private Sector','V')


insert into trade values (2000000,2)
insert into trade values (400000,1)
insert into trade values (500000,1)
insert into trade values (3000000,1)




EXEC ReturnTradeCategories



