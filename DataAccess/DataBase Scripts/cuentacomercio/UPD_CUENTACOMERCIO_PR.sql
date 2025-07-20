CREATE PROCEDURE UPD_CUENTACOMERCIO_PR
    @P_idCuenta INT,
    @P_nombreUsuario NVARCHAR(20),
    @P_contrasena NVARCHAR(120),
    @P_cedulaJuridica NVARCHAR(20),
    @P_telefono INT,
    @P_correoElectronico NVARCHAR(50),
    @P_direccion NVARCHAR(100)
AS
BEGIN
    UPDATE cuentaComercio
    SET 
        nombreUsuario = @P_nombreUsuario,
        contrasena = @P_contrasena,
        cedulaJuridica = @P_cedulaJuridica,
        telefono = @P_telefono,
        correoElectronico = @P_correoElectronico,
        direccion = @P_direccion
    WHERE idCuenta = @P_idCuenta
END
GO
