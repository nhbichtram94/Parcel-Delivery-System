# Software Requirements Specification (SRS)

## 1. Introduction

The system is developed using C# WinForms and MongoDB to manage parcel delivery operations.

## 2. User Roles

### Administrator

- Manage users
- Manage orders
- Assign shippers
- Manage payments
- Backup & Restore database

### Customer

- Register account
- Login
- Create delivery orders
- Track delivery status
- Update profile

### Shipper

- View assigned orders
- Update shipment status
- Confirm payment
- Export CSV reports

## 3. Functional Requirements

### FR-01 Login

The system shall authenticate users based on username and password.

### FR-02 User Management

The administrator shall create, update, delete, lock, and unlock user accounts.

### FR-03 Order Management

The administrator shall view, search, filter, and update delivery orders.

### FR-04 Shipper Assignment

The administrator shall assign delivery orders to shippers.

### FR-05 Payment Management

The administrator shall update payment status and export invoices.

### FR-06 Backup & Restore

The administrator shall backup and restore MongoDB data.

### FR-07 Create Order

Customers shall create parcel delivery orders.

### FR-08 Track Order

Customers shall monitor shipment status.

### FR-09 Delivery Processing

Shippers shall update shipment status and export assigned orders.

## 4. Non-functional Requirements

- Desktop application
- MongoDB database
- Role-based authorization
- User-friendly interface
- Reliable data storage
