# Meus Jogos
Repositório responsável por armazenar o código fonte do projeto MeusJogos, o qual tem o intuito de gerenciar os jogos que empresto aos meus amigos.

# Desafio
Seus amigos vivem pedindo seus jogos emprestados. Muitas vezes você quer jogar um jogo e não sabe com quem está. 
Pensando nisso, crie um sistema que você possa gerenciar os empréstimos dos seus jogos.

O sistema deverá permitir a inserção/edição/exclusão de amigos e jogos, 
além de permitir o gerenciamento e visualização dos seus jogos, dos amigos e qual jogo está com quem.

# Requisitos técnicos:
- O sistema deverá possuir controle de acesso (Segurança/Login).
 NÃO será necessário a implementação de permissões de usuário.
- MVC + JQuery + SQL Server

# Descrição do Projeto
O projeto foi implementado utilizando as seguintes tecnologias/recursos:
- SQL Server 2014;
- Visual Studio 2017
- MVC 5 com razor;
- Entity Framework 6;
- AutoMapper;
- Autofac
- Jquery;
- Bootstrap

# Instalação/Execução
Executar os scripts abaixo, responsáveis pela criação da base de dados e entidades:

- 1 - MEUSJOGOS_CREATE_DATABASE
- 2 - MEUSJOGOS_DROP_CREATE_TABLES

Alterar na solution o Web.config do projeto MeusJogos, informando a connection string da base de dados na máquina local.
