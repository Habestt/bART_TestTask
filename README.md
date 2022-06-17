# bART_TestTask
#### How to use my program ####
* type "update-database" in Package Manager Console
* run a project

#### Libraries used ####
* Autofac
* AutoMapper
* Entity Framework Core
* LINQ

#### Presentation ####
* the project is based on multi-layered architecture: __Data Access__, __Business Logic__, __API__ layers
* Autofac container and AutoMapper configuration were moved to Configuration Folder
* DataBase structure was build by code first 
* Used repository pattern
* Added many exeptions
* All request to DB are asynchronous
* On each controller you can create and and get gata
* On contact controller in CreateOrUpdate you can create or update contact by following the last requirement in bART_Task
* DataBase relationship:
* * Incident - Account => 1 - Many 
* * Account - Contact => 1 - Many 