CREATE PROCEDURE SP_RET_TRANS_POR_CUENTA
  @P_IdCuentaBancaria INT = NULL,
  @P_IdCuentaComercio INT  = NULL
AS
BEGIN
  SELECT * FROM dbo.Transaccion
   WHERE (@P_IdCuentaBancaria IS NOT NULL AND IdCuentaBancaria = @P_IdCuentaBancaria)
      OR (@P_IdCuentaComercio  IS NOT NULL AND IdCuentaComercio  = @P_IdCuentaComercio)
   ORDER BY Fecha DESC;
END