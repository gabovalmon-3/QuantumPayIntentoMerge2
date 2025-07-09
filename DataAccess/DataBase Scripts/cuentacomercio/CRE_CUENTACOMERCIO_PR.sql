CREATE PROCEDURE CRE_CUENTACOMERCIO_PR
    @P_nombreUsuario NVARCHAR(20),
    @P_contrasena NVARCHAR(20),
    @P_cedulaJuridica NVARCHAR(20),
    @P_telefono INT,
    @P_correoElectronico NVARCHAR(50),
    @P_direccion NVARCHAR(100)
AS
BEGIN
    INSERT INTO cuentaComercio (
        nombreUsuario,
        contrasena,
        cedulaJuridica,
        telefono,
        correoElectronico,
        direccion
    )
    VALUES (
        @P_nombreUsuario,
        @P_contrasena,
        @P_cedulaJuridica,
        @P_telefono,
        @P_correoElectronico,
        @P_direccion
    )
END
GO
