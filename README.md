# DomainDesign

Projeto desenvolvido em C# com foco na aplicação dos conceitos de Domain-Driven Design (DDD), utilizando uma estrutura organizada para representar entidades, objetos de valor, repositórios e regras de negócio de forma desacoplada e sustentável.

## Objetivo

O principal objetivo deste projeto é servir como laboratório de estudos para modelagem de domínio, aplicando boas práticas de desenvolvimento orientado ao domínio e construção de software com alta coesão e baixo acoplamento.

## Conceitos Aplicados

- Domain-Driven Design (DDD)
- Entities
- Value Objects
- Repository Pattern
- Encapsulamento de regras de negócio
- Tratamento de exceções de domínio
- Organização em camadas
- Princípios SOLID

## Estrutura do Projeto

```text
DomainDesign
│
├── Entities/
├── ValueObjects/
├── Repositories/
├── Exceptions/
├── Shared/
├── Properties/
│
├── Domain.csproj
└── DomainDesign.sln
```

### Entities

Representam objetos que possuem identidade única dentro do domínio.

Exemplos:

- Usuário
- Cliente
- Funcionário
- Pedido

As entidades carregam comportamento e regras de negócio relacionadas ao seu contexto.

### ValueObjects

Representam objetos imutáveis definidos por seus valores e não por identidade.

Exemplos:

- Email
- CPF
- Endereço
- Telefone

Dois Value Objects são considerados iguais quando possuem os mesmos valores.

### Repositories

Responsáveis por abstrair o acesso aos dados do domínio.

Objetivos:

- Isolar regras de persistência
- Facilitar testes
- Reduzir acoplamento com banco de dados

### Exceptions

Contém exceções específicas do domínio para garantir que regras de negócio sejam respeitadas.

Exemplo:

```csharp
throw new DomainException("CPF inválido.");
```

### Shared

Componentes compartilhados entre os diferentes módulos do domínio.

## Tecnologias Utilizadas

- C#
- .NET
- Visual Studio
- Git
- GitHub

## Como Executar

### Clonar o repositório

```bash
git clone https://github.com/LuisAmarall/DomainDesign.git
```

### Acessar a pasta

```bash
cd DomainDesign
```

### Abrir a solução

```bash
DomainDesign.sln
```

Ou abra diretamente pelo Visual Studio.

## Aprendizados

Este projeto foi criado para aprofundar conhecimentos em:

- Modelagem de domínio
- Arquitetura de software
- Design Patterns
- Clean Code
- DDD Tático
- Boas práticas com .NET

## Melhorias Futuras

- [ ] Adicionar camada Application
- [ ] Adicionar camada Infrastructure
- [ ] Implementar testes unitários
- [ ] Implementar validações mais robustas
- [ ] Adicionar documentação de arquitetura
- [ ] Aplicar CQRS
- [ ] Adicionar exemplos práticos de agregados

## Autor

Luis Amaral

GitHub:
https://github.com/LuisAmarall

LinkedIn:
Adicione seu LinkedIn aqui
