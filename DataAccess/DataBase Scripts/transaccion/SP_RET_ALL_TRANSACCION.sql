CREATE PROCEDURE SP_RET_ALL_TRANSACCION
AS
BEGIN
    SELECT Id,
           IdCuentaCliente,
           IdCuentaBancaria,
           IBAN,
           IdCuentaComercio,
           Monto,
           Comision,
           DescuentoAplicado,
           Fecha,
           MetodoPago
    FROM dbo.Transaccion
    ORDER BY Fecha DESC;
END
GO
