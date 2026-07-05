# Business Requirements Document (BRD)

# Parcel Delivery Management System

---

## 1. Project Overview

The Parcel Delivery Management System is a desktop application developed to support the management of parcel delivery operations. The project aims to replace manual processes with a centralized system that enables administrators, customers, and shippers to manage parcel information, monitor delivery progress, and maintain payment records efficiently.

The application is developed using **C# WinForms** with **MongoDB** as the NoSQL database.

---

## 2. Business Problem

Parcel delivery businesses often rely on manual processes to manage orders, assign deliveries, and update shipment status. These processes can lead to delayed updates, inconsistent information, and difficulties in monitoring delivery progress.

The organization requires a centralized application that simplifies parcel management, improves communication between different user roles, and provides reliable data storage and reporting.

---

## 3. Business Objectives

The project aims to achieve the following objectives:

- Provide a centralized parcel delivery management system.
- Manage user accounts based on different roles (Administrator, Customer, and Shipper).
- Allow customers to create and monitor delivery orders.
- Support administrators in managing users, orders, payments, and delivery assignments.
- Enable shippers to update delivery status and payment information.
- Improve data reliability through backup and restore functionality.
- Support exporting delivery reports in CSV format.

---

## 4. Stakeholders

| Stakeholder | Responsibility |
|--------------|----------------|
| Administrator | Manage users, orders, payments, delivery assignments, and system maintenance |
| Customer | Register an account, create delivery orders, track shipment status, and manage personal information |
| Shipper | View assigned orders, update delivery status, confirm payments, and export delivery reports |

---

## 5. Project Scope

### In Scope

The system provides the following features:

- User authentication
- User registration
- User profile management
- Role-based authorization
- Parcel order management
- Delivery assignment
- Shipment tracking
- Payment management
- Backup and restore database
- Export delivery reports to CSV

### Out of Scope

The following features are not included in the current version:

- Online payment gateway integration
- Mobile application
- GPS real-time tracking
- SMS or email notifications
- Integration with third-party logistics providers

---

## 6. Business Requirements

### BR-01 User Management

The system shall allow administrators to manage customer, shipper, and administrator accounts.

### BR-02 Parcel Order Management

The system shall allow customers to create delivery orders and administrators to manage all orders.

### BR-03 Delivery Assignment

The system shall allow administrators to assign delivery orders to available shippers.

### BR-04 Shipment Tracking

The system shall allow customers to monitor the current delivery status of their parcels.

### BR-05 Payment Management

The system shall record and update payment information for delivery orders.

### BR-06 Reporting

The system shall support exporting delivery information into CSV format.

### BR-07 Data Protection

The system shall support database backup and restore operations.

---

## 7. Business Rules

- Every user must log in before accessing the system.
- Each delivery order belongs to one customer.
- A delivery order can only be assigned to one shipper at a time.
- Only administrators are allowed to assign delivery orders.
- Only assigned shippers can update delivery status.
- Payment status must be updated before an order is marked as completed.
- User permissions are controlled based on their assigned role.

---

## 8. Success Criteria

The project is considered successful if:

- Customers can successfully create and track parcel delivery orders.
- Administrators can manage users, orders, and delivery assignments efficiently.
- Shippers can update delivery progress without errors.
- Delivery information is stored consistently in MongoDB.
- Database backup and restore functions operate successfully.
- Delivery reports can be exported in CSV format.
