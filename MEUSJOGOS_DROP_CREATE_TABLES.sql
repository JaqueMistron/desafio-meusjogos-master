USE [MeusJogosBD]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] DROP CONSTRAINT [FK_jogo_amigo_usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_jogo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] DROP CONSTRAINT [FK_jogo_amigo_jogo]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_amigo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] DROP CONSTRAINT [FK_jogo_amigo_amigo]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo]'))
ALTER TABLE [dbo].[jogo] DROP CONSTRAINT [FK_jogo_usuario]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[amigo]'))
ALTER TABLE [dbo].[amigo] DROP CONSTRAINT [FK_amigo_usuario]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 22/02/2018 00:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
DROP TABLE [dbo].[usuario]
GO
/****** Object:  Table [dbo].[jogo_amigo]    Script Date: 22/02/2018 00:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[jogo_amigo]') AND type in (N'U'))
DROP TABLE [dbo].[jogo_amigo]
GO
/****** Object:  Table [dbo].[jogo]    Script Date: 22/02/2018 00:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[jogo]') AND type in (N'U'))
DROP TABLE [dbo].[jogo]
GO
/****** Object:  Table [dbo].[amigo]    Script Date: 22/02/2018 00:33:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[amigo]') AND type in (N'U'))
DROP TABLE [dbo].[amigo]
GO
/****** Object:  Table [dbo].[amigo]    Script Date: 22/02/2018 00:33:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[amigo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[amigo](
	[IdAmigo] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Telefone] [varchar](11) NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_amigo] PRIMARY KEY CLUSTERED 
(
	[IdAmigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jogo]    Script Date: 22/02/2018 00:33:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[jogo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[jogo](
	[IdJogo] [int] NOT NULL IDENTITY(1,1),
	[Titulo] [varchar](80) NOT NULL,
	[DataAquisicao] [datetime] NULL,
	[Versao] [varchar](20) NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_jogo] PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[jogo_amigo]    Script Date: 22/02/2018 00:33:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[jogo_amigo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[jogo_amigo](
	[IdJogoAmigo] [int] IDENTITY(1,1) NOT NULL,
	[IdJogo] [int] NOT NULL,
	[IdAmigo] [int] NOT NULL,
	[DataRetirada] [datetime] NOT NULL,
	[DataDevolucao] [datetime] NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_jogo_amigo] PRIMARY KEY CLUSTERED 
(
	[IdJogoAmigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 22/02/2018 00:33:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usuario]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Senha] [varchar](20) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[amigo]'))
ALTER TABLE [dbo].[amigo]  WITH CHECK ADD  CONSTRAINT [FK_amigo_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuario] ([IdUsuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[amigo]'))
ALTER TABLE [dbo].[amigo] CHECK CONSTRAINT [FK_amigo_usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo]'))
ALTER TABLE [dbo].[jogo]  WITH CHECK ADD  CONSTRAINT [FK_jogo_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuario] ([IdUsuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo]'))
ALTER TABLE [dbo].[jogo] CHECK CONSTRAINT [FK_jogo_usuario]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_amigo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo]  WITH CHECK ADD  CONSTRAINT [FK_jogo_amigo_amigo] FOREIGN KEY([IdAmigo])
REFERENCES [dbo].[amigo] ([IdAmigo])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_amigo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] CHECK CONSTRAINT [FK_jogo_amigo_amigo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_jogo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo]  WITH CHECK ADD  CONSTRAINT [FK_jogo_amigo_jogo] FOREIGN KEY([IdJogo])
REFERENCES [dbo].[jogo] ([IdJogo])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_jogo]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] CHECK CONSTRAINT [FK_jogo_amigo_jogo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo]  WITH CHECK ADD  CONSTRAINT [FK_jogo_amigo_usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[usuario] ([IdUsuario])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_jogo_amigo_usuario]') AND parent_object_id = OBJECT_ID(N'[dbo].[jogo_amigo]'))
ALTER TABLE [dbo].[jogo_amigo] CHECK CONSTRAINT [FK_jogo_amigo_usuario]
GO
