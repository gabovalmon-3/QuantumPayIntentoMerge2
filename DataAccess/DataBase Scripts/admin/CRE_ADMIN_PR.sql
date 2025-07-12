CREATE PROCEDURE CRE_ADMIN_PR
@P_nombreUsuario NVARCHAR(20),
@P_contrasena NVARCHAR(20)
AS
BEGIN
    INSERT INTO admin (nombreUsuario, contrasena)
    VALUES (@P_nombreUsuario, @P_contrasena)
END
GO
