# UFG.API

REST API for customer management and profile images with secure storage in AWS S3.

## 📋 About the Project

UFG.API is a REST API developed in .NET 8 that offers functionalities for managing customers and their profile images. The system allows uploading, updating, viewing, and deleting profile images, with secure storage in Amazon S3.

## 🚀 Technologies Used

- **.NET 8**: Modern framework for application development
- **ASP.NET Core**: Framework for RESTful API development
- **AWS S3**: Amazon's object storage service for storing user images
- **AWS DynamoDB**: NoSQL database for customer data storage
- **MailKit**: Library for sending emails
- **AutoMapper**: Object-to-object mapping
- **FluentValidation**: Model validation
- **SixLabors.ImageSharp**: Image processing and manipulation
- **Swagger/OpenAPI**: API documentation
- **Docker**: Application containerization

## 🏗️ Architecture

The project follows a clean architecture with clear separation of responsibilities:

- **Core**: Contains central and reusable components
- **src**: Contains the specific application implementation

## 🔧 Main Features

### Customer Management
- Creation of new customers
- Customer lookup by ID
- Listing of all customers
- Customer deletion

### Image Management
- Profile image upload
- Image updates (resizing)
- Image viewing
- Listing all images of a customer
- Image deletion
- Upload limitations for Beginner plan users (5 images per day)

### Validation System
- Standardized exception handling
- Input validation with FluentValidation
- Consistent error responses in JSON format

## 📦 Project Structure

```
UFG.API/
├── Core/                     # Reusable core components
│   ├── Config/               # Application configurations
│   │   ├── Interfaces/       # Interfaces for configurations
│   │   └── AwsConfig.cs      # AWS configurations
│   ├── Profiles/             # AutoMapper profiles
│   ├── Utils/                # Utilities and helpers
│   └── Validation/           # Validation and exception handling system
│       ├── ApiException.cs   # Custom API exception
│       └── ExceptionMiddleware.cs # Exception handling middleware
├── src/                      # Main application source code
│   ├── Controllers/          # API controllers
│   │   ├── CustomerController.cs      # Customer endpoints
│   │   └── CustomerImageController.cs # Image endpoints
│   ├── Models/               # Data models
│   │   └── Customer/         # Customer-related models
│   │       └── DTO/          # Data transfer objects
│   ├── Repositories/         # Data access
│   │   ├── Interfaces/       # Repository interfaces
│   │   └── CustomerRepository.cs # Customer repository implementation
│   └── Services/             # Application services
│       ├── Interfaces/       # Service interfaces
│       ├── Validators/       # FluentValidation validators
│       ├── CustomerService.cs    # Customer service
│       ├── EmailService.cs       # Email service
│       └── CustomerImageService.cs # Image service
└── Program.cs                # Application configuration
```

## 📝 API Endpoints

### Customers

- `POST /customers` - Create a new customer
- `GET /customers/{id}` - Get customer by ID
- `GET /customers` - List all customers
- `DELETE /customers/{id}` - Delete customer

### Images

- `POST /customers/{id}/image` - Upload profile image
- `PATCH /customers/{id}/{fileName}/image?Width={width}&Height={height}` - Update image (resize)
- `GET /customers/{id}/{fileName}/image` - Get specific image
- `GET /customers/{id}/image` - List all images of a customer
- `DELETE /customers/{id}/image` - Delete profile image

## 🔐 Image Storage

Images are securely stored in Amazon S3, with the following characteristics:

- Bucket: `UFGbucket`
- Support for non-GUID identifiers (such as "2-2ke")
- Image processing for optimization
- Upload limitation based on user level

## 🛡️ Validation and Exception Handling System

The project implements a robust validation and exception handling system:

- **ApiException**: Custom exception that includes HTTP status code and error details
- **ExceptionMiddleware**: Middleware that captures exceptions and returns standardized error responses
- **Validators**: Implemented with FluentValidation to validate inputs

## 🚀 How to Run

### Prerequisites

- .NET 8 SDK
- AWS account with access to S3 and DynamoDB
- Email account for sending notifications

### Configuration

1. Clone the repository
   ```bash
   git clone https://github.com/your-username/UFG.API.git
   cd UFG.API
   ```

2. Configure environment variables or the `appsettings.json` file with:
   - AWS credentials
   - Email settings
   - Other necessary configurations

3. Run the application
   ```bash
   dotnet run
   ```

4. Access the Swagger documentation
   ```
   https://localhost:5001/swagger
   ```

### Using Docker

1. Build the Docker image
   ```bash
   docker build -t UFG-api .
   ```

2. Run the container
   ```bash
   docker run -p 8080:80 UFG-api
   ```
   
## Developer

Developed by Fernando Furtado © 2025

##### - Access the container on [Docker - click here](https://hub.docker.com/r/furtadofernando/UFG-api)
##### - Access GitHub [GitHub - click here](https://github.com/Fernando-EngComputacao/UFG-api)

---

<div align="center">
  <p>Desenvolvido com ❤️ por Fernando Furtado</p>
  <p>PPGCC - INF/UFG - 2025</p>
</div>