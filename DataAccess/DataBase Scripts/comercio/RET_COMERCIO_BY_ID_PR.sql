CREATE PROCEDURE RET_COMERCIO_BY_ID_PR
    @P_idComercio INT
AS
BEGIN
    SELECT 
        idComercio,
        idCuenta,
        nombre,
        estadoSolicitud
    FROM comercio
    WHERE idComercio = @P_idComercio
END
GO
