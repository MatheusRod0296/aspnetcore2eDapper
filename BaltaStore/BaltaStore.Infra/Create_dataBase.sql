create table [Customer]
(
     [Id] Uniqueidentifier Primary key not null
    ,[FirstName] varchar(40) not null
    ,[LastName] varchar(40) not null
    ,[Document] char(11) not null
    ,[Email] varchar(160) not null
    ,[Pohone] varchar(13) not null
)

create table [Adress]
(
     [Id] Uniqueidentifier Primary key not null
    ,[CustomerId] Uniqueidentifier not null
    ,[Number] varchar(10) not null
    ,[Complement] varchar(40) not null
    ,[District] varchar(60) not null
    ,[City] varchar(60) not null
    ,[state] char(2) not null
    ,[Country] char(2) not null
    ,[Zipcode] char(8) not null
    ,[Type]  int not null default(1)
    ,Foreign key ([CustomerId] references [Customer](Id))
    
    
)

create table [Product]
(
      [Id] Uniqueidentifier Primary key not null
      ,[Title] varchar(255) not null
      ,[description] Text not null
      ,[image] varchar(1024) not null
      ,[price] money not null
      ,[quantityOnHand] Decimal(10,2) not null
)

create table [Order]
(
    [Id] Uniqueidentifier Primary key not null
    ,[costumerId] Uniqueidentifier not null
    ,[createDate] DateTime not null default(GetDate())
    ,[status] int not null default(1)
    ,Foreign key ([CustomerId]) references ([Customer]([Id]))
)


create table [OrderItem]
(
    [Id] Uniqueidentifier Primary key not null
    ,[OrderId] Uniqueidentifier not null
    ,[ProductId] Uniqueidentifier not null
    ,[Qunatity] decimal(10,2) not null
    ,[price] money not null  
    ,Foreign key ([OrderId]) references ([OrderId]([Id]))
    ,Foreign key ([ProductId]) references ([Product]([Id]))
)

create table [Delivery]
(
     [Id] Uniqueidentifier Primary key not null
      ,[OrderId] Uniqueidentifier not null
      ,[createDate] DateTime not null default(GetDate())
      ,[EstimatedateDeliveryDate] DateTime not null
      ,[status] int not null default(1)
      ,Foreign key ([OrderId]) references ([OrderId]([Id]))
)

