/*Запрос, который выводит название товара, название типа и название производителя тех товаров цена которых больше 50*/
select Good.Name as 'Name', Producer.Name as 'Producer', Type.Name as 'Type' 
from Good 
	inner join Producer on Producer.id = Good.ProducerID
	inner join Type on Type.id = Good.TypeID 
		where Good.Price>50;

/*Запрос выводит минимальную цену всех товаров*/
select min(price) as 'Min Price of goods' 
	from Good;

/*Запрос выводит минимальную цену для каждого типа товара*/
select type.Name, t1.minPrice
	from (select Good.TypeID, min(price) as minPrice from Good 
		group by TypeID) as t1
	inner join type on type.Id = t1.TypeID;

/*Запрос выводит минимальную цену для каждого типа товара сумма цен которых больше 1000*/
select type.Name, t1.minPrice
	from (select Good.TypeID, min(price) as minPrice from Good 
		group by TypeID 
		having sum(price)>1000) as t1
	inner join type on type.Id = t1.TypeID;

/*Запрос выводит количество складов для каждого менеджера*/
select Manager.Name, t1.CountSt 
	from (select Stock.ManagerID, count(Stock.Id) as CountSt 
		from Stock group by ManagerID) as t1
	inner join Manager on Manager.Id = t1.ManagerId;

/*Запрос выводит менеджеров, чьи склады  обслуживюат более одного магазина*/
select Manager.Name from
	(select Manager.Id from Stock 
	inner join Manager on Manager.Id = Stock.ManagerID
	inner join StocksForShop on StocksForShop.StockID = Stock.Id 
		group by Manager.Id having count(StocksForShop.ShopID)>1) as t1
	inner join Manager on Manager.Id = t1.Id;

/*Вывести топ 3 менеджеров на чьих складах большее количество товаров*/
select Manager.Name from 
	(select top(3) Manager.Id from Stock 
	inner join Manager on Manager.Id = Stock.ManagerID
	inner join GoodsInStock on GoodsInStock.StockID = Stock.Id 
		group by Manager.Id order by sum(GoodsInStock.Count)) as t1
	inner join Manager on Manager.Id = t1.Id;

/*Увеличить на 1 количество всех товаров на складах с именем товара «Фисташки» и которые обслуживают магазины с именем «Мир пустоты»*/
update goodsinstock set count=count+1 
	from goodsinstock 
		inner join Good on Good.Id = GoodsInStock.GoodID
		inner join StocksForShop on StocksForShop.StockID = GoodsInStock.StockID
		inner join Shop on StocksForShop.ShopID = Shop.Id
			where Good.Name = N'Фисташки' and Shop.Name = N'Мир пустоты';