CREATE PROCEDURE CRE_COMERCIO_PR
    @P_idCuenta INT,
    @P_nombre NVARCHAR(50),
    @P_estadoSolicitud NVARCHAR(20)
AS
BEGIN
    INSERT INTO comercio (idCuenta, nombre, estadoSolicitud)
    VALUES (@P_idCuenta, @P_nombre, @P_estadoSolicitud)
END
GO
