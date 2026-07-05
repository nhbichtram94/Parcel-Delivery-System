# Parcel Delivery Management System

A desktop application developed using **C# WinForms** and **MongoDB** to manage parcel delivery operations. The system supports shipment creation, order tracking, shipper assignment, payment management, and user administration.

---

## Overview

The Parcel Delivery Management System is designed to simplify parcel delivery operations for logistics companies. It allows customers to create and track delivery orders, administrators to manage shipments and assign shippers, and shippers to update delivery progress efficiently.

This repository contains both the application source code and the business analysis artifacts created during system analysis and design.

---

## Features

### Customer

- Register and log in
- Create delivery orders
- Track shipment status
- View delivery history
- Submit service ratings

### Admin

- Manage users
- Manage delivery orders
- Assign shippers
- Update shipment status
- Manage payments
- Backup and restore database

### Shipper

- View assigned deliveries
- Update delivery status
- Complete deliveries
- Export delivery reports

---

## Tech Stack

| Category | Technology |
|----------|------------|
| Language | C# |
| Framework | .NET WinForms |
| Database | MongoDB |
| Database Tool | Studio 3T |
| IDE | Visual Studio |

---

## Project Architecture

```
GUI
│
├── Business Logic Layer (BLL)
│
├── Data Access Layer (DAL)
│
├── Data Transfer Objects (DTO)
│
└── MongoDB
```

---

## Business Analysis Artifacts

This project also includes business analysis documentation created during the system analysis phase.

- Business Requirements Document (BRD)
- Software Requirements Specification (SRS)
- User Stories
- Use Case Specifications
- BPMN Diagrams
- UML Diagrams
- Entity Relationship Diagram (ERD)

---

## Database Design

### Main Collections

- Users
- Orders

### Data Modeling

**Embedded Documents**

- Sender Information
- Receiver Information
- Parcel Information

**References**

- Customer
- Admin
- Shipper

---

## Repository Structure

```
Parcel-Delivery-System
│
├── BLL/
├── DAL/
├── DTO/
├── GUI/
├── docs/
├── diagrams/
├── screenshots/
├── database/
├── README.md
└── QuanLyGiaoNhanBuuPham.sln
```

---

## Screenshots

Screenshots of the application interface will be added here.

- Login
- Dashboard
- Order Management
- Shipment Tracking
- Payment Management

---

## Future Improvements

- Email notifications
- Real-time shipment tracking
- QR code support
- Mobile application
- Dashboard analytics

---

## Author

**Nguyễn Hoàng Bích Trâm**

Bachelor of Information Technology

Interested in Business Analysis, System Analysis, and Software Development.
