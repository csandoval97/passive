# Passive

Identity Management for ACM@UIC written in C# and Typescript with ASP.NET Core and Angular.

## Getting Started

- `dotnet build`
- `dotnet run`

# Configuration

If not running as user with appropriate privleges in AD on a domain joined machine, the following environment variables are required.

- `PASSIVE_AD_HOST`
- `PASSIVE_AD_USER`
- `PASSIVE_AD_PASSWORD`

Optional

- `PASSIVE_AD_HOST`
- `PASSIVE_AD_USER`
- `PASSIVE_AD_PASSWORD`
- `PASSIVE_AD_DOMAIN`
- `PASSIVE_AD_BASEDN`
- `PASSIVE_AD_USERSOU`
- `PASSIVE_AD_GROUPSOU`
- `PASSIVE_AD_PAIDGROUP`
- `PASSIVE_AD_NOTPAIDGOUP`
- `PASSIVE_AD_DEFUNCTGOUP`
- `PASSIVE_AD_ALUMNIGROUP`

# License

MIT | Copyright (c) 2019 ACM@UIC
