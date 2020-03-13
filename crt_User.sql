-- Script Date: 2020-03-09 오후 5:40  - ErikEJ.SqlCeScripting version 3.5.2.85
CREATE TABLE [User] (
  [Id] INTEGER NOT NULL
, [FirstName] TEXT NULL
, [LastName] TEXT NULL
, [Username] TEXT NULL
, [Password] TEXT NULL
, [Token] TEXT NULL
, CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
