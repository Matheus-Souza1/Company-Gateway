# Company Gateway
Foi desenvolvido dois microsserviços completo de gerenciamento de produtos e clientes, e uma api gateway para fazer o redirecionamento de requisições para os microsserviços apropriados. 

## Tecnologias e práticas utilizadas
- ASP.NET Core com .NET 6
- Entity Framework Core
- Entity Framework Core In Memory
- Ocelot
- Swagger
- Injeção de Dependência
- Programação Orientada a Objetos
- Padrão Repository
- Docker

## Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Produto.
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Clientes.

## Formas de Executar a aplicação

O projeto pode ser executado em contrainers pois no repositorio se encontra os arquivos de configuração dos mesmos. Com isso basta executar o seguinte comando na raiz do projeto.
``` docker-compose up --build```

Mas caso não desejar executar em containers, basta ir nas propriedades da solução em 'projetos de inicialização' e marcar a opção 'Vários projetos de inicialização'

![startup](https://user-images.githubusercontent.com/54037557/197655355-337f0d1a-203f-498c-952b-0ea54ac3948a.jpg)

## Evidências
Ao executar os microsserviços, podemos acessar cada um separadamente(Devido a configuração feita pelo containers)

- Microsserviço de produto
![Micro-product](https://user-images.githubusercontent.com/54037557/197653796-0e07f4af-fcc4-4ad4-abde-c638e11a6411.jpg)

- Microsserviço de cliente
 ![Micro-Client](https://user-images.githubusercontent.com/54037557/197653838-15897deb-06e8-44c9-8abf-50478d031519.jpg)

Ou podemos acessar cada microsserviço pela nossa API Gateway

- Gateway Produto
![Gateway-Product](https://user-images.githubusercontent.com/54037557/197654035-467ab31d-757b-401a-acd4-8728eab21fb5.jpg)

- Gateway Cliente
![gateway-client](https://user-images.githubusercontent.com/54037557/197654069-0e79fc9a-fe81-4aa1-8073-db06a1a800d5.jpg)

 ---
 
 Feito por Matheus Souza 
 👋 Entre em contato! 

[![Linkedin Badge](https://img.shields.io/badge/Matheus%20Souza%20-blue?Style=flat&logo=linkedin&labelColor=blue=https://www.linkedin.com/in/matheus-souza-silva/)](https://www.linkedin.com/in/matheus-souza-silva/)
