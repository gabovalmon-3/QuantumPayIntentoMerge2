CREATE PROCEDURE RET_COMERCIO_BY_NAME_PR
    @P_nombre NVARCHAR(50)
AS
BEGIN
    SELECT 
        idComercio,
        idCuenta,
        nombre,
        estadoSolicitud
    FROM comercio
    WHERE nombre LIKE '%' + @P_nombre + '%'
END
GO
