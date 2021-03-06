<h1 align="center">Instagram</h1>

<p align="center">
<img src="https://img.shields.io/badge/made%20by-krzysztoftalar-blue.svg" />

<img src="https://img.shields.io/badge/.NET%20Core-3.1.0-blueviolet" />

<img src="https://img.shields.io/badge/WPF%20.NET%20Framework-4.8-informational" />

<img src="https://img.shields.io/badge/license-MIT-green" />
</p>

## About The Project

_The application was created for [Programming IV](https://www.wbmii.ath.bielsko.pl) classes.
The project implements Dependency Injection and MVVM patterns._

<br/>

<p align="center">
  <img src="./src/DesktopUI/Assets/screen3.png" width="70%" alt="">
</p>

<p align="center">
  <img src="./src/DesktopUI/Assets/screen2.png" width="70%">
</p>

<p align="center">
  <img src="./src/DesktopUI/Assets/screen1.png" width="70%">
</p>

<p align="center">
  <img src="./src/DesktopUI/Assets/screen4.png" width="70%">
</p>

## Features

- Registration, login with email verification
- Uploading photos to the cloud
- Real-time chat with SignalR
- Profile page
- Subscription (follow / unfollow)

## Built With

| Server                                                                                                           | Client                                                                                                           |
| ---------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------- |
| [.NET Core](https://docs.microsoft.com/en-us/dotnet/) 3.1.0                                                      | [WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/) .NET Framework 4.8                                 |
| [ASP.NET Web API](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-3.1)                     | [Caliburn.Micro](https://caliburnmicro.com/)                                                                     |
| [Entity Framework](https://docs.microsoft.com/en-us/ef/)                                                         | [SignalR](https://docs.microsoft.com/pl-pl/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio) |
| [SignalR](https://docs.microsoft.com/pl-pl/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio) | [AutoMapper](https://automapper.org/)                                                                            |
| [MediatR](https://github.com/jbogard/MediatR/wiki)                                                               | [Material Design](http://materialdesigninxaml.net/) 
| [AutoMapper](https://automapper.org/)                                                                            |
| [Swagger](https://swagger.io/)                                                                                   |
| [Cloudinary](https://cloudinary.com/)                                                                            |
| [SendGrid](https://sendgrid.com/)                                                                              |

## Getting Started

### Prerequisites

- .NET Core 3.1.0
- .NET Framework 4.8
- SQL Server
- Cloudinary account
- SendGrid account

### Installation

1. Create an account on Cloudinary and SendGrid.
2. In solution WebUI in `appsettings.json` set your Cloudinary, SendGrid account details and database connection string.

```JSON
"Cloudinary": {
    "CloudName": "ENTER YOUR ACCOUNT DETAIL",
    "ApiSecret": "ENTER YOUR ACCOUNT DETAIL",
    "ApiKey": "ENTER YOUR ACCOUNT DETAIL"
  }
```

```JSON
"SendGrid": {
    "SendGridKey": "ENTER YOUR ACCOUNT DETAIL"
  }
```

```JSON
"ConnectionStrings": {
    "EFInstagramData": "ENTER YOUR CONNECTION STRING"
  },
```

3. Set multiple startup projects: WebUI, DesktopUI and MVCApp.
4. Build and run the solution.

## License

This project is licensed under the MIT License.

## Contact

**Krzysztof Talar** - [Linkedin](https://www.linkedin.com/in/ktalar/) - krzysztoftalar@protonmail.com
