using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
#region Package Manager Consol Üzerinden DB First
var db2 = @"Scaffold - DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Nortwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False' Microsoft.EntityFrameworkCore.SqlServer 

-Tables Categories,Products 
-OutputDir Models 
-Context dbcontext 
-ContextDir Contexts
-NameSpace Example.Entities
-ContextNamespace Example.Contexts

-Force
";

#endregion



#region Dotnet CLI üzerinden db first

var db= @"dotnet ef dbcontext scaffold 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Nortwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False' Microsoft.EntityFrameworkCore.SqlServer

--table Categories --table Products -o Models 
--context Contexts 
--context-dir Contexts
--output-dir Entities
--context-namespace Example.Contexts
--namespace Example.Entities

--force
";

#endregion
