# BlazingApple.Components :apple:

:fire:  A totally copacetic, easy-to-use and lightweight front-end Blazor Components package.
This front-end Razor Class Library is intended to be used by Blazor WASM projects, and targets .NET 5.

## About BlazingApples
BlazingApples is an open-source set of packages that aims to speed application development for Blazor WebAssembly organizations.

:zap: Check out the [demo site here](https://blazorsimplesurvey.azurewebsites.net/displaysurvey), [or this blog post on how the components work](https://blazorhelpwebsite.com/ViewBlogPost/44)!

# :video_camera: Demo
  `TODO: Add Demo gif`.

# :wrench: Installation

## 1. Get the required dependencies.

1. On Client Project, right click and get to the NuGet Package Manager ("Manage NuGetPackages").
2. Install `BlazingApple.Components` ([package also located here](https://www.nuget.org/packages/BlazingApple.Components/)).

3. Add the following to `Program.cs's Main`:
```
IConfiguration configuration = builder.Configuration;
services.AddBlazingAppleComponents(configuration);
```

4. In your `index.html` file, add the required Radzen style and script:
```
<link href="_content/BlazingApple.Components/css/blazingAppleComponents.css" rel="stylesheet" />
<script src="_content/BlazingApple.Components/scripts/blazingAppleComponents.js"></script> <! -- only needed for a handful of components) -->
```

5. Add BlazingApple.Components namespaces to your imports file. Now you should be all set to use the components.

<hr/>

## :white_flower: Credits

- Build with love :blue_heart:, using [Radzen's Component Library](https://razor.radzen.com/).

## :pencil: Authors

1. [Taylor White](https://twitter.com/taychasewhite)

## :scroll: License

![License: GPL v2](https://img.shields.io/badge/License-GPL%20v2-blue.svg)

- **[GPLv2](https://www.gnu.org/licenses/old-licenses/gpl-2.0.en.html)**

