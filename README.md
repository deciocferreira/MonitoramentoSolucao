# QueroSolucao

Esta solução é baseada em .NET, Prometheus e Docker.

Uma aplicação simples foi concebida em .NET (versão 5.0).

Considero o prometheus como o coração do sistema, onde ele é responsável por ir na aplicação e buscar as métricas de sistema.

O Docker age criando um container para a aplicação e o Prometheus.

Com isso, Temos a possibilidade de adicionar os Endpoints no arquivos **Startaup.cs** do projeto e depois acessar a aplicação para verificar as métricas.

![image](https://user-images.githubusercontent.com/12403699/222585362-1c214d13-7c13-45f8-bfc5-f4aa9d9b6fa8.png)

Os respectivos arquivos estão no repo representando a criação da infra.
