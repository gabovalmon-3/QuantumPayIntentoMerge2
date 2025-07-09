CREATE PROCEDURE DEL_INSTITUCIONBANCARIA_PR
    @P_idInstBancaria INT
AS
BEGIN
    DELETE FROM institucionBancaria
    WHERE idInstBancaria = @P_idInstBancaria
END
GO
