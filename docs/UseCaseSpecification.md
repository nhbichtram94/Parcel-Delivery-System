# Use Case Specification

# UC-01 Login

## Actor

- Administrator
- Customer
- Shipper

## Preconditions

- User has a valid account.

## Main Flow

1. Enter username.
2. Enter password.
3. Click Login.
4. System validates credentials.
5. Dashboard is displayed.

## Alternative Flow

- Invalid username or password.
- System displays an error message.

## Postconditions

- User is logged into the system.

---

# UC-02 Create Order

## Actor

Customer

## Preconditions

Customer has logged in.

## Main Flow

1. Select Create Order.
2. Enter receiver information.
3. Enter parcel information.
4. Confirm order.
5. System saves the order.

## Alternative Flow

Required information is missing.

System displays validation messages.

## Postconditions

A new delivery order is created.

---

# UC-03 Assign Shipper

## Actor

Administrator

## Preconditions

Orders and shippers exist.

## Main Flow

1. Select a shipper.
2. Select one or more orders.
3. Click Assign.
4. System saves the assignment.

## Postconditions

Orders are assigned successfully.

---

# UC-04 Update Delivery Status

## Actor

Shipper

## Preconditions

Order has been assigned.

## Main Flow

1. Open assigned orders.
2. Select an order.
3. Update delivery status.
4. Save changes.

## Postconditions

Order status is updated.

---

# UC-05 Backup Database

## Actor

Administrator

## Preconditions

Administrator has permission.

## Main Flow

1. Select Backup.
2. Choose backup location.
3. Click Backup.
4. System creates the backup file.

## Postconditions

Database backup is completed successfully.
