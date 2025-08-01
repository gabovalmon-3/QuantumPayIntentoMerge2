CREATE PROCEDURE DEL_COMERCIO_PR
    @P_idComercio INT
AS
BEGIN
    DELETE FROM comercio
    WHERE idComercio = @P_idComercio
END
GO
