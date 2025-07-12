CREATE PROCEDURE RET_ALL_ADMINS_PR
AS
BEGIN
    SELECT idAdmin, nombreUsuario, contrasena
    FROM admin
END
GO
