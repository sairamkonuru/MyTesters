CREATE PROCEDURE SP_ORDERdETAILS
(RegionId int)
AS
SELECT        ID, SalesOrderID, OrderDate, OrderQty, UnitPrice, StandardCost, tblProductName_ID, tblSalesRegion_ID
FROM            tblOrderDetails
where  tblSalesRegion_ID = RegionId


execute SP_ORDERdETAILS '2'


DROP PROCEDURE SP_ORDERdETAILS