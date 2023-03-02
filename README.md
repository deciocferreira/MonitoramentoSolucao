# Quero Solução SRE

Esta solução é baseada em .NET, Prometheus e Docker.

Uma aplicação simples foi concebida em .NET (versão 5.0).

Considero o prometheus como o coração do sistema, onde ele é responsável por ir na aplicação e buscar as métricas de sistema da aplicação.

A adição dos Endpoints está centralizada no arquivo **Startaup.cs** do projeto. Para verificar as métricas basta acessar a aplicação(imagem a seguir para representar a coleta de métrica do *HTTP Status code*).

![image](https://user-images.githubusercontent.com/12403699/222585362-1c214d13-7c13-45f8-bfc5-f4aa9d9b6fa8.png)

Depois de configurado os devidos Endpoints no projeto, podemos criar uma imagem customizada para ser entregue por algum provider de nuvem.

Os respectivos arquivos estão no repo representando a criação da infra.
