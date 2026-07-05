# Software Requirements Specification (SRS)

# Parcel Delivery Management System

---

## 1. Introduction

### 1.1 Purpose

This document specifies the functional and non-functional requirements of the Parcel Delivery Management System. It serves as a reference for system development, testing, and future maintenance.

### 1.2 Project Scope

The Parcel Delivery Management System is a desktop application that manages parcel delivery operations. The system supports three user roles: Administrator, Customer, and Shipper. Users can create delivery orders, assign shipments, update delivery status, manage payments, and perform backup and restore operations.

---

## 2. Overall Description

### 2.1 Product Perspective

The application is developed using C# WinForms with MongoDB as the database. It provides a centralized platform for parcel delivery management.

### 2.2 User Roles

#### Administrator

- Manage user accounts
- Manage delivery orders
- Assign orders to shippers
- Manage payment information
- Backup and restore database
- View delivery statistics

#### Customer

- Register an account
- Login
- Create delivery orders
- Track delivery status
- Update personal information

#### Shipper

- View assigned orders
- Search and filter orders
- Update delivery status
- Confirm payment
- Export delivery reports to CSV

---

## 3. Functional Requirements

### FR-01 User Authentication

The system shall allow users to log in using a valid username and password.

### FR-02 User Registration

The system shall allow customers to register a new account by providing personal information.

### FR-03 User Management

The administrator shall be able to:

- Create users
- Edit users
- Delete users
- Lock or unlock user accounts
- Search users

### FR-04 Order Management

The administrator shall be able to:

- View all orders
- Search orders
- Filter orders
- Update order status

### FR-05 Delivery Assignment

The administrator shall assign one or more delivery orders to a shipper.

### FR-06 Shipment Tracking

Customers shall be able to monitor the current status of their delivery orders.

### FR-07 Payment Management

The system shall record payment information and allow administrators or shippers to update payment status.

### FR-08 Backup and Restore

The administrator shall backup and restore MongoDB data.

### FR-09 CSV Export

The shipper shall export assigned delivery orders into CSV format.

### FR-10 Profile Management

Customers shall update their personal information including name, phone number, email, and address.

---

## 4. Non-functional Requirements

### Performance

- The system should respond to user requests within a reasonable time under normal operating conditions.

### Security

- Users must authenticate before accessing the system.
- Access permissions are controlled based on user roles.

### Reliability

- Data shall be stored in MongoDB.
- Backup and restore functions shall protect against data loss.

### Usability

- The interface should be simple and easy to use.
- Functions should be organized according to user roles.

### Compatibility

The application supports:

- Windows 10
- Windows 11

---

## 5. Database Overview

The system stores data in MongoDB.

Main collections include:

- Users
- Orders
- Payments
- Assignments

The database supports CRUD operations through the MongoDB.Driver library.

---

## 6. Technology Stack

| Component | Technology |
|-----------|------------|
| Programming Language | C# |
| Framework | .NET WinForms |
| Database | MongoDB |
| Database Tool | Studio 3T |
| IDE | Visual Studio 2022 |

---

## 7. System Features

| Feature | Admin | Customer | Shipper |
|----------|:----:|:--------:|:-------:|
| Login | ✓ | ✓ | ✓ |
| Register | | ✓ | |
| Manage Users | ✓ | | |
| Manage Orders | ✓ | | |
| Create Orders | | ✓ | |
| Track Orders | | ✓ | |
| Assign Shippers | ✓ | | |
| Update Delivery Status | | | ✓ |
| Payment Management | ✓ | | ✓ |
| Backup & Restore | ✓ | | |
| Export CSV | | | ✓ |

---

## 8. Assumptions and Constraints

### Assumptions

- MongoDB server is available.
- Users have valid accounts before accessing protected functions.

### Constraints

- The application is designed for Windows desktop only.
- Internet-based features such as online payment and GPS tracking are not included.
