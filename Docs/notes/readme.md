* create new sln `dotnet new sln -o BuberDinner`
* create new webapi project  `dotnet new webapi -o BuberDinner.Api`
* create new class lib `dotnet new classlib -o BuberDinner.Domain`
* add all projects to sln `dotnet sln add (ls -r **\*.csproj)   `
* add project reference `dotnet add .\BuberDinner.Application\ reference .\BuberDinner.Domain\`
* Add nuget package reference `dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions --version 8.0.0` or `dotnet add .\BuberDinner.Application\ package Microsoft.Extensions.DependencyInjection.Abstractions   `


* run project `dotnet run --project .\BuberDinner.Api\BuberDinner.Api.csproj --launch-profile https`


* run project with watch `dotnet watch run --project .\BuberDinner.Api\BuberDinner.Api.csproj --launch-profile https`


## Structure
* BubberDinner.Api
    * BubberDinner.Contracts
* BubberDinner.Infrasturcture
* BubberDinner.Applicaiton
* BuberDinner.Domain


## Global Error Handling
* Middleware
* ExceptionFilterAttribute
* UseExceptionHandler("/error")
* Problem Details + Problem Detail Custom Factory


## Flow Controle
* Exception
* OneOf
* FluentResults
* ErrorOr & Domain Errors

## CQRS
* CQS
* CQRS
* CQRS + MediatR

## Authentication & Authorizatipn

JwtBearer Authentication



## Process Modeling



## 3 Steps to model Domain

* Identifiy All entities (Proces modeling)
* Take each entity and look at relationship with othere entities
* Identify aggregates


## Domain Layer Structure

* Appraoch 1: Each type will have there own floder i.e.
    - Aggregates
    - Entities
    - ValueObjects
    - DomainEvents

Pro is its convienet as its easy to identify where particluar type is. However, this approach result in scattered types. i.e. if you want to see what is part of a single aggregate root its not very intutive and straight forward to identify all the entities, valueObjects and domain events which are part of aggregate root. 

Plus it also results in namespace cluttering. we will have to reference many namespaces i.e. Aggregates, Entities, ValuesObjects etc. In addition to this I will have access to many useless symbols in a particular context. (Loosing cohession)

* Approach 2

**Split by feature:** each aggregate will get its own heiraichy. i.e.
- Aggregate 1
    - Entities
    - ValueObjects
    - DomainEvents
    - Enums
    - Aggregate.cs

Pro is better cohession on cost of looking at high level picture of domain. Plus how do we define vlaue objects shared across multiple aggregates. One approach is to move these value objects to common (if its really a common object). If its accidental common then its better to duplicate.


### Things to do for scafolding project

* Add Director.Build.props
* Add stylcop analzer into `Director.Build.props`
* Configure 
* Add editor config `dotnet new editorconfig`


### Questions
Why we have different layer mappings i.e. api request -> service request -> domain model
                                          domain model <- service response/result <- api response. (Part 14)
Pros and Cons.
