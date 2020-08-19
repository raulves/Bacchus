FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

COPY BLL.App/*.csproj ./BLL.App/
COPY BLL.App.DTO/*.csproj ./BLL.App.DTO/
COPY BLL.Base/*.csproj ./BLL.Base/
COPY Contracts.BLL.App/*.csproj ./Contracts.BLL.App/
COPY Contracts.BLL.Base/*.csproj ./Contracts.BLL.Base/

COPY Contracts.DAL.App/*.csproj ./Contracts.DAL.App/
COPY Contracts.DAL.Base/*.csproj ./Contracts.DAL.Base/
COPY DAL.App.DTO/*.csproj ./DAL.App.DTO/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY DAL.App.HttpClient/*.csproj ./DAL.App.HttpClient/
COPY DAL.Base/*.csproj ./DAL.Base/
COPY DAL.Base.EF/*.csproj ./DAL.Base.EF/
COPY DAL.Base.HttpClient/*.csproj ./DAL.Base.HttpClient/

COPY Contracts.Domain/*.csproj ./Contracts.Domain/
COPY Domain.App/*.csproj ./Domain.App/
COPY Domain.Base/*.csproj ./Domain.Base/

COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore


# copy everything else and build app
COPY BLL.App/. ./BLL.App/
COPY BLL.App.DTO/. ./BLL.App.DTO/
COPY BLL.Base/. ./BLL.Base/
COPY Contracts.BLL.App/. ./Contracts.BLL.App/
COPY Contracts.BLL.Base/. ./Contracts.BLL.Base/

COPY Contracts.DAL.App/. ./Contracts.DAL.App/
COPY Contracts.DAL.Base/. ./Contracts.DAL.Base/
COPY DAL.App.DTO/. ./DAL.App.DTO/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY DAL.App.HttpClient/. ./DAL.App.HttpClient/
COPY DAL.Base/. ./DAL.Base/
COPY DAL.Base.EF/. ./DAL.Base.EF/
COPY DAL.Base.HttpClient/. ./DAL.Base.HttpClient/

COPY Contracts.Domain/. ./Contracts.Domain/
COPY Domain.App/. ./Domain.App/
COPY Domain.Base/. ./Domain.Base/

COPY WebApp/. ./WebApp/

WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out



FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:SqlServerConnection="Server=tcp:bacchus.database.windows.net,1433;Initial Catalog=bacchus;Persist Security Info=False;User ID=bacchus;Password=Uptime12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
COPY --from=build /app/WebApp/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]
