CREATE PROCEDURE RET_INSTITUCIONBANCARIA_BY_IBAN_PR
    @P_codigoIBAN INT
AS
BEGIN
    SELECT 
        idInstBancaria,
        codigoIdentidad,
        codigoIBAN,
        cedulaJuridica,
        direccionSedePrincipal,
        telefono,
        estadoSolicitud,
        correoElectronico
    FROM institucionBancaria
    WHERE codigoIBAN = @P_codigoIBAN
END
GO
