# MauiTodoItems
Experimenting with MAUI.
Simple todo app that allows CRUD operations on todo items.
This is a general playground app where we can test maui (Libraries, upgrades etc.)

## Technologies used:
- [.NET 7.x](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/what-is-maui?view=net-maui-7.0)
- [Visual Studio](https://visualstudio.microsoft.com/vs/)


## Major Libraries
- [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- [LiteDB](https://www.litedb.org/)


## To Run:
- `rebuild` with Visual Studio
- `select` desired platform (Android/iOS/Window)
- `run`

## Implementations

### General
Using CommunityToolkit.Mvvm for our Model/View/ViewModel pattern, splitting forms/views and services code.
Using LiteDB as our databse for the application.

### TodoItems

First tab of application allows Creating/updating/deleting todo items.
Simple collection view displays the items.
Data stored in nosql database using liteDb

### Quotes

Simple 3 item list of random quotes, pull list to receive 3 new quotes.
