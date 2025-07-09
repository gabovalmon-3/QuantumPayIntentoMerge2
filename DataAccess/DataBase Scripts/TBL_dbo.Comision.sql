CREATE TABLE dbo.Comision (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdInstitucionBancaria INT NOT NULL,
    IdCuentaComercio INT NULL,
    Porcentaje DECIMAL(5,4) NOT NULL,
    MontoMaximo DECIMAL(18,2) NOT NULL
);