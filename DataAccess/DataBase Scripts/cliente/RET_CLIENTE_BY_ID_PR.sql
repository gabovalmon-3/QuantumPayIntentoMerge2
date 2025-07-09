CREATE PROCEDURE RET_CLIENTE_BY_ID_PR
    @P_idCliente INT
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
    WHERE idCliente = @P_idCliente
END
GO
