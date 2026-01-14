# 🚗 Car Inventory Management System

A Windows Forms (WinForms) desktop application for managing vehicle inventory. This project demonstrates full CRUD (Create, Read, Update, Delete) capabilities using a persistent database connection.

### 🎯 The Problem
Managing car stock via spreadsheets is error-prone. This application provides a user-friendly Graphical User Interface (GUI) to safely insert, search, and manage vehicle records in a relational database.

### 🛠 Tech Stack
* **Language:** C# (.NET Framework)
* **GUI:** Windows Forms
* **Database:** Microsoft Access (via `System.Data.OleDb`)
* **Concepts:** SQL Injection Prevention, Event-Driven Programming, Data Binding

### ✨ Key Features
* **Database Connectivity:** Uses `OleDbConnection` to interface directly with an external Access database (`CARS.accdb`).
* **Dynamic Data Grid:** Displays live inventory data in a `DataGridView`, updating automatically when changes are made.
* **Search Functionality:** Allows users to filter the inventory by Car Make or Model using SQL `WHERE` clauses.
* **Input Validation:** Prevents invalid data entry (e.g., negative prices) before attempting to write to the database.

### 💡 Challenges & Learnings
* **SQL & C# Integration:** I learned how to embed SQL queries within C# code. To make this robust, I ensured that database connections are always closed in a `finally` block (or `using` statement) to prevent resource leaks.
* **UI Responsiveness:** Separating the database logic from the UI thread was important to keep the application from freezing during large data loads.

