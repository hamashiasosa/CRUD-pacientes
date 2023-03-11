
Create Database Prg3Parc
Use Prg3Parc

CREATE TABLE mEstatusPaciente (
      IDESTATUS INT PRIMARY KEY,
      DESCRIPCION   NVARCHAR(20),
      
);

CREATE TABLE mPacientes (
      IDPACIENTE int PRIMARY KEY,        
      NOMBRES  NVARCHAR(50),
      APELLIDOS NVARCHAR(50),
      EXPEDIENTE  NUMERIC(18,0),
      IDENTIFICACION  NVARCHAR(11),
      ESTATUS INT FOREIGN KEY (ESTATUS) REFERENCES mEstatusPaciente  (IDESTATUS)
); 



Insert Into mPacientes  values ('Hama', 'sosareyes', 123456789012345678, '12345678901', 1);
Insert Into mPacientes values ('Emile', 'Herrera', 234567890123456789, '23456789012', 2);
Insert Into mPacientes values ('Rosi', 'Fernandez', 345678901234567890, '34567890123', 3);


insert into mEstatusPaciente VALUES (1,'Ingresado');
insert into mEstatusPaciente VALUES (2,'De Alta');
insert into mEstatusPaciente VALUES (3,'En Emergencia');