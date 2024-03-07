# DesafioHandcom

Projeto desenvolvido com o intuíto de avaliação no processo seletivo da Handcom.

O objetivo foi desenvolver um aplicativo Web que permita os usuários navegar, pesquisar e criar postagens sobre vários tópicos.

# Tecnologias utilizadas

  Back-End: .NET 4.8, C# e Blazor 8
  
  Front-End: Html e CSS

# Bibliotecas utilizadas

  Blazored.LocalStorage
  
  SweetAlert2
  
  AspNetCore.Authorization
  
  AspNetCore.Authentication.JwtBearer
  
  EntityFrameworkCore.InMemory

# A aplicação contém 3 projetos:

  DesafioHandcom.Client (Projeto onde fica toda a parte de iteração com o usuário)
  
  DesafioHandcom.Server (Projeto onde toda a regra de negócio é desenvolvida)
  
  DesafioHandcom.Shared (Projeto onde está alocado os Models e DTO para comunicação entre o Client e o Server)

# Sobre o Projeto

Todas as tarefas que eram necessárias para o desenvolvimento do desafio foram feitas, entre elas:
Interação com banco de dados, criação de post, criação de comentário, API REST para consumo de informações, Filtros, Paginação, Design Responsivo e validação das informações

A aplicação foi desenvolvida utilizando banco de dados InMemory

Ao executar a aplicação, algumas tabelas são preenchidas com informações "mock"

Na tabela Users é inserido as seguintes informações:

{ Id = 1, Name = "User 1", Email = "user1@handcom.com", Password = "user1", CreatedAt = DateTime.Now });

{ Id = 2, Name = "User 2", Email = "user2@handcom.com", Password = "user2", CreatedAt = DateTime.Now });
 
Na tabela Topics é inserido as seguintes informações:

{ Id = 1, Name = "Carro" });

{ Id = 2, Name = "Futebol" });

{ Id = 3, Name = "Tecnologia" });

Para efetuar os testes na aplicação, basta efetuar o login com algum usuário dito anteriormente.

Foi disponibilizado algumas API's para o consumo externo.
[HttpGet]
"/api/getposts" Esse request retorna todos os posts e comentários cadastrados no banco de dados.

[HttpGet]
"/api/getPostById?={id}" Esse request retorna o post e os comentários do post por ID.

[HttpGet]
"/api/getAllAuthors" Esse request retorna todos os usuários cadastrados no banco de dados.

[HttpGet]
"GetAuthorById?={id}" Esse request retorna o usuário por ID.

[HttpGet]
"GetTopics" Esse request retorna todos os tópicos cadastrados no banco de dados.

[HttpGet]
"GetTopicById?={id}" Esse request retorna o tópico por ID.


