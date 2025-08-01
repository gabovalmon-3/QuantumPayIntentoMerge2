CREATE PROCEDURE DEL_CLIENTE_PR
    @P_idCliente INT
AS
BEGIN
    DELETE FROM cliente
    WHERE idCliente = @P_idCliente
END
GO
