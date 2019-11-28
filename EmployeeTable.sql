create table Employee(
ID int PRIMARY KEY NOT NULL IDENTITY(1,1),
Name VARCHAR(100) NOT NULL,
Age int NOT NULL,
Location VARCHAR(100),
MaritalStatus VARCHAR(100),
Salary DECIMAL(18,2)
)


