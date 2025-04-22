dotnet new webapi        -n AS.FOS.Order.API
dotnet new classlib      -n AS.FOS.Order.Application
dotnet new classlib      -n AS.FOS.Order.Domain
dotnet new classlib      -n AS.FOS.Order.Infrastructure
dotnet new classlib      -n AS.FOS.Order.Persistence
dotnet new classlib      -n AS.FOS.Order.Contracts
dotnet new xunit         -n AS.FOS.Order.UnitTests

dotnet sln add AS.FOS.Order.API/AS.FOS.Order.API.csproj
dotnet sln add AS.FOS.Order.Application/AS.FOS.Order.Application.csproj
dotnet sln add AS.FOS.Order.Domain/AS.FOS.Order.Domain.csproj
dotnet sln add AS.FOS.Order.Infrastructure/AS.FOS.Order.Infrastructure.csproj
dotnet sln add AS.FOS.Order.Persistence/AS.FOS.Order.Persistence.csproj
dotnet sln add AS.FOS.Order.Contracts/AS.FOS.Order.Contracts.csproj
dotnet sln add AS.FOS.Order.UnitTests/AS.FOS.Order.UnitTests.csproj

// 
<ItemGroup>
  <Compile Include="Aggregates\**\*.cs" />
  <Compile Include="Entities\**\*.cs" />
  <Compile Include="ValueObjects\**\*.cs" />
  <Compile Include="Enums\**\*.cs" />
  <Compile Include="Events\**\*.cs" />
  <Compile Include="Abstractions\**\*.cs" />
</ItemGroup>
