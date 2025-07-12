CREATE PROCEDURE RET_CUENTACOMERCIO_BY_ID_PR
    @P_idCuenta INT
AS
BEGIN
    SELECT 
        idCuenta,
        nombreUsuario,
        contrasena,
        cedulaJuridica,
        telefono,
        correoElectronico,
        direccion
    FROM cuentaComercio
    WHERE idCuenta = @P_idCuenta
END
GO
