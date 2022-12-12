# Personal Management and Tracker

## What is this project about?

Personal Essential is a project to build Full Stack application with ASP.NET Core (.NET 6) Web API following Clean Architecture. 
It is a personal organizer and tracker.
- user will be able to write a diary
- access to the data for the google fitness account(steps, amount of sleep, weight, etc..)
- make it  assessment of his day
- and a lot more...

Frontend for this application is built using Angular and placed in another repository.

Personal Management and Tracker - working on the app in progress ...

## What does the to this day the Solution offer?

- [x] Clean Architecture with separated layers for API, Application, Domain, Infrastructure, and Presentation
- [x] UnitOfWork and Repositories
- [x] Entity Framework Core migrations with MS SQL
- [x] Implemented CRUD for Entities following CQRS, with segregated Commands and Queries
- [x] Fluent Validation of input inside the Command
- [x] NetArchTest for testing architecture dependencies
- [x] Auditable Entities with Entity Tracking
- [x] Mapster implementation for conversion objects
- [x] Authorization with a google account and access to Google Fit via Google Cloud
- [x] Azure Key Vault stores access keys for Google Rest API

## Technologies Used

* ASP.NET Core (.NET 6) Web API
* Entity Framework Core (EFCore 6)
* Mapster for .NET 6
* Fluent Validation for .NET 6
* MediatR 
* SwaggerUI
* Azure Seciurity - Key Vault
* Google.Apis.Fitness.v1
* Xunit
* NetArchTest
* Fluent Assertions
