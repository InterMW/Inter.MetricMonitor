# Inter.MetricMonitor

## Summary
This microservice is in charge of taking the timing recordings from other services.

# Overview
A brief description of each process

## Ingest

This process listens for metric messages and stores them in InfluxDB.

# How to run

Clone this repository and run with `dotnet run --project Application/Application.csproj`

## General information

This project requires dotnet 8 sdk to run (install link [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)).

When running locally, I have the rabbit password replaced using the dotnet user-secrets tool. 
Please follow Microsoft's [guide](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=linux) to set the value of rabbit_pass to your configured rabbit account's password for the Applications.csproj.

This project uses the MelbergFramework nuget package, please see [its github repo](https://github.com/Joseph-Melberg/https://github.com/MelbergFramework) for more info.

## Required Infrastructure
|Product|Details|Database Install Link|
|-|-|-|
|InfluxDB| You will need a bucket called service_data, change the InfluxDBContext value of the ConnectionStrings section of [appsettings.json](Application/appsettings.json).| Docker installation guide for influxdb [here](https://hub.docker.com/_/influxdb).|
|RabbitMQ| The code will create the exchanges, queues, and bindings for you, just update the Rabbit:ClientDeclarations:Connections:0 details in [appsettings.json](Application/appsettings.json).| Docker installation guide for RabbitMQ [here](https://hub.docker.com/_/rabbitmq).|

