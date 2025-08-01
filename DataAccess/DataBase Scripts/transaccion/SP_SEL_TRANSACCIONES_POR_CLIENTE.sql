CREATE PROCEDURE SP_SEL_TRANSACCIONES_POR_CLIENTE
    @ClienteId INT
AS
BEGIN
    SELECT t.Id,
           t.IdCuentaBancaria,
           t.IdCuentaComercio,
           t.Monto,
           t.Comision,
           t.DescuentoAplicado,
           t.Fecha,
           t.MetodoPago
    FROM dbo.Transaccion t
        INNER JOIN dbo.ClienteCuenta cc ON t.IdCuentaBancaria = cc.Id
    WHERE cc.ClienteId = @ClienteId
    ORDER BY t.Fecha DESC;
END
GO
