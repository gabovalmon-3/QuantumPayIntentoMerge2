CREATE PROCEDURE UPD_ADMIN_PR
@P_idAdmin INT,
@P_nombreUsuario NVARCHAR(20),
@P_contrasena NVARCHAR(120)
AS
BEGIN
    UPDATE admin
    SET nombreUsuario = @P_nombreUsuario,
        contrasena = @P_contrasena
    WHERE idAdmin = @P_idAdmin
END
GO
