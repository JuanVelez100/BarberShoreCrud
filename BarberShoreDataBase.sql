USE [BarberShoreDataBase]
GO

/****** Object:  Table [dbo].[Persona]    Script Date: 7/10/2021 10:00:27 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persona](
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Celular] [nchar](10) NULL,
	[Correo] [nvarchar](50) NULL,
	[Contraseña] [nvarchar](50) NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

