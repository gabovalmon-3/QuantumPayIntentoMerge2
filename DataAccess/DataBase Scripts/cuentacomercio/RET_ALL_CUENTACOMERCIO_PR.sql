CREATE PROCEDURE RET_ALL_CUENTACOMERCIO_PR
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
END
GO
