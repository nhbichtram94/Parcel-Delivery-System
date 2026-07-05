# Database

This project uses **MongoDB** as the NoSQL database and **Studio 3T** for database management.

## Main Collections

### NguoiDung

Stores user information, including administrators, customers, and shippers.

### DonHang

Stores parcel delivery information such as sender, receiver, order status, and payment status.

### SanPham

Stores product information as embedded documents within each order.

## Database Operations

The application supports:

- Create
- Read
- Update
- Delete (CRUD)

using the **MongoDB.Driver** library.

## Backup & Restore

The system supports backing up and restoring MongoDB data through the administrator interface.
