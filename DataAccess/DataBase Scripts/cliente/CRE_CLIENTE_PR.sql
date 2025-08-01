CREATE PROCEDURE CRE_CLIENTE_PR
@P_cedula NVARCHAR(20),
@P_nombre NVARCHAR(50),
@P_apellidos NVARCHAR(80),
@P_telefono INT,
@P_correoElectronico NVARCHAR(50),
@P_direccion NVARCHAR(100),
@P_fotoCedula NVARCHAR(150),
@P_fechaNacimiento DATE,
@P_fotoPerfil NVARCHAR(100),
@P_contrasena NVARCHAR(120),
@P_IBAN NVARCHAR(30)
AS
BEGIN
    INSERT INTO cliente (
        cedula, nombre, apellidos, telefono, correoElectronico,
        direccion, fotoCedula, fechaNacimiento, fotoPerfil,
        contrasena, IBAN
    )
    VALUES (
        @P_cedula, @P_nombre, @P_apellidos, @P_telefono, @P_correoElectronico,
        @P_direccion, @P_fotoCedula, @P_fechaNacimiento, @P_fotoPerfil,
        @P_contrasena, @P_IBAN
    )
END
GO
