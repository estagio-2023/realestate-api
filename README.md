<a name="readme-top"></a>


<br />
<div align="center">
 
<img src="Images/image.png" alt="Logo" width="180" height="150">
 

<h3 align="center">Aplicação Casas</h3>

  <p align="center">
    This repository contains the backend API for a real estate application. 
    <br />
    <br />
    ·
    ·
  </p>
</div>


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
      <a href="#pre-requirements-and-instalation">Pre-Requirements and Instalation
      </a>
    </li>
    <li>
      <a href="#database-connection">Database Connection
      </a>
    </li>
     <li>
      <a href="#testing-the-api-with-swagger">Testing the API
      </a>
    </li>
     <li>
      <a href="#contact">Contact
      </a>
    </li>
    
  </ol>
</details>


## About the API

This API serves as the central communication hub between the frontend application and the database, facilitating various functionalities related to real estate listings, property management and database requests.

## Technologies

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
      <li>Define a password for the database superuser. it can be used "postgres", and leave everything else as default.</li>
      <li>This password, as well as the server name, username and database will be used for the connection string used to get data from the database, so keep these information.</li>
    </ul>
</ul>

## Database Connection
  For connecting the database to the API, we need to retrieve the server information.
<br>
  For the information to be secured, it is needed to store it in a secret.json file:
    <ol>
      <li>After installing the <strong>Microsoft.Extensions.Configuration.UserSecrets</strong> package, press with the right button in the project file, and then "Manage User Secrets".</li>
      <li>It will open an secret.json file, and inside that file, you will paste the code from the SecretsSttructure.json, inside the Helpers folder, which is the connection string data structure that will be retrieved in the database connection method</li>
      <li>After pasting it, you should fill the fields with your database server information:
      <ul>
      <li>Host</li>
      <li>Port</li>
      <li>Database</li>
      <li>Username</li>
      <li>Password</li>
      </ul>
      </li>
    </ol>

## Testing the API with Swagger
To make sure that the API working, we will use swagger in order to see the returned value from the API controller
<ol>
<li>Run the API with IIS Express.</li>
<li>It will open an localhost and load Swagger.</li>
<li>For executing it, click in the GET method, "Try it out", and "Execute". This should diplay the returned value in the "Response body" field.</li>
</ol>


## Contact

Jonathan Osório - jonathan.d.osorio@cgi.com
Repository Link - https://github.com/estagio-2023/appcasas-api
