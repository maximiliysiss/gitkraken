/*Запрос, который выводит название товара, название типа и название производителя тех товаров цена которых больше 50*/
select Good.Name as 'Name',Producer.Name as 'Producer',Type.Name as 'Type' from Good,Producer,Type 
where Type.id = Good.TypeID and Producer.id=Good.ProducerID and Good.Price>50;

/*Запрос выводит минимальную цену всех товаров*/
select name, min(price) as 'price' from good group by name;

/*Запрос выводит минимальную цену для каждого типа товара*/
select type.name as 'name', min(good.price) as 'price' from type, good where good.typeID = type.id group by type.name;

/*Запрос выводит минимальную цену для каждого типа товара сумма цен которых больше 1000*/
select type.name as 'name', min(good.price) as 'price' from type, good 
where good.typeID = type.id group by type.name having sum(good.price)>1000;

/*Запрос выводит количество складов для каждого менеджера*/
select manager.name as 'name', count(stock.id) as 'count' from manager, stock where stock.managerID=manager.id group by manager.name;

/*Запрос выводит менеджеров, чьи склады  обслуживюат более одного магазина*/
select manager.name as 'name' from stock join manager on manager.id = stock.managerId join stocksforshop on 
stocksforshop.stockID = stock.id  group by manager.name having count(stocksforshop.shopID)>1;

/*Вывести топ 3 менеджеров на чьих складах большее количество товаров*/
select top(3) manager.name as 'name' from stock join goodsinstock on  goodsinstock.stockId = stock.id join 
manager on manager.id = stock.managerId group by manager.name order by sum(goodsinstock.count);

/*Увеличить на 1 количество всех товаров на складах с именем товара «Фисташки» и которые обслуживают магазины с именем «Мир пустоты»*/
update goodsinstock set count=count+1 where (select id from good where name=N'Фисташки')=goodID and 
	(select id from shop where name=N'Мир пустоты') in (select shopID from stocksforshop where stockID = goodsinstock.stockID);
