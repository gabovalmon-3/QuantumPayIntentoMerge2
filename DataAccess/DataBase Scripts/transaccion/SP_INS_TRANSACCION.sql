CREATE PROCEDURE SP_INS_TRANSACCION
  @P_IdCuentaCliente INT,
  @P_IdCuentaBancaria INT,
  @P_IdCuentaComercio INT,
  @P_Monto DECIMAL(18,2),
  @P_Comision DECIMAL(18,2),
  @P_DescuentoAplicado DECIMAL(18,2),
  @P_Fecha DATETIME2,
  @P_MetodoPago VARCHAR(50)
AS
BEGIN
  INSERT INTO dbo.Transaccion
    (IdCuentaCliente, IdCuentaBancaria, IdCuentaComercio, Monto, Comision, DescuentoAplicado, Fecha, MetodoPago)
  VALUES
    (@P_IdCuentaCliente, @P_IdCuentaBancaria, @P_IdCuentaComercio, @P_Monto, @P_Comision, @P_DescuentoAplicado, @P_Fecha, @P_MetodoPago);
END