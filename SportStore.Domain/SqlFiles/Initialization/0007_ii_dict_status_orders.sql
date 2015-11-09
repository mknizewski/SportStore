USE SportStore

INSERT INTO _dict_status_orders(Name, InsertTime) VALUES ('Nowe', GETDATE());
INSERT INTO _dict_status_orders(Name, InsertTime) VALUES ('W trakcie realizacji', GETDATE());
INSERT INTO _dict_status_orders(Name, InsertTime) VALUES ('Zakonczone', GETDATE());