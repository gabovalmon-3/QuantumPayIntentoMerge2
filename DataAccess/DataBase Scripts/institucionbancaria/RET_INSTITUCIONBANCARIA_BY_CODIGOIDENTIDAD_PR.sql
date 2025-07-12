CREATE PROCEDURE RET_INSTITUCIONBANCARIA_BY_CODIGOIDENTIDAD_PR
    @P_codigoIdentidad INT
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
    WHERE codigoIdentidad = @P_codigoIdentidad
END
GO
