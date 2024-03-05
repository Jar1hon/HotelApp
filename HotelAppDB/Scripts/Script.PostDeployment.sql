/*
Шаблон скрипта после развертывания							
--------------------------------------------------------------------------------------
 В данном файле содержатся инструкции SQL, которые будут добавлены в скрипт построения.		
 Используйте синтаксис SQLCMD для включения файла в скрипт после развертывания.			
 Пример:      :r .\myfile.sql								
 Используйте синтаксис SQLCMD для создания ссылки на переменную в скрипте после развертывания.		
 Пример:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--if not exists (SELECT * FROM dbo.RoomTypes)
--begin
--    insert into dbo.RoomTypes(Title, Description, Price)
--    values ('King Size Bed', 'A room with a king-size bed and a window.', 100),
--    ('Two Queen Size Beds','A room with two queen-size bed and a window.', 115),
--    ('Executive Suite','Two rooms, each with a king-size bed and a window.', 205);
--end

--if not exists (select 1 from dbo.Rooms)
--begin
--    declare @roomId@1 int;
--    declare @roomId@2 int;
--    declare @roomId@3 int;

--    select @roomId@1 = Id from dbo.RoomTypes where Title = 'King Size Bed';
--    select @roomId@2 = Id from dbo.RoomTypes where Title = 'Two Queen Size Beds';
--    select @roomId@3 = Id from dbo.RoomTypes where Title = 'Executive Suite';

--    insert into dbo.Rooms(RoomNumber, RoomTypeId)
--    values ('101', @roomId@1),
--    ('102', @roomId@1),
--    ('103', @roomId@1),
--    ('201', @roomId@2),
--    ('202', @roomId@2),
--    ('301', @roomId@3);
--end
