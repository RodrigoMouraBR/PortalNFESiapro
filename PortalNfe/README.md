##CONFIGURAÇÃO APLICAÇÃO

Docker run: 
 docker run --name postgres-container -e POSTGRES_PASSWORD=portal -e POSTGRES_USER=portal -e POSTGRES_DB=portal -v /path/on/host:/var/lib/postgresql/data -p 5432:5432  -d postgres:latest

PASSOS: =======================================================================================

SETAR PortalNFE.Api
Set as Startup Project: PortalNFE.Api

=======================================================================================

1 - ) Default Project: PortalNFE.Register.Companies.Data (Package Manager Console)

2 - ) add-migration InitialRegiterCompany -Context PortalNFECompaniesContext

3 - ) update-database -Context PortalNFEUserPersonContext

=======================================================================================

1 - ) Default Project: PortalNFE.Register.Users.Data (Package Manager Console)

2 - ) add-migration InitialRegiterUser -Context PortalNFEUserPersonContext

3 - ) update-database -Context PortalNFEUserPersonContext

=======================================================================================

1 - ) Default Project: PortalNFE.Identity.Data (Package Manager Console)

2 - ) add-migration InitialRegiterUser -Context IdentityContext

3 - ) update-database -Context IdentityContext


