-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerContratoFutbolista 
	@DNIoNIE CHAR(9)
AS
BEGIN
    
	   SELECT codContrato, Equipos.nomEquipo, Ligas.nomLiga, fechaInicio, fechaFin, precioAnual, precioRecision 
	   FROM Contratos 
		INNER JOIN Equipos ON Equipos.codEquipo = Contratos.codEquipo 
		INNER JOIN Ligas ON Ligas.codLiga = Equipos.codLiga 
       WHERE Contratos.codDNIoNIE = @DNIoNIE 
       ORDER BY fechaInicio;
   
END
GO

--EXEC ObtenerContratoFutbolista '11111111M';