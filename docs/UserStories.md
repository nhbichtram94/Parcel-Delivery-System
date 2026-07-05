# User Stories

# Parcel Delivery Management System

---

## Administrator

### US-01 Login

**As an** Administrator,

**I want** to log into the system,

**So that** I can manage parcel delivery operations.

**Acceptance Criteria**

- Given a valid username and password
- When the administrator clicks **Login**
- Then the system redirects to the Admin Dashboard.

---

### US-02 Manage User Accounts

**As an** Administrator,

**I want** to create, edit, lock, unlock, and delete user accounts,

**So that** I can control access to the system.

**Acceptance Criteria**

- New users can be created successfully.
- Existing users can be updated.
- Locked users cannot log in.

---

### US-03 Manage Orders

**As an** Administrator,

**I want** to search, filter, and update delivery orders,

**So that** parcel information remains accurate.

**Acceptance Criteria**

- Orders can be searched by Order ID.
- Orders can be filtered by status.
- Order status can be updated.

---

### US-04 Assign Orders

**As an** Administrator,

**I want** to assign delivery orders to shippers,

**So that** deliveries are processed efficiently.

**Acceptance Criteria**

- One order can only be assigned to one shipper.
- Assignment is saved successfully.

---

### US-05 Manage Payments

**As an** Administrator,

**I want** to update payment information,

**So that** payment records remain accurate.

**Acceptance Criteria**

- Payment status can be updated.
- Invoice information is displayed correctly.

---

### US-06 Backup and Restore Database

**As an** Administrator,

**I want** to backup and restore the MongoDB database,

**So that** data can be recovered when necessary.

**Acceptance Criteria**

- Backup file is created successfully.
- Database can be restored from a backup file.

---

## Customer

### US-07 Register

**As a** Customer,

**I want** to register an account,

**So that** I can use the parcel delivery service.

**Acceptance Criteria**

- Username must be unique.
- Password meets validation rules.
- Registration completes successfully.

---

### US-08 Login

**As a** Customer,

**I want** to log into the system,

**So that** I can access my delivery orders.

**Acceptance Criteria**

- Valid credentials allow access.
- Invalid credentials display an error.

---

### US-09 Create Delivery Order

**As a** Customer,

**I want** to create a parcel delivery order,

**So that** my parcel can be delivered.

**Acceptance Criteria**

- Receiver information is required.
- At least one parcel item must be added.
- Order is created successfully.

---

### US-10 Track Delivery

**As a** Customer,

**I want** to track my parcel,

**So that** I know its delivery status.

**Acceptance Criteria**

- Current status is displayed.
- Last updated time is displayed.

---

### US-11 Update Profile

**As a** Customer,

**I want** to update my personal information,

**So that** my account information remains accurate.

**Acceptance Criteria**

- Name, phone number, email, and address can be updated.
- Changes are saved successfully.

---

## Shipper

### US-12 View Assigned Orders

**As a** Shipper,

**I want** to view orders assigned to me,

**So that** I know which deliveries I need to complete.

**Acceptance Criteria**

- Only assigned orders are displayed.
- Orders can be filtered by status.

---

### US-13 Update Delivery Status

**As a** Shipper,

**I want** to update delivery status,

**So that** customers receive the latest shipment information.

**Acceptance Criteria**

- Status can be changed.
- Update time is recorded automatically.

---

### US-14 Confirm Payment

**As a** Shipper,

**I want** to confirm payment after successful delivery,

**So that** payment information is recorded correctly.

**Acceptance Criteria**

- Payment status changes to Paid.
- Order status is updated accordingly.

---

### US-15 Export CSV Report

**As a** Shipper,

**I want** to export my assigned orders,

**So that** I can create delivery reports.

**Acceptance Criteria**

- CSV file is generated successfully.
- Exported data matches displayed orders.
