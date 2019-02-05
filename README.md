# ELearning Application

The work concerns the design and implementation of the back-end of the e-learning web application used to support the didactic process of programming.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to get the project up and running:

* Visual Studio Code or Visual Studio 2017
* .NET Core SDK 2.2
* Microsoft SQL Server 2017
* node.js
* MinGW

### Installing

Follow these steps to get a development env running:

1. Clone the repository
2. Restore required ASP.NET Core packages by running the following in root directory:

```
dotnet restore
dotnet build
```

3. Restore required React.js packages by running the following in `ELearning.WebUI\ClientApp` directory:

```
npm install
```

4. (Optional) Next follow the instructions from MinGW wiki Getting Started page to install the compiler:

http://www.mingw.org/wiki/Getting_Started

In the process install g++ compiler.

5. Make sure that port setup in front-end `ELearning.WebUI\ClientApp\src\axios.js` and in back-end are the same. 

6. Launch the app by running the following in root directory:

```
dotnet run
```

## Authors

* **[Mateusz Młotek](https://github.com/MKafar)** - ASP.NET Core Back-End
* **[Daria Ratyńska](https://github.com/peacchy)** - React Front-End in directory `ELearning.WebUI\ClientApp`

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

### Login data

User data provided for testing purposes:

Administrator account
  **login:** admin
  **password:** admin 

Student account
  **login:** student
  **password:** student
