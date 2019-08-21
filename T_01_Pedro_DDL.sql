Create database T_Peoples

use T_Peoples

Create Table Funcionarios
(
IdFuncionario Int primary key identity
,Nome varchar(255) not null
,Sobrenome varchar (255) not null
)

INSERT INTO Funcionarios (Nome,Sobrenome) Values ('Catarina' ,'Strada'), ('Tadeu','Vitelli')

SELECT *  FROM Funcionarios

SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios

ALTER TABLE Funcionarios ADD DataNascimento Date  

UPDATE Funcionarios
set DataNascimento = '04-09-1989'
WHERE IdFuncionario = 2

