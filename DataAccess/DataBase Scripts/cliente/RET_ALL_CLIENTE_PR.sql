CREATE PROCEDURE RET_ALL_CLIENTE_PR
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
END
GO
