CREATE PROCEDURE UPD_CLIENTE_PR
    @P_idCliente INT,
    @P_cedula NVARCHAR(20),
    @P_nombre NVARCHAR(50),
    @P_apellidos NVARCHAR(80),
    @P_telefono INT,
    @P_correoElectronico NVARCHAR(50),
    @P_direccion NVARCHAR(100),
    @P_fotoCedula NVARCHAR(150),
    @P_fechaNacimiento DATE,
    @P_fotoPerfil NVARCHAR(100),
    @P_contrasena NVARCHAR(20),
    @P_IBAN NVARCHAR(30)
AS
BEGIN
    UPDATE cliente
    SET
        cedula = @P_cedula,
        nombre = @P_nombre,
        apellidos = @P_apellidos,
        telefono = @P_telefono,
        correoElectronico = @P_correoElectronico,
        direccion = @P_direccion,
        fotoCedula = @P_fotoCedula,
        fechaNacimiento = @P_fechaNacimiento,
        fotoPerfil = @P_fotoPerfil,
        contrasena = @P_contrasena,
        IBAN = @P_IBAN
    WHERE idCliente = @P_idCliente
END
GO
