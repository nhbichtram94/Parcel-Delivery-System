# Software Requirements Specification (SRS)

# 1. Introduction

The Parcel Delivery Management System is developed using C# WinForms and MongoDB to support parcel delivery management.

# 2. System Overview

The system consists of three user roles:

- Administrator
- Customer
- Shipper

# 3. Functional Requirements

## FR-01 Login

The system shall allow users to log in using a username and password.

## FR-02 User Management

The administrator shall be able to:

- Create users
- Edit users
- Delete users
- Lock and unlock accounts

## FR-03 Order Management

The administrator shall be able to:

- View orders
- Search orders
- Update order status
- Filter orders

## FR-04 Shipper Assignment

The administrator shall assign delivery orders to shippers.

## FR-05 Payment Management

The administrator shall update payment status and export invoices.

## FR-06 Backup & Restore

The administrator shall backup and restore MongoDB data.

## FR-07 Create Order

Customers shall create parcel delivery orders.

## FR-08 Track Order

Customers shall monitor shipment status.

## FR-09 Update Profile

Customers shall update personal information.

## FR-10 Delivery Management

Shippers shall:

- View assigned orders
- Update delivery status
- Confirm payment
- Export CSV reports

# 4. Non-functional Requirements

- Windows desktop application
- MongoDB database
- Role-based authorization
- Responsive user interface
- Reliable data storage

# 5. Technology

- C#
- .NET WinForms
- MongoDB
- Studio 3T
- Visual Studio 2022
