CREATE PROCEDURE SP_UPD_TRANSACCION
    @P_Id INT,
    @P_IdCuentaCliente INT,
    @P_IdCuentaBancaria INT,
    @P_IBAN VARCHAR(30),
    @P_IdCuentaComercio INT,
    @P_Monto DECIMAL(18,2),
    @P_Comision DECIMAL(18,2),
    @P_DescuentoAplicado DECIMAL(18,2),
    @P_Fecha DATETIME2,
    @P_MetodoPago VARCHAR(50)
AS
BEGIN
    UPDATE dbo.Transaccion
    SET IdCuentaCliente = @P_IdCuentaCliente,
        IdCuentaBancaria = @P_IdCuentaBancaria,
        IBAN = @P_IBAN,
        IdCuentaComercio = @P_IdCuentaComercio,
        Monto = @P_Monto,
        Comision = @P_Comision,
        DescuentoAplicado = @P_DescuentoAplicado,
        Fecha = @P_Fecha,
        MetodoPago = @P_MetodoPago
    WHERE Id = @P_Id;
END
GO
