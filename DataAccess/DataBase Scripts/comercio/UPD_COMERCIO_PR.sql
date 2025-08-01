CREATE PROCEDURE UPD_COMERCIO_PR
    @P_idComercio INT,
    @P_idCuenta INT,
    @P_nombre NVARCHAR(50),
    @P_estadoSolicitud NVARCHAR(20)
AS
BEGIN
    UPDATE comercio
    SET 
        idCuenta = @P_idCuenta,
        nombre = @P_nombre,
        estadoSolicitud = @P_estadoSolicitud
    WHERE idComercio = @P_idComercio
END
GO
