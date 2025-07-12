CREATE PROCEDURE RET_CLIENTE_BY_TELEFONO_PR
    @P_telefono INT
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
    WHERE telefono = @P_telefono
END
GO
