# 📦 Inventory Management System (C# WinForms + SQL Server)

A complete **Inventory Management System** developed using **C# WinForms** and **SQL Server**, designed to manage products, track stock levels in real time, handle user authentication, and log all inventory transactions.

This project demonstrates practical usage of **desktop application development**, **database design**, and **CRUD operations** in a real-world business scenario.

---

## 🧩 Features Overview

- 🔐 User authentication (Login system)
- 📋 Product registration and management
- 🗂️ Category-based product filtering
- 📊 Real-time stock tracking
- 🔄 Product entry & exit (stock in / stock out)
- 🧾 Transaction logging and history reports
- 🧠 Input validation and error handling
- 🖥️ Simple and user-friendly WinForms UI

---

## 🛠️ Technologies Used

- **Language:** C#  
- **Framework:** .NET (WinForms)  
- **Database:** SQL Server  
- **Data Access:** ADO.NET  
- **UI:** Windows Forms  

---

## 🗃️ System Modules

### 🔐 User Login Module
- Secure login system connected to SQL Server
- Prevents unauthorized access to the system
- Basic validation for empty or incorrect credentials

---

### 📦 Product Management
- Add, edit, and delete products
- Each product includes:
  - Product Name
  - Category
  - Quantity
  - Description (optional)
- Products are stored and managed in the SQL Server database

---

### 📊 Stock Tracking (Real-Time)
- Stock quantity updates automatically based on:
  - Product entry (incoming stock)
  - Product exit (outgoing stock)
- Prevents negative stock values
- Displays current available inventory in real time

---

### 🔄 Transactions (Entry / Exit)
- Every stock operation is logged
- Tracks:
  - Product name
  - Quantity change
  - Date & time
  - Operation type (IN / OUT)
- Ensures full traceability of inventory changes

---

### 🧾 Reports & History
- Dedicated report view for transaction history
- Filterable by product or category
- Useful for auditing and stock analysis

---

## 🖼️ Application Screenshots

### 🔹 Login Screen
![Login Screen Screenshot](img/1.png)

---

### 🔹 Transaction Report View
![Report View Screenshot](img/3.png)

---


### 🔹 Menu
![Menu](img/2.png)


---

## 🗄️ Database Design (SQL Server)

The database includes tables such as:
- `Users`
- `Products`
- `Categories`
- `Transactions`

Relationships are designed to ensure data consistency and integrity.

---

## ✅ Validations & Error Handling

- Empty input checks
- Numeric validation for quantities
- Database constraint handling
- User-friendly error messages

---

## 🚀 How to Run the Project

1. Clone the repository
2. Restore the SQL Server database
3. Update the connection string in the project
4. Open the solution in Visual Studio
5. Build and run the application

---

## 🎯 Project Purpose

This project was built to:
- Practice **C# WinForms desktop development**
- Work with **SQL Server and relational databases**
- Implement a real-world **inventory management workflow**
- Strengthen understanding of CRUD operations and system design

---

## 📌 Future Improvements
- Role-based access (Admin / User)
- Advanced reporting and export (PDF / Excel)
- Search functionality
- UI modernization (WPF or .NET MAUI)


