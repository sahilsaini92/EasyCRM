1. In the webconfig file replace the connection string with sql server credentials.

			 connectionString="Data Source=SAHILDEV\SQLSERVER;Initial Catalog=EasyCRM;persist security info=True;user id=sa;password=admin@123;Trusted_Connection=true" />
2. Create db with the name EasyCRM in sql server.
3. Run migration from nuget package manager console with these 2 commands

Add-Migration "new migration".
Update-Database

4. Run the code in Visual studio.
5. Then publish the application on the location.
6. Deploy the application on the iis.