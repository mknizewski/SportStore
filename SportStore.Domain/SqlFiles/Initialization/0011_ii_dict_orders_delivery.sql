USE SportStore

SET IDENTITY_INSERT _dict_orders_delivery ON

INSERT INTO _dict_orders_delivery(Id, Name, Price, InsertTime) VALUES (1, 'Poczta Polska z góry', 8.00, GETDATE());
INSERT INTO _dict_orders_delivery(Id, Name, Price, InsertTime) VALUES (2, 'Poczta Polska za pobraniem', 10.00, GETDATE());
INSERT INTO _dict_orders_delivery(Id, Name, Price, InsertTime) VALUES (3, 'Kurier z góry', 15.00, GETDATE());
INSERT INTO _dict_orders_delivery(Id, Name, Price, InsertTime) VALUES (4, 'Kurier za pobraniem', 20.00, GETDATE());