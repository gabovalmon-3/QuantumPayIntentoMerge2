CREATE PROCEDURE RET_ADMIN_BY_ID_PR
@P_idAdmin INT
AS
BEGIN
    SELECT idAdmin, nombreUsuario, contrasena
    FROM admin
    WHERE idAdmin = @P_idAdmin
END
GO
