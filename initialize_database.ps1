docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=StrongPassword!123" -p 1433:1433 --name Nonsense --hostname localhost -d mcr.microsoft.com/mssql/server:2022-latest