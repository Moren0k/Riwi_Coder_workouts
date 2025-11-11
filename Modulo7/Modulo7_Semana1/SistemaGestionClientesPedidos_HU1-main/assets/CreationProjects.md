# Creation of Projects

1. **Create a new folder**

    ```bash
    mkdir SystemGestionClients
    cd SystemGestionClients
    ```

2. **Create a solution file**

    ```bash
    dotnet new sln -n solution
    ```

3. **Create the 4 projects (API, Application, Domain, Infrastructure)**

    ```bash
    dotnet new webapi -n System.Api  
    dotnet new classlib -n System.Application  
    dotnet new classlib -n System.Domain  
    dotnet new classlib -n System.Infrastructure
    ```

4. **Add the projects to the solution**

    ```bash
    dotnet sln add System.Api
    dotnet sln add System.Application
    dotnet sln add System.Domain
    dotnet sln add System.Infrastructure
    ```

5. **Add project references**

    ```bash
    dotnet add System.Api reference System.Application
    dotnet add System.Application reference System.Domain
    dotnet add System.Infrastructure reference System.Domain
    ```

---
