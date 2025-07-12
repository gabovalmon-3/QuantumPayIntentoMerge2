CREATE PROCEDURE RET_CLIENTE_BY_EMAIL_PR
    @P_correoElectronico NVARCHAR(50)
AS
BEGIN
    SELECT 
        idCliente,
        cedula,
        nombre,
        apellidos,
        telefono,
        correoElectronico,
        direccion,
        fotoCedula,
        fechaNacimiento,
        fotoPerfil,
        contrasena,
        IBAN
    FROM cliente
    WHERE correoElectronico = @P_correoElectronico
END
GO
