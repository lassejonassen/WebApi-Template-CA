# Clean Architecture .NET Web Api Template
This is a .NET Web Api Template using the Clean Architecture, along with serveral other design patterns. The api provided examples of how it can be utilised along with serveral features that might come in handy. I have choosen to develop the api using Microsofts .NET because it is very versatile and it is the technology that I enjoy working with the most.

The motivation behind this project that I have started is to learn more about .NET and become a better developer. I build it to be used in my own hobby projects to not having to start from scratch everytime I would start a new project of my own. This way I have a single way of developing my own applications. I plan on to keep improving the template and adding more features that might benefit any application. These features can of course be deactivated or removed entirely if it is not needed to a certain application.

I have build the template from the experience I have from my workplaces, spare time and looking into what others have done using the Clean Architecture. I have tried to combine different ways of doing certains things to my liking, and in a way that I think makes sense.

Features that I plan on implementing can be found in the Issues tab where every feature that is to be implemented will be described thoroughly.

## How to Install and run the Project
You will need to have the latest .NET LTS SDK installed along with access to a SQL Server. I use Docker to run a SQL Server on my PC, but you can use any SQL Server, as long as you can get the ConnectionString for it. The AppSettings.json in the Api project has a section called Database, where you can replace the ConnectionString. Once you have configured the ConnectionString, you might need to run a migrations using dotnet-ef, to get the database schema up to date with the application. Once this is done, you should be able to run the api without any issues.

## How to Use the Project
The api can be used in a standalone case where it communicates with a frontend application. It can also be used in a Microservice Architecture where it might communicate with other microservices. Some features might need to activated/deactivated to work with one or the other.

## Credits
I have taken a lot of inspiration from [this repository](https://github.com/amantinband/clean-architecture). The overall structure of my repository resembles the linked. Other credits might go to [Milan Jovanovic](https://github.com/m-jovanovic) and [Nick Chapsas](https://github.com/Elfocrash). Both of them have been an inspiration on how I wanted to create the template

## Contribution
Should you want to contribute in any way, please open an Issue and create a Pull Request with the changes you want to make.

Any additional documentation can be viewed in the documentation-folder.

![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/lassejonassen/WebApi-Template-CA/pipeline.yml?style=for-the-badge)


