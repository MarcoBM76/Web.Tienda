USE [ejemplo]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 02/02/2026 21:40:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[ArticuloId] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](25) NOT NULL,
	[Descripcion] [varchar](500) NULL,
	[Precio] [int] NOT NULL,
	[Imagen] [varbinary](max) NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK__Articulo__C0D725EDC5396511] PRIMARY KEY CLUSTERED 
(
	[ArticuloId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloTienda]    Script Date: 02/02/2026 21:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloTienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdArticulo] [int] NULL,
	[IdTienda] [int] NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK__Articulo__3214EC071A2B10D0] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteArticulo]    Script Date: 02/02/2026 21:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteArticulo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdArticulo] [int] NULL,
	[Fecha] [datetime] NULL,
 CONSTRAINT [PK__ClienteA__3214EC07AFA78655] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 02/02/2026 21:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ApellidoP] [varchar](50) NOT NULL,
	[ApellidoM] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tienda]    Script Date: 02/02/2026 21:40:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tienda](
	[TiendaId] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [varchar](50) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TiendaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArticuloTienda] ADD  CONSTRAINT [DF__ArticuloT__Fecha__5EBF139D]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[ClienteArticulo] ADD  CONSTRAINT [DF__ClienteAr__Fecha__6383C8BA]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[ArticuloTienda]  WITH CHECK ADD  CONSTRAINT [FK__ArticuloT__IdArt__5CD6CB2B] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulos] ([ArticuloId])
GO
ALTER TABLE [dbo].[ArticuloTienda] CHECK CONSTRAINT [FK__ArticuloT__IdArt__5CD6CB2B]
GO
ALTER TABLE [dbo].[ArticuloTienda]  WITH CHECK ADD  CONSTRAINT [FK__ArticuloT__IdTie__5DCAEF64] FOREIGN KEY([IdTienda])
REFERENCES [dbo].[Tienda] ([TiendaId])
GO
ALTER TABLE [dbo].[ArticuloTienda] CHECK CONSTRAINT [FK__ArticuloT__IdTie__5DCAEF64]
GO
ALTER TABLE [dbo].[ClienteArticulo]  WITH CHECK ADD  CONSTRAINT [FK__ClienteAr__IdArt__628FA481] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulos] ([ArticuloId])
GO
ALTER TABLE [dbo].[ClienteArticulo] CHECK CONSTRAINT [FK__ClienteAr__IdArt__628FA481]
GO
ALTER TABLE [dbo].[ClienteArticulo]  WITH CHECK ADD  CONSTRAINT [FK__ClienteAr__IdCli__619B8048] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[ClienteArticulo] CHECK CONSTRAINT [FK__ClienteAr__IdCli__619B8048]
GO
