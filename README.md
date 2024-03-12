<a name="readme-top"></a>

<!-- PROJECT LOGO -->
<br />
<div align="center">
 
<img src="https://github.com/estagio-2023/appcasas-db/raw/master/imagens/logo/casas-high-resolution-logo.png" alt="Logo" width="180" height="150">
 

<h3 align="center">Aplicação Casas</h3>

  <p align="center">
    This repository contains the backend API for a real estate application. 
    <br />
    <br />
    ·
    ·
  </p>
</div>



<!-- Índice -->
<details>
  <summary>Summary</summary>
  <ol>
    <li>
      <a href="#about-the-api">About the API</a>
    </li>
    <li>
      <a href="#technologies">Technologies
      </a>
    </li>
     <li>
      <a href="#">Pre-Requirements
      </a>
    </li>
    <li>
      <a href="#">Configuration
      </a>
    </li>
     <li>
      <a href="#">Database Connection
      </a>
    </li>
    
  </ol>
</details>



<!-- SOBRE O PROJETO -->
## About the API

This API serves as the central communication hub between the frontend application and the database, facilitating various functionalities related to real estate listings, property management and database requests.

### Technologies

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white) ![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)



## Pre Requirements and Instalation
<ul>
  <li>.Net</li>
  <ul>
  <li>Install .Net 8.0 SLK - <a href="https://dotnet.microsoft.com/en-us/download">https://dotnet.microsoft.com/en-us/download</a></li>
  </ul>
  <li>Visual Studio</li>
  <ul>
    <li>Install Visual Studio - <a href="https://visualstudio.microsoft.com/">https://visualstudio.microsoft.com/</a></li>
    <li>Clone Repository</li>
    <li>Install NuGet Packages
        <ul>
          <li>Npgsql</li>
          <li>Npgsql.DependencyInjection</li>
          <li>Microsoft.Extensions.Configuration.UserSecrets</li>
        </ul>
    </li>
  </ul>
  <li>PostgreSql</li>
    <ul>
      <li>Download PostgreSQL -<a href="https://www.postgresql.org/download/">https://www.postgresql.org/download/</a> </li>
      <li>Define a password for the database superuser. it can be used "postgres", and leave everythign else as default.</li>
      <li>This password, as well as the server name, username and database will be used for the connection string used to get data from the database, so keep these information.</li>
    </ul>
</ul>

## Configuration


