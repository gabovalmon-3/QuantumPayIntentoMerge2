CREATE PROCEDURE RET_CUENTACOMERCIO_BY_EMAIL_PR
    @P_correoElectronico NVARCHAR(50)
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
    WHERE correoElectronico = @P_correoElectronico
END
GO
