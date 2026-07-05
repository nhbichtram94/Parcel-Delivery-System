# Business Requirements Document (BRD)

## 1. Project Overview

The Parcel Delivery Management System is a desktop application developed using C# WinForms and MongoDB to support parcel delivery operations. The system enables administrators, customers, and shippers to manage delivery activities, track shipment progress, process payments, and maintain user information.

## 2. Business Problem

Manual parcel management makes it difficult to track deliveries, assign orders to shippers, and maintain consistent shipment information. A centralized management system is required to improve operational efficiency and reduce manual processing.

## 3. Business Objectives

- Manage parcel delivery orders efficiently.
- Allow customers to track shipment status.
- Support role-based access for administrators, customers, and shippers.
- Manage delivery assignments and payment status.
- Provide backup and restore functionality for data protection.

## 4. Stakeholders

- Administrator
- Customer
- Shipper

## 5. Project Scope

### In Scope

- User authentication
- User management
- Parcel order management
- Shipper assignment
- Shipment tracking
- Payment management
- Backup and restore
- Export delivery data to CSV

### Out of Scope

- Online payment gateway
- Mobile application
- GPS real-time tracking

## 6. Business Requirements

- Customers can create and track delivery orders.
- Administrators manage users, orders, payments, and delivery assignments.
- Shippers update delivery status and payment information.
- The system stores all delivery information in MongoDB.
