CREATE PROCEDURE SP_UPD_COMISION
  @P_Id INT,
  @P_IdInstitucionBancaria INT,
  @P_IdCuentaComercio INT    = NULL,
  @P_Porcentaje DECIMAL(5,4),
  @P_MontoMaximo DECIMAL(18,2)
AS
BEGIN
  UPDATE dbo.Comision
    SET IdInstitucionBancaria = @P_IdInstitucionBancaria,
        IdCuentaComercio     = @P_IdCuentaComercio,
        Porcentaje           = @P_Porcentaje,
        MontoMaximo          = @P_MontoMaximo
   WHERE Id = @P_Id;
END