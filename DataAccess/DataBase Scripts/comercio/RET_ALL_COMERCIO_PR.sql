CREATE PROCEDURE RET_ALL_COMERCIO_PR
AS
BEGIN
    SELECT 
        idComercio,
        idCuenta,
        nombre,
        estadoSolicitud
    FROM comercio
END
GO
