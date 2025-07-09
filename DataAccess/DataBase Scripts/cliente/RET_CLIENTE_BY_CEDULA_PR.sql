CREATE PROCEDURE RET_CLIENTE_BY_CEDULA_PR
    @P_cedula NVARCHAR(20)
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
    WHERE cedula = @P_cedula
END
GO
