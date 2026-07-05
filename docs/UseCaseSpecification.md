# Use Case Specification

# Parcel Delivery Management System

---

# UC-01 Login

## Goal

Allow users to access the system based on their roles.

## Primary Actor

- Administrator
- Customer
- Shipper

## Preconditions

- User has a valid account.

## Main Flow

1. User enters username.
2. User enters password.
3. User clicks **Login**.
4. System validates the credentials.
5. System redirects the user to the corresponding dashboard.

## Alternative Flow

4a. Invalid username or password.

- System displays an error message.
- User remains on the login page.

## Postconditions

The user is successfully authenticated.

---

# UC-02 Register Account

## Goal

Allow a customer to create a new account.

## Primary Actor

Customer

## Preconditions

The customer does not already have an account.

## Main Flow

1. Customer opens the registration page.
2. Customer enters personal information.
3. Customer creates a username and password.
4. Customer confirms the password.
5. Customer clicks **Register**.
6. System validates the information.
7. System creates the account successfully.

## Alternative Flow

- Username already exists.
- Password confirmation does not match.
- Required information is missing.

## Postconditions

A new customer account is created.

---

# UC-03 Create Delivery Order

## Goal

Allow customers to create a parcel delivery order.

## Primary Actor

Customer

## Preconditions

- Customer has logged in.

## Main Flow

1. Customer selects **Create Order**.
2. Customer enters receiver information.
3. Customer enters parcel information.
4. Customer confirms the order.
5. System calculates the order information.
6. System saves the order.
7. System displays the order details.

## Alternative Flow

- Required information is missing.
- System requests the customer to complete the information.

## Postconditions

A new delivery order is created.

---

# UC-04 Manage Orders

## Goal

Allow administrators to manage delivery orders.

## Primary Actor

Administrator

## Preconditions

Administrator has logged in.

## Main Flow

1. Administrator opens Order Management.
2. System displays all orders.
3. Administrator searches or filters orders.
4. Administrator selects an order.
5. Administrator updates the order status.
6. System saves the changes.

## Alternative Flow

- Order cannot be found.
- Invalid status update.

## Postconditions

Order information is updated successfully.

---

# UC-05 Assign Shipper

## Goal

Assign delivery orders to available shippers.

## Primary Actor

Administrator

## Preconditions

- Orders exist.
- Shippers exist.

## Main Flow

1. Administrator opens Assignment Management.
2. Administrator selects a shipper.
3. Administrator selects one or more delivery orders.
4. Administrator clicks **Assign**.
5. System creates the assignment.

## Alternative Flow

- No shipper is selected.
- No order is selected.

## Postconditions

Orders are assigned successfully.

---

# UC-06 Update Delivery Status

## Goal

Allow shippers to update the delivery progress.

## Primary Actor

Shipper

## Preconditions

- Order has been assigned.

## Main Flow

1. Shipper logs into the system.
2. Shipper views assigned orders.
3. Shipper selects an order.
4. Shipper updates the delivery status.
5. System records the update time.
6. System saves the new status.

## Alternative Flow

- The order has already been completed.
- The order has been cancelled.

## Postconditions

The delivery status is updated successfully.
