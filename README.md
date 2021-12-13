# DevOpsSec
NCI DevOpsSec

/*Clone Project*/
Use github link and clone the repository from the following link https://github.com/dineshkanojia/DevOpsSec.git 

/*Database*/
For this project we have use SQL Server 2016, open and execute DBScript.sql file; this will create database and all relevant tables with demo records for testing purpoose.

/*Connection String*/
Once database is ready then create a connection string in a followng format: Server={dbServer};Database={dbname};Trusted_Connection=True;MultipleActiveResultSets=true and replace ConnectionString attribute values inside  appsetting.json file  

/*All Set*/
Set LibraryApp as a default project and press f5 the application will get compiled and login screen appear on browser.

/*Login Details*/
For Demo use userid: dinesh@123.com and password: Next.com@123, the system will authenticate and takes user to landing page.

