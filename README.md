# Parcel Delivery Management System

A desktop application developed for the **NoSQL Database** course using **MongoDB**, **Studio 3T**, and **C# WinForms**. The system supports parcel delivery management, including user management, order processing, shipment tracking, payment management, and database backup/restore.

---

## Project Overview

This project was developed to explore MongoDB and Studio 3T while applying NoSQL database concepts to a real-world parcel delivery management system.

The application provides role-based access for three user types:

- **Administrator**
- **Customer**
- **Shipper**

Each role has dedicated features to support parcel delivery operations efficiently.

---

## Objectives

- Learn and apply MongoDB using Studio 3T.
- Design a NoSQL database for a parcel delivery management system.
- Develop a desktop application using C# WinForms.
- Implement CRUD operations with MongoDB.
- Support shipment tracking, payment management, and database backup/restore.

---

## Tech Stack

| Category | Technology |
|----------|------------|
| Language | C# |
| Framework | .NET WinForms |
| Database | MongoDB |
| Database Tool | Studio 3T |
| Driver | MongoDB.Driver |
| IDE | Visual Studio 2022 |

---

## System Features

### Administrator

- Manage user accounts (Admin, Customer, and Shipper)
- Manage all delivery orders
- Assign orders to shippers
- Manage payment status
- Backup and restore database
- View delivery statistics

### Customer

- Register and log in
- Create delivery orders
- Track shipment status
- View order history
- Update personal information

### Shipper

- View assigned delivery orders
- Update delivery status
- Confirm payment
- Export delivery reports to CSV

---

## Database Design

The system uses **MongoDB** as the NoSQL database.

Main collections include:

- **NguoiDung** – Stores information about administrators, customers, and shippers.
- **DonHang** – Stores parcel order information, delivery status, and payment status.
- **SanPham** – Stores product information embedded within each order.

The database combines **Embedded Documents** and **References** to improve storage efficiency and query performance.

---

## MongoDB Connection

```csharp
var client = new MongoClient("mongodb://localhost:27017");

var database = client.GetDatabase("GiaoNhanBuuPham");

var collection = database.GetCollection<DonHang_DTO>("DonHang");
```

---

## CRUD Operations

The application supports complete CRUD functionality.

- **Create** – Create new delivery orders
- **Read** – Retrieve parcel order information
- **Update** – Update delivery status and payment status
- **Delete** – Remove delivery orders

---

## Documentation

Project documentation is available in the **docs** folder.

- Business Requirements Document (BRD)
- Software Requirements Specification (SRS)
- User Stories
- Use Case Specification

---

## Screenshots

### Login Screen

![Login](screenshots/login-screen.png)

### Admin Dashboard

![Admin Dashboard](screenshots/admin-dashboard.png)

### User Management

![User Management](screenshots/user-management.png)

### Order Management

![Order Management](screenshots/order-management.png)

### Shipper Assignment

![Shipper Assignment](screenshots/shipper-assignment.png)

### Payment Management

![Payment Management](screenshots/payment-management.png)

### Create Delivery Order

![Create Order](screenshots/create-order.png)

### Shipper Dashboard

![Shipper Dashboard](screenshots/shipper-dashboard.png)

---

## Results

- Successfully developed a parcel delivery management system using MongoDB.
- Connected C# WinForms with MongoDB successfully.
- Implemented complete CRUD operations.
- Applied role-based access control for three user roles.
- Implemented shipment tracking and payment management.
- Developed database backup and restore functionality.
- Exported delivery reports to CSV.

---

## Future Improvements

- Optimize performance for large datasets.
- Develop RESTful APIs using ASP.NET Core.
- Build a web or mobile version.
- Integrate real-time shipment tracking.

---

## Author

**Nguyễn Hoàng Bích Trâm**

Business Analyst | .NET Developer

> **Note:** This repository is maintained as part of my personal portfolio. The original application was developed as a university team project.
