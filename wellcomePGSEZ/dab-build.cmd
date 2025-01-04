@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mssql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
dab add "Department" --source "[dbo].[department]" --fields.include "id,dName" --permissions "anonymous:*" 
dab add "Phone" --source "[dbo].[phones]" --fields.include "id,phoneNumber,pCode,pName,pDep,pSerial,propertyNumber" --permissions "anonymous:*" 
dab add "Software" --source "[dbo].[softwares]" --fields.include "id,sName,sAddress,sImagePath,sExplain" --permissions "anonymous:*" 
@echo Adding views and tables without primary key
@echo Adding relationships
dab update Phone --relationship Department --target.entity Department --cardinality one
dab update Department --relationship Phone --target.entity Phone --cardinality many
@echo Adding stored procedures
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **
