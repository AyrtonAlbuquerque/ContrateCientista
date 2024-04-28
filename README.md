<!-- ------------------------------------------ Logo ------------------------------------------- -->
<div align="center">
    <div><img src="https://i.imgur.com/rQNjkKJ.png" width="160px" height="120px"></div>
    <div>Your Logo description (Optional)</div>
</div>

![Version][version.badge]

<!-- ------------------------------------ Table of Content ------------------------------------- -->
<h1>Table of Content</h1>

- [Overview](#overview)
- [Setup](#setup)
  - [Requirements](#requirements)
  - [Installation](#installation)
- [Execution](#execution)
  - [Compiling](#compiling)
  - [Debugging](#debugging)
- [Versioning](#versioning)
  - [Staging](#staging)
  - [Production](#production)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)

<!-- ------------------------------------------------------------------------------------------- -->
<!--                                          Sections                                           -->
<!-- ------------------------------------------------------------------------------------------- -->

<!-- ---------------------------------------- Overview ----------------------------------------- -->
<div align="center">

# Overview

</div>

Put here a brief description of the project.

An image is worth a 1000 words, so they are always welcome.

<div align="center"><img src="https://i.imgur.com/rQNjkKJ.png"></div>

Tables can be used to show data:

| Column 1 | Column 2 | Column 3 | Column 4 | Column 5 |
| -------- | -------- | -------- | -------- | -------- |
| Row 1    |          |          |          |          |
| Row 2    |          |          |          |          |
| Row 3    |          |          |          |          |
| Row 4    |          |          |          |          |

Use [this](https://www.tablesgenerator.com/markdown_tables) site to generate tables automatically.

<!-- ------------------------------------------ Setup ------------------------------------------ -->
<div align="center">

# Setup

</div>

## Requirements

<!-- Describe here the tools required for the project. To keep things simple to read and understand use lists and links. You can also use badges for better visual information. You can use [this](https://dev.to/envoy_/150-badges-for-github-pnk) link to get badges for a lot a tools.

- [![Angular][angular.badge]][angular.url]
- [![Node][node.badge]][node.url]
- [![JavaScript][javascript.badge]][javascript.url]
- [![.NET][.net.badge]][.net.url] -->

To host this Platform you will need a Linux server with Docker Engine installed.

## Installation

1. Create a commom docker network for the containers

```sh
docker network create -d bridge contrate-cientista-network
```

2. Pull a Postgres image from Docker and set it to use the previously created network

```sh
docker run --name contrate-cientista-database -p 5432:5432 \
--network contrate-cientista-network \
-e POSTGRES_PASSWORD=<Password> \
-d postgres:latest
```

3. Pull the Language API from Docker and set it to use the previously created network (Replace the \<Key> with each respective API key):

```sh
docker run --name contrate-cientista-language-api -p 8000:8000 \
--network contrate-cientista-network \
-e OPENAI_API_KEY=<Key> \
-e AWS_ACCESS_KEY=<Key> \
-e AWS_SECRET_KEY=<Key> \
-e AZURE_LANGUAGE_KEY=<Key> \
-d ayrton297866/contrate-cientista-language-api:latest
```

4. Pull the API from Docker and set it to use the previously created network

```sh
docker run --name contrate-cientista-api -p 5000:5000 \
--network contrate-cientista-network \
-e ASPNETCORE_ENVIRONMENT=Production \
-e ASPNETCORE_HTTP_PORTS=5000 \
-d ayrton297866/contrate-cientista-api:latest
```

<!-- Describe here the steps necessary to install your project. Prefer the use of lists/commands/images over pure text, for example:

1. Clone the repository

   ```sh
   git clone https://github.com/ProjectName/ProjectName.git
   ```

2. Install packages

   ```sh
   npm install
   ```

3. Configure key in `📜 config.js`

   ```js
   const KEY = "Value";
   ```

4. Copy the files at `📁 ./SomeDirectory` to `📁 /Users/Name`

Use emojis like 📁 and 📜 in the example to better describe the type of actions that should be taken. You can access a list of available emojis at [this](https://www.webfx.com/tools/emoji-cheat-sheet/) link. -->

<!-- ---------------------------------------- Execution ---------------------------------------- -->
<div align="center">

# Execution

</div>

## Compiling

Describe here the necessary steps to compile parts or the entire project.

## Debugging

Describe here the necessary steps to enable debugging and other error correction methods in the project.

<!-- --------------------------------------- Versioning ---------------------------------------- -->
<div align="center">

# Versioning

</div>

Describe here the necessary steps to contribute to the project with new versions and adjustments.

## Staging

Describe here the necessary steps for releasing staging versios.

## Production

Describe here the necessary steps for releasing production versios.

<!-- ----------------------------------------- Contact ----------------------------------------- -->
<div align="center">

# Contact

</div>

<!-- Put in this section the contacts of the team members responsible for the project. -->

- [🐱 Fulano](https://www.linkedin.com/) - fulano@example.com
- [🐶 Ciclano](https://www.linkedin.com/) - ciclano@example.com
- [🐯 Beltrano](https://www.linkedin.com/) - beltrano@example.com
- [🐻 Foo](https://www.linkedin.com/) - foo@example.com
- [🐺 Bar](https://www.linkedin.com/) - bar@example.com

<!-- ------------------------------------- Acknowledgments ------------------------------------- -->
<div align="center">

# Acknowledgments

</div>

<!-- Use this section to list resources you find helpful and people you would like to give credit to. Use a list and links to keep it short and simple. -->

- [👦 Fulano](https://www.linkedin.com/) - fulano@example.com
- [👦 Ciclano](https://www.linkedin.com/) - ciclano@example.com
- [👦 Beltrano](https://www.linkedin.com/) - beltrano@example.com

<!-- --------------------------------------- References ---------------------------------------- -->

[version.badge]: https://img.shields.io/badge/version-22.07.0901-brightgreen
[angular.url]: https://angular.io/
[angular.badge]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[node.url]: https://nodejs.org/en/
[node.badge]: https://img.shields.io/badge/Node.js-43853D?style=for-the-badge&logo=node.js&logoColor=white
[javascript.url]: https://www.javascript.com/
[javascript.badge]: https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black
[.net.url]: https://dotnet.microsoft.com/en-us/
[.net.badge]: https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white
