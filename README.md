# bugrepro_dotnetcore_missingmethod
Issue reproduction for AspNetCore.TestHost throwing a missing method exception when running in a dotnet core app targeting the full framework.

When referencing `Microsoft.AspNetCore.TestHost` (https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/) nuget package in a .NET Core project that targets `net461`, a `MissingMethodException` 
is thrown when trying to create an HttpClient:

```
Error Message:
 System.MissingMethodException : 
   Method not found: 'System.Net.Http.HttpClient Microsoft.AspNetCore.TestHost.TestServer.CreateClient()'.
```

It is also thrown when creating a "classic" .NET Framework class library and using `PackageReferences` for NuGet.

The exception is not thrown when targeting `netcoreapp1.0`, or when creating a "classic" .NET Framework class library using `packages.config` for NuGet,
**or** when running under as a console app instead of a unit test.

Adding auto binding redirects fixes the issue (see: https://github.com/aspnet/Hosting/issues/926#issuecomment-276773662):
```
    <GenerateBindingRedirectsOutputType>true</GenerateBindingRedirectsOutputType>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
```

All projects include a single xUnit test that creates a `TestServer` and then creates an `HttpClient` from that server.

Projects included for reproduction of the issue:
* **TestHostDebug**: .NET Core xUnit project targeting `net461`
* **TestHostDebugNetCore**: .NET Core xUnit project targeting `netcoreapp1.0`
* **TestHostDebugFull**: Full .NET Framework xUnit project, using csproj PackageReferences to reference Microsoft.AspNetCore.TestHost
* **TestHostDebugPackageConfig**: Full .NET Framework xUnit project, using traditional *packages.config* to reference Microsoft.AspNetCore.TestHost
* **TestHostDebugConsole**: .NET Core console app targeting `net461`
* **TestHostDebugBindingRedirect**: .NET Core xUnit project targeting `net461` with auto binding redirects.
