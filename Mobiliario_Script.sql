CREATE DATABASE [PracticaMobiliario]
GO
USE [PracticaMobiliario]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Mobiliario](
	[IdMobiliario] [bigint] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](20) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[Material] [varchar](50) NULL,
	[Color] [varchar](30) NULL,
	[Costo] [decimal](10, 2) NULL,
	[Activo] [bit] NOT NULL,
	[FechaRegistro] [datetime] NULL,
	[FechaActualizacion] [datetime] NULL
) 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Mobiliario_Insertar](
@Codigo varchar(20),
@Nombre varchar(100),
@Material varchar(50),
@Color varchar(30),
@Costo decimal(10,2)
)
as
begin

	insert into Mobiliario
	(
	Codigo,
	Nombre,
	Material,
	Color,
	Costo,
	Activo,
	FechaRegistro
	)
	values
	(
	@Codigo,
	@Nombre,
	@Material,
	@Color,
	@Costo,
	1,
	GETDATE()
	)

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Mobiliario_Actualizar](
@IdMobiliario bigint,
@Codigo varchar(20),
@Nombre varchar(100),
@Material varchar(50),
@Color varchar(30),
@Costo decimal(10,2)
)
as
begin

	update Mobiliario
	set
	Codigo = @Codigo,
	Nombre = @Nombre,
	Material = @Material,
	Color = @Color,
	Costo = @Costo,
	FechaActualizacion = GETDATE()
	where IdMobiliario = @IdMobiliario and Activo = 1
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Mobiliario_Eliminar](
@IdMobiliario bigint
)
as
begin

	update Mobiliario
	set
	Activo = 0,
	FechaActualizacion = GETDATE()
	where IdMobiliario = @IdMobiliario and Activo = 1
end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Mobiliario_ConsultarPorId]
(
@IdMobiliario bigint
)
as
begin

	select 
	[IdMobiliario],
	[Codigo],
	[Nombre],
	[Material],
	[Color],
	[Costo],
	[Activo],
	[FechaRegistro],
	[FechaActualizacion]
	from Mobiliario where IdMobiliario = @IdMobiliario

end

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Mobiliario_ConsultarTodos]
as
begin

	select 
	[IdMobiliario],
	[Codigo],
	[Nombre],
	[Material],
	[Color],
	[Costo],
	[Activo],
	[FechaRegistro],
	[FechaActualizacion]
	from Mobiliario where Activo = 1

end

GO

