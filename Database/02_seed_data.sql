USE DevTrackDb;
GO


IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'admin@devtrack.com')
    BEGIN
        INSERT INTO Users (Name, Email, PasswordHash, Role, Location)
        VALUES (
                   'Admin',
                   'admin@devtrack.com',
                   '$2a$11$xKGKKj1dPPhGXZMDq6oKs.7Y4e5K6sO8bHqWWlCBLkGz4pQRrm4Oi',
                   'Admin',
                   'Bucharest'
               );
    END

IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'ion.popescu@devtrack.com')
    BEGIN
        INSERT INTO Users (Name, Email, PasswordHash, Role, Location)
        VALUES (
                   'Ion Popescu',
                   'ion.popescu@devtrack.com',
                   '$2a$11$xKGKKj1dPPhGXZMDq6oKs.7Y4e5K6sO8bHqWWlCBLkGz4pQRrm4Oi',
                   'User',
                   'Cluj-Napoca'
               );
    END

IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = 'maria.ionescu@devtrack.com')
    BEGIN
        INSERT INTO Users (Name, Email, PasswordHash, Role, Location)
        VALUES (
                   'Maria Ionescu',
                   'maria.ionescu@devtrack.com',
                   '$2a$11$xKGKKj1dPPhGXZMDq6oKs.7Y4e5K6sO8bHqWWlCBLkGz4pQRrm4Oi',
                   'User',
                   'Timisoara'
               );
    END
GO



IF NOT EXISTS (SELECT 1 FROM Devices WHERE Name = 'iPhone 15 Pro' AND Manufacturer = 'Apple')
    BEGIN
        INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId)
        VALUES ('iPhone 15 Pro', 'Apple', 'phone', 'iOS', '17.0', 'A17 Pro', 8, '', 1);
    END

IF NOT EXISTS (SELECT 1 FROM Devices WHERE Name = 'Galaxy S24 Ultra' AND Manufacturer = 'Samsung')
    BEGIN
        INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId)
        VALUES ('Galaxy S24 Ultra', 'Samsung', 'phone', 'Android', '14', 'Snapdragon 8 Gen 3', 12, '', 2);
    END

IF NOT EXISTS (SELECT 1 FROM Devices WHERE Name = 'Galaxy Tab S9' AND Manufacturer = 'Samsung')
    BEGIN
        INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId)
        VALUES ('Galaxy Tab S9', 'Samsung', 'tablet', 'Android', '13', 'Snapdragon 8 Gen 2', 12, '', NULL);
    END

IF NOT EXISTS (SELECT 1 FROM Devices WHERE Name = 'iPad Pro 12.9' AND Manufacturer = 'Apple')
    BEGIN
        INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId)
        VALUES ('iPad Pro 12.9', 'Apple', 'tablet', 'iPadOS', '17.0', 'M2', 16, '', NULL);
    END

IF NOT EXISTS (SELECT 1 FROM Devices WHERE Name = 'Pixel 8 Pro' AND Manufacturer = 'Google')
    BEGIN
        INSERT INTO Devices (Name, Manufacturer, Type, OperatingSystem, OsVersion, Processor, RamAmount, Description, AssignedUserId)
        VALUES ('Pixel 8 Pro', 'Google', 'phone', 'Android', '14', 'Google Tensor G3', 12, '', 3);
    END
GO