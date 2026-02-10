# 📚 Bookstore Management System (OOP)

A high-performance C# Windows Forms application featuring a bespoke Dark Mode UI and a robust Object-Oriented Programming (OOP) architecture.  
The system manages client memberships and literary preferences with a strong focus on clean code, maintainability, and data persistence.

---

## ✨ Key Features

- Custom Dark UI  
  - Fully custom title bar with handcrafted Close, Maximize, and Minimize buttons  
  - Completely bypasses standard Windows legacy borders  

- Persistent Storage  
  - Reliable data lifecycle management using a local flat-file system  
  - Data stored in FileClient.txt  

- Dynamic DataGrid  
  - Real-time UI synchronization for Create, Read, and Delete operations  

- Glassmorphism Design  
  - Modern semi-transparent containers  
  - High-fidelity background assets rendered using GDI+  

---

## 🛡️ Advanced OOP Implementation

- Encapsulation  
  - Strict data protection within the Client class using private fields and public properties  

- Abstraction (Interfaces)  
  - IClientFileManager decouples the UI from the data engine  
  - Enables future database migration without UI changes  

- Polymorphism  
  - Unified data handling through interface-based contracts and implementations  

- Type Safety  
  - Extensive use of Enums (ENMembershipType, ENGenre)  
  - Eliminates runtime errors caused by magic strings  

- Separation of Concerns (SoC)  
  - Clear division between Data Model, File Service Layer, and Presentation Layer  

---

## 🛠️ Tech Stack

- Language: C# 12.0  
- Framework: .NET 8.0 (Windows Forms)  
- Styling: GDI+ & Custom Win32 API Interop  
- Version Control: Git & GitHub  

---

## 🚀 Getting Started

### 1️⃣ Clone the Repository

git clone https://github.com/Mark1amgad/bookstore-management-system-oop.git

### 2️⃣ Open the Project

- Launch Visual Studio 2022  
- Open the .sln or .slnx solution file  

### 3️⃣ Prepare Assets

Ensure the background image exists at the following path:

bin/Debug/net8.0-windows/Bldg_Duke Humfreys_BOD_JC_2019_0.jpg

### 4️⃣ Build & Run

- Press F5 to build and launch the application  

---

## 🏗️ Project Structure

├── Client.cs  
│   └── Data model representing a bookstore member with full encapsulation  

├── CFile.cs  
│   └── Service layer handling File I/O operations (Repository Pattern)  

├── IClientFileManager.cs  
│   └── Interface defining required data operations  

├── Form1.cs  
│   └── Presentation layer handling GDI+ rendering and event-driven UI logic  

├── Form1.Designer.cs  
│   └── Optimized designer file for layout stability  

---

## ☕ Author

Developed with ☕ and C# by Mark1amgad  
GitHub: https://github.com/Mark1amgad
