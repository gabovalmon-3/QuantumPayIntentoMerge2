CREATE PROCEDURE RET_CUENTACOMERCIO_BY_USERNAME_PR
    @P_nombreUsuario NVARCHAR(20)
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
    WHERE nombreUsuario = @P_nombreUsuario
END
GO
