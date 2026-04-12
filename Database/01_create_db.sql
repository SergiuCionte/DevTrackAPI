IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DevTrackDb')
    BEGIN
        CREATE DATABASE DevTrackDb;
    END
GO


USE DevTrackDb;
GO


IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Users' AND TABLE_SCHEMA = 'dbo'
)
    BEGIN
        CREATE TABLE Users (
                               Id            INT IDENTITY(1,1) PRIMARY KEY,
                               Name          NVARCHAR(100)  NOT NULL,
                               Email         NVARCHAR(200)  NOT NULL UNIQUE,
                               PasswordHash  NVARCHAR(500)  NOT NULL,
                               Role          NVARCHAR(50)   NOT NULL DEFAULT 'User',
                               Location      NVARCHAR(100)  NOT NULL
        );
    END
GO


IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Devices' AND TABLE_SCHEMA = 'dbo'
)
    BEGIN
        CREATE TABLE Devices (
                                 Id               INT IDENTITY(1,1) PRIMARY KEY,
                                 Name             NVARCHAR(100)  NOT NULL,
                                 Manufacturer     NVARCHAR(100)  NOT NULL,
                                 Type             NVARCHAR(50)   NOT NULL, 
                                 OperatingSystem  NVARCHAR(50)   NOT NULL,
                                 OsVersion        NVARCHAR(50)   NOT NULL,
                                 Processor        NVARCHAR(100)  NOT NULL,
                                 RamAmount        INT            NOT NULL, 
                                 Description      NVARCHAR(1000) NOT NULL DEFAULT '',
                                 AssignedUserId   INT            NULL,

                                 CONSTRAINT FK_Devices_Users
                                     FOREIGN KEY (AssignedUserId)
                                         REFERENCES Users(Id)
                                         ON DELETE SET NULL
        );
    END
GO