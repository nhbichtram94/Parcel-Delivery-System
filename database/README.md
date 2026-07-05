# Database

This folder contains the database design and sample data for the Parcel Delivery Management System.

## Database

- MongoDB
- Studio 3T

## Main Collections

### NguoiDung

Stores information about administrators, customers, and shippers.

Main fields:

- UserId
- Username
- Password
- FullName
- PhoneNumber
- Email
- Address
- Role

---

### DonHang

Stores parcel delivery information.

Main fields:

- OrderId
- Sender
- Receiver
- Products
- Status
- PaymentStatus
- ShippingFee
- TotalAmount
- LastUpdated

---

### SanPham

Embedded document inside each order.

Main fields:

- ProductName
- Quantity
- Weight
- Price

---

## Database Design

The project combines:

- Embedded Documents
- References

to improve query performance while minimizing duplicated data.
