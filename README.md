# BookHaven Library Management System

## Overview
The "BookHaven Library Management System" is a desktop application built using **Windows Forms** and **C#** with a SQL Server database. This project is designed to manage the daily operations of a library, including books, members, and borrowing/returning transactions. It features an easy-to-use interface with an attractive design.

---

## Demo Video
Watch the full demonstration of the **BookHaven Library Management System** on YouTube:  
[![Watch the Demo](https://img.youtube.com/vi/pq6-j6C2THM/0.jpg)](https://youtu.be/pq6-j6C2THM)

---

## Project Components

### 1. Main Form
- Displays a welcoming message: **"Welcome to BookHaven Library"**.
- Three main buttons:
  - **Books**: To manage books.
  - **Members**: To manage members.
  - **Borrowing**: To manage borrowing and returning transactions.

### 2. Books Management (Books Form)
#### Fields:
- **Book ID**: Unique identifier for the book.
- **Title**: Title of the book.
- **Author**: Author of the book.
- **Category**: Category or genre of the book.
- **Published Year**: Year the book was published.
- **Availability**: Status (Available/Not Available).

#### Buttons:
- **Add**: To add a new book.
- **Edit**: To update book details.
- **Search**: To search for a specific book.
- **Show**: To display all books.

### 3. Members Management (Members Form)
#### Fields:
- **Member ID**: Unique identifier for the member.
- **Full Name**: Name of the member.
- **Address**: Address of the member.
- **Gender**: Gender (Male/Female).
- **Membership Date**: Date of membership.

#### Buttons:
- **Add**: To add a new member.
- **Edit**: To update member details.
- **Delete**: To remove a member.
- **Search**: To search for a specific member.

### 4. Borrowing Management (Borrowing Form)
#### Fields:
- **Member Selection**: Select a member from a dropdown.
- **Book Selection**: Select a book from a dropdown.
- **Borrowed Date**: Date when the book is borrowed.
- **Due Date**: Due date for returning the book.

#### Buttons:
- **Borrow**: To register a borrowing transaction.
- **Return**: To register a returning transaction.
- **Search**: To search for a borrowing record.
- **Delete**: To delete a borrowing record.

#### Table:
- Displays details of ongoing borrowing transactions, including the member name, book title, borrowing date, due date, and late fees.

---

## Features
1. **User-Friendly Interface**: A simple and visually appealing design with intuitive navigation.
2. **Comprehensive Management**:
   - Add, edit, and delete books and members.
   - Manage borrowing and returning transactions.
3. **SQL Server Integration**: Efficient data storage with fast retrieval and search capabilities.
4. **Flexible and Scalable**: Easily extendable to add new features in the future.

---

## Technical Requirements
- **Programming Language**: C#.
- **User Interface**: Windows Forms.
- **Database**: SQL Server 2022.
- **Development Environment**: Visual Studio 2022.

---

## Objectives
- Digitize library management operations.
- Save time and effort in handling daily tasks.
- Provide accurate tracking of borrowing and returning activities.
