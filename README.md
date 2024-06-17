**Project Description**

In this project, I developed an application that allows users to obtain quotes for travel health insurance, make payments, and view policy details. Using ASP.NET Core technology, I designed it with a layered architecture in accordance with modern software development principles, separating data access, business logic, and API layers. This approach provides high flexibility, extensibility, and ease of maintenance.

**Technologies Used and Dependencies**

Throughout the project, I utilized the following technologies and dependencies:

ASP.NET Core 8.0: Used to create Web APIs. I opted for the latest version for its performance and security advantages.
Entity Framework Core 8.0: Used as the ORM tool for database operations. The latest version offers enhanced query performance and new features.
Microsoft SQL Server 2019: Chosen as the database management system for its high performance, scalability, and security features.
Swagger 6.6.1: Integrated for API documentation. Swagger allows visualizing and testing API endpoints, accelerating the development process and improving communication among developers.
Project Layers

**The project is structured into the following layers:**

Entities Layer: Contains the data models used in the application.
DataAccess Layer: Includes the code for database operations.
Core Layer: Houses fundamental infrastructure and utility classes.
Business Layer: Implements business logic and services.
WebAPI Layer: Contains API controllers and application configurations.

**Business Layer**

In this layer, I implemented the business logic and service layer of the application. Business services interact with the data access layer (DAL) to apply business logic, including various business rules and validation processes.

PaymentManager: Handles payment operations. Here, I ensure secure payment processes by masking card information and verifying the Turkish ID number (TC) for added security.

**Conclusion**

I developed a comprehensive and modular API for insurance management in this project. By adhering to a layered architecture, utilizing Entity Framework Core, and adopting a service-based structure, I aimed to create a scalable and maintainable system. Clearly defining responsibilities for each layer has streamlined project management and maintenance efforts. This project adheres to modern software development principles, delivering high performance and flexibility.
