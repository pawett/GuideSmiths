# GuideSmith Code Challenge
Repository for the code challenge

## Summary
This repository stores my solution to the GuideSmith code challenge.
[Here](https://github.com/guidesmiths/interview-code-challenges/blob/master/.NET/martian-robots/instructions.md) is the description of the challenge.
The language used is C# and the framework is .NET Core 3.1
My main goal when coding is that the code should be easy to read and comprehend to external people. With that in mind I always try to give meaningful names to classes and funcions and keep a robust code style through all my applications.


## Arquitecture
I have used an Onion arquitecture, with three different layers: Domain, Application and Infrastructure.
The **domain layer** represents the business and behaviour classes of the application. This classes must remain isolated from the outside of the application logic.
The **application layer** behaves as the proxy between the external world and the application logic. Helps to isolate the domain layer and describes how the application communicates with the external world. It is responsible to receive data from external sources, validate and transform it into objects which the doman classes can work with. 
Also, keeps the flow of the information and processes in the correct order.
**Infrastucture layer** is the external part of this architecture and keeps peripheral concerns like UI or DB access.

Once summarized the Onion architecture, this particular implementation is explained as follows:

### Domain layer
Here are the all the business classes that modelates the Surface and the Robot movements.
For the instructions or commands that the Robot can perform, I have used the Command pattern (under the RobotCommands folder) to isolate the Robot class from the interaction with the Surface class and also make it easily extensible for new instructions.
### Application
Formats the input and output data to the format required for this challenge.
MissionControlService is responsible to read the input data, and process the instructions in the correct order and return the results.
### Infrastructure
Two different projects has been created for this layer, one is an console app and the other one is a web api. I decided to create a Web API because in my opinion it fits better in an environment when requests can be made from remote sources to a public endpoint running on Docker.
Console application helps to test the application locally and that's why I have kept it.
## Testing
I have created unit tests and integration tests.
Unit tests 
## Docker
