CREATE PROCEDURE SP_INS_COMISION
  @P_IdInstitucionBancaria INT,
  @P_IdCuentaComercio INT    = NULL,
  @P_Porcentaje DECIMAL(5,4),
  @P_MontoMaximo DECIMAL(18,2)
AS
BEGIN
  INSERT INTO dbo.Comision
    (IdInstitucionBancaria, IdCuentaComercio, Porcentaje, MontoMaximo)
  VALUES
    (@P_IdInstitucionBancaria, @P_IdCuentaComercio, @P_Porcentaje, @P_MontoMaximo);
END