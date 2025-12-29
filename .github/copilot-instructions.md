# AI Coding Agent Instructions for myMon3y

## Architecture Overview
- **Blazor United Application**: Server-side ASP.NET Core app hosts a Blazor WebAssembly client. Components can render on server (SSR) or client (WASM) based on `@rendermode` attributes.
- **Project Structure**:
  - `MyMoney/`: Server project (ASP.NET Core Web API + Blazor SSR)
  - `MyMoney.Client/`: Client project (Blazor WASM)
  - Shared components in `MyMoney/Components/`
- **Data Flow**: No external APIs yet; components handle data locally. Future integrations likely via server-side controllers.

## Key Technologies & Patterns
- **.NET 10.0** with nullable enabled and implicit usings
- **Tailwind CSS**: Styles built via npm in `MyMoney.csproj` BuildCss target. Use utility classes directly in `.razor` files (e.g., `class="bg-blue-500 text-white px-4 py-2 rounded"` in `Counter.razor`)
- **Render Modes**:
  - `@rendermode InteractiveAuto`: Components interactive on client, static on server
  - `@attribute [StreamRendering]`: Server-side streaming for async data loading
- **Central Package Management**: Versions defined in `Directory.Packages.props`

## Development Workflows
- **Build**: `dotnet build` automatically runs Tailwind CSS compilation via `BuildCss` target
- **Run/Dev**: `dotnet watch run --project mymon3y.slnx` for hot reload
- **Debug**: Launch via VS Code debugger using `https` profile (ports 7062/5198)
- **CI/CD**: GitHub Actions in `.github/workflows/build.yml`

## Conventions & Best Practices
- **Component Location**: Server components in `MyMoney/Components/`, client-specific in `MyMoney.Client/`
- **Routing**: Defined in `Routes.razor`, includes both server and client assemblies
- **Styling**: Tailwind-first; output compiled to `wwwroot/output.css`
- **Error Handling**: `BlazorDisableThrowNavigationException=true` in build props for smoother navigation
- **No Tests Yet**: Uncomment test step in CI when adding unit/integration tests

## Integration Points
- **Static Assets**: Served from `wwwroot/`, includes compiled CSS and JS
- **Configuration**: `appsettings.json` for environment-specific settings
- **Future Extensions**: Add API controllers in `MyMoney/` for data persistence, likely Entity Framework + SQL Server

Reference: `Program.cs`, `App.razor`, `Directory.Build.props` for setup patterns.