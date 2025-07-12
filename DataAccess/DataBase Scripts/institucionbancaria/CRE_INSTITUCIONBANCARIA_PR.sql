CREATE PROCEDURE CRE_INSTITUCIONBANCARIA_PR
    @P_codigoIdentidad INT,
    @P_codigoIBAN INT,
    @P_cedulaJuridica NVARCHAR(30),
    @P_direccionSedePrincipal NVARCHAR(100),
    @P_telefono INT,
    @P_estadoSolicitud NVARCHAR(20),
    @P_correoElectronico NVARCHAR(50)
AS
BEGIN
    INSERT INTO institucionBancaria (
        codigoIdentidad,
        codigoIBAN,
        cedulaJuridica,
        direccionSedePrincipal,
        telefono,
        estadoSolicitud,
        correoElectronico
    )
    VALUES (
        @P_codigoIdentidad,
        @P_codigoIBAN,
        @P_cedulaJuridica,
        @P_direccionSedePrincipal,
        @P_telefono,
        @P_estadoSolicitud,
        @P_correoElectronico
    )
END
GO
