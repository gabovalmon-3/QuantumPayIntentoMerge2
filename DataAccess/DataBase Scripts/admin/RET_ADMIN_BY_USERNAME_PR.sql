CREATE PROCEDURE RET_ADMIN_BY_USERNAME_PR
@P_nombreUsuario NVARCHAR(20)
AS
BEGIN
    SELECT idAdmin, nombreUsuario, contrasena
    FROM admin
    WHERE nombreUsuario = @P_nombreUsuario
END
GO
