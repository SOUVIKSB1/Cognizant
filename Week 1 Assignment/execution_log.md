# Execution Log of Week 1 Assignment Projects

This log contains the console output of all 18 projects running sequentially.

## Algorithm & Data Structures
### InventoryManagementSystem
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/InventoryManagementSystem/Inventory.cs(60,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/InventoryManagementSystem/InventoryManagementSystem.csproj]
========================================
Inventory Management System Test
========================================
Adding products...

--- Current Inventory ---
ID: P001 | Name: Laptop | Quantity: 10 | Price: $999.99
ID: P002 | Name: Smartphone | Quantity: 25 | Price: $499.99
ID: P003 | Name: Headphones | Quantity: 50 | Price: $79.99
-------------------------

Updating Smartphone quantity to 30 and price to 449.99...

--- Current Inventory ---
ID: P001 | Name: Laptop | Quantity: 10 | Price: $999.99
ID: P002 | Name: Smartphone | Quantity: 30 | Price: $449.99
ID: P003 | Name: Headphones | Quantity: 50 | Price: $79.99
-------------------------

Searching for product P001...
Found: ID: P001 | Name: Laptop | Quantity: 10 | Price: $999.99

Deleting Headphones (P003)...

--- Current Inventory ---
ID: P001 | Name: Laptop | Quantity: 10 | Price: $999.99
ID: P002 | Name: Smartphone | Quantity: 30 | Price: $449.99
-------------------------

Inventory management test completed.
```

### EcommercePlatformSearch
```text
========================================
E-commerce Search Benchmarking
========================================
Unsorted Products:
ID: P103 | Name: Sony Headphones | Category: Electronics
ID: P101 | Name: Apple MacBook | Category: Electronics
ID: P105 | Name: Nike Running Shoes | Category: Apparel
ID: P102 | Name: Samsung Galaxy S23 | Category: Electronics
ID: P104 | Name: Dell Monitor | Category: Electronics
ID: P106 | Name: Leather Wallet | Category: Accessories

--- Linear Search for 'Dell Monitor' ---
Found at index 4: ID: P104 | Name: Dell Monitor | Category: Electronics

Sorting products by Name for Binary Search...
Sorted Products:
ID: P101 | Name: Apple MacBook | Category: Electronics
ID: P104 | Name: Dell Monitor | Category: Electronics
ID: P106 | Name: Leather Wallet | Category: Accessories
ID: P105 | Name: Nike Running Shoes | Category: Apparel
ID: P102 | Name: Samsung Galaxy S23 | Category: Electronics
ID: P103 | Name: Sony Headphones | Category: Electronics

--- Binary Search for 'Dell Monitor' ---
Found at index 1 in sorted array: ID: P104 | Name: Dell Monitor | Category: Electronics

--- Performance Benchmarking on 1,000 items ---
Linear Search Result Index: 750 | Time: 11333 ticks
Binary Search Result Index: 750 | Time: 541 ticks
Binary search was 20.95x faster in this test run.
```

### SortingCustomerOrders
```text
========================================
Sorting Customer Orders Benchmarking
========================================
Original Orders:
ID: O001 | Customer: Alice | Total Price: $250.50
ID: O002 | Customer: Bob | Total Price: $120.00
ID: O003 | Customer: Charlie | Total Price: $450.75
ID: O004 | Customer: Diana | Total Price: $80.20
ID: O005 | Customer: Ethan | Total Price: $310.00

--- Running Bubble Sort ---
ID: O004 | Customer: Diana | Total Price: $80.20
ID: O002 | Customer: Bob | Total Price: $120.00
ID: O001 | Customer: Alice | Total Price: $250.50
ID: O005 | Customer: Ethan | Total Price: $310.00
ID: O003 | Customer: Charlie | Total Price: $450.75

--- Running Quick Sort ---
ID: O004 | Customer: Diana | Total Price: $80.20
ID: O002 | Customer: Bob | Total Price: $120.00
ID: O001 | Customer: Alice | Total Price: $250.50
ID: O005 | Customer: Ethan | Total Price: $310.00
ID: O003 | Customer: Charlie | Total Price: $450.75

--- Benchmarking on 500 random orders ---
Bubble Sort Time: 1124959 ticks
Quick Sort Time: 54667 ticks
Quick Sort was 20.58x faster in this test.
```

### EmployeeManagementSystem
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/EmployeeManagementSystem/EmployeeRegistry.cs(51,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/EmployeeManagementSystem/EmployeeManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/EmployeeManagementSystem/EmployeeRegistry.cs(96,38): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/EmployeeManagementSystem/EmployeeManagementSystem.csproj]
========================================
Employee Management System Test
========================================
Adding employees...

--- Employee Registry List ---
ID: E001 | Name: John Doe | Position: Software Engineer | Salary: $75000.00
ID: E002 | Name: Jane Smith | Position: Project Manager | Salary: $85000.00
ID: E003 | Name: Bob Johnson | Position: QA Analyst | Salary: $60000.00
ID: E004 | Name: Alice Brown | Position: HR Specialist | Salary: $65000.00
------------------------------

Searching for employee with ID E002...
Found: ID: E002 | Name: Jane Smith | Position: Project Manager | Salary: $85000.00

Deleting employee with ID E003...

--- Employee Registry List ---
ID: E001 | Name: John Doe | Position: Software Engineer | Salary: $75000.00
ID: E002 | Name: Jane Smith | Position: Project Manager | Salary: $85000.00
ID: E004 | Name: Alice Brown | Position: HR Specialist | Salary: $65000.00
------------------------------

Adding two more employees to test capacity limit (max 5)...

--- Employee Registry List ---
ID: E001 | Name: John Doe | Position: Software Engineer | Salary: $75000.00
ID: E002 | Name: Jane Smith | Position: Project Manager | Salary: $85000.00
ID: E004 | Name: Alice Brown | Position: HR Specialist | Salary: $65000.00
ID: E005 | Name: Charlie Green | Position: UX Designer | Salary: $70000.00
ID: E006 | Name: David White | Position: DevOps Engineer | Salary: $80000.00
------------------------------

```

### TaskManagementSystem
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(24,21): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(25,21): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(22,16): warning CS8618: Non-nullable field '_head' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(22,16): warning CS8618: Non-nullable field '_tail' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(15,24): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(12,20): warning CS8618: Non-nullable property 'Next' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(58,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/SinglyLinkedList.cs(91,29): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/TaskManagementSystem/TaskManagementSystem.csproj]
========================================
Task Management System Test
========================================
Adding tasks...

--- Current Task List ---
ID: T001 | Task Name: Design Database Schema | Status: Completed
ID: T002 | Task Name: Implement API Endpoints | Status: In Progress
ID: T003 | Task Name: Write Unit Tests | Status: Pending
ID: T004 | Task Name: Configure CI/CD Pipelines | Status: Pending
-------------------------

Searching for task with ID T002...
Found: ID: T002 | Task Name: Implement API Endpoints | Status: In Progress

Deleting task with ID T003...

--- Current Task List ---
ID: T001 | Task Name: Design Database Schema | Status: Completed
ID: T002 | Task Name: Implement API Endpoints | Status: In Progress
ID: T004 | Task Name: Configure CI/CD Pipelines | Status: Pending
-------------------------

Deleting head task (T001)...

--- Current Task List ---
ID: T002 | Task Name: Implement API Endpoints | Status: In Progress
ID: T004 | Task Name: Configure CI/CD Pipelines | Status: Pending
-------------------------

```

### LibraryManagementSystem
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/Library.cs(10,70): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/LibraryManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/Library.cs(19,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/LibraryManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/Library.cs(25,70): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/LibraryManagementSystem.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/Library.cs(48,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Algorithm_Data_Structures/LibraryManagementSystem/LibraryManagementSystem.csproj]
========================================
Library Management System Search Test
========================================
Unsorted Books in Library:
ID: B003 | Title: "The Great Gatsby" | Author: F. Scott Fitzgerald
ID: B001 | Title: "To Kill a Mockingbird" | Author: Harper Lee
ID: B005 | Title: "1984" | Author: George Orwell
ID: B002 | Title: "Moby Dick" | Author: Herman Melville
ID: B004 | Title: "Pride and Prejudice" | Author: Jane Austen

Searching for '1984' using Linear Search...
Found: ID: B005 | Title: "1984" | Author: George Orwell

Sorting books by title for Binary Search...
Sorted Books in Library:
ID: B005 | Title: "1984" | Author: George Orwell
ID: B002 | Title: "Moby Dick" | Author: Herman Melville
ID: B004 | Title: "Pride and Prejudice" | Author: Jane Austen
ID: B003 | Title: "The Great Gatsby" | Author: F. Scott Fitzgerald
ID: B001 | Title: "To Kill a Mockingbird" | Author: Harper Lee

Searching for '1984' using Binary Search...
Found: ID: B005 | Title: "1984" | Author: George Orwell

Searching for non-existent 'The Catcher in the Rye' using Binary Search...
'The Catcher in the Rye' was not found.
```

### FinancialForecasting
```text
========================================
Financial Forecasting Test
========================================
Initial Investment (PV): $1000.00
Annual Growth Rate (r): 5%
Forecasting Horizon: 10 years

Recursive Forecasted Value: $1628.89
Iterative Forecasted Value: $1628.89

Success: Both implementations yielded matching values.

Year-by-Year Progression:
Year 01: $1050.00
Year 02: $1102.50
Year 03: $1157.62
Year 04: $1215.51
Year 05: $1276.28
Year 06: $1340.10
Year 07: $1407.10
Year 08: $1477.46
Year 09: $1551.33
Year 10: $1628.89
```

## Design Patterns
### SingletonPatternExample
```text
========================================
Singleton Pattern Example
========================================
Accessing Logger.Instance for the first time (l1)...
Logger Instance Initialized (Private Constructor Called).
[2026-06-22 14:22:16] LOG: First log message from l1.

Accessing Logger.Instance again (l2)...
[2026-06-22 14:22:16] LOG: Second log message from l2.

Verifying instance identity...
Are l1 and l2 the exact same instance? True
SUCCESS: Singleton pattern successfully verified! Only one instance exists.
```

### FactoryMethodPatternExample
```text
========================================
Factory Method Pattern Example
========================================

--- Testing Word Document Creation ---
Opening Word Document (.docx)...
Saving Word Document...
Closing Word Document.

--- Testing PDF Document Creation ---
Opening PDF Document (.pdf)...
Saving (exporting) PDF Document...
Closing PDF Document.

--- Testing Excel Document Creation ---
Opening Excel Spreadsheet (.xlsx)...
Saving Excel Spreadsheet...
Closing Excel Spreadsheet.

Factory Method Pattern demonstration completed.
```

### BuilderPatternExample
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/BuilderPatternExample/Computer.cs(53,20): warning CS8618: Non-nullable property 'GPU' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/BuilderPatternExample/BuilderPatternExample.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/BuilderPatternExample/Computer.cs(53,20): warning CS8618: Non-nullable property 'OS' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/BuilderPatternExample/BuilderPatternExample.csproj]
========================================
Builder Pattern Example
========================================

Assembling Gaming PC...
Computer Configuration:
  - CPU: Intel Core i9-14900K
  - RAM: 32GB DDR5
  - Storage: 2TB NVMe SSD
  - GPU: NVIDIA GeForce RTX 4090
  - OS: Windows 11 Pro
  - WiFi: Yes
  - Bluetooth: Yes

Assembling Office PC...
Computer Configuration:
  - CPU: Intel Core i5-13400
  - RAM: 8GB DDR4
  - Storage: 512GB SATA SSD
  - GPU: Integrated Graphics
  - OS: Windows 11 Home
  - WiFi: No
  - Bluetooth: No

Assembling Headless Server Node...
Computer Configuration:
  - CPU: AMD EPYC 9654
  - RAM: 256GB ECC RAM
  - Storage: 8TB Enterprise SSD
  - GPU: Integrated Graphics
  - OS: No OS
  - WiFi: No
  - Bluetooth: No

Builder Pattern demonstration completed.
```

### AdapterPatternExample
```text
========================================
Adapter Pattern Example
========================================

Processing payment of $149.99 via PayPal...
PayPal: Processing transaction of $149.99 USD.

Processing payment of $149.99 via Stripe...
Stripe: Capturing credit card charge of 14999 cents.

Adapter Pattern demonstration completed.
```

### DecoratorPatternExample
```text
========================================
Decorator Pattern Example
========================================

--- Sending via Base Notifier (Email Only) ---
Sending Email: "CRITICAL: Database connection limit exceeded!" to primary recipient.

--- Sending via Email + SMS Decorator ---
Sending Email: "CRITICAL: Database connection limit exceeded!" to primary recipient.
Sending SMS: "CRITICAL: Database connection limit exceeded!" to registered phone number.

--- Sending via Email + Slack Decorator ---
Sending Email: "CRITICAL: Database connection limit exceeded!" to primary recipient.
Sending Slack message: "CRITICAL: Database connection limit exceeded!" to channel #alerts.

--- Sending via Email + SMS + Slack Decorator ---
Sending Email: "CRITICAL: Database connection limit exceeded!" to primary recipient.
Sending SMS: "CRITICAL: Database connection limit exceeded!" to registered phone number.
Sending Slack message: "CRITICAL: Database connection limit exceeded!" to channel #alerts.

Decorator Pattern demonstration completed.
```

### ProxyPatternExample
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ProxyPatternExample/ProxyImage.cs(13,26): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ProxyPatternExample/ProxyPatternExample.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ProxyPatternExample/ProxyImage.cs(10,16): warning CS8618: Non-nullable field '_realImage' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ProxyPatternExample/ProxyPatternExample.csproj]
========================================
Proxy Pattern Example
========================================

--- Displaying Image 1 for the first time ---
ProxyImage: First time display request. Instantiating RealImage for 'nature_landscape.jpg'...
RealImage: Loading image 'nature_landscape.jpg' from remote server...
RealImage: Image 'nature_landscape.jpg' loaded successfully.
RealImage: Displaying image 'nature_landscape.jpg'.
Time taken: 1504 ms

--- Displaying Image 1 for the second time ---
ProxyImage: Cache hit! Retaining already loaded RealImage for 'nature_landscape.jpg'...
RealImage: Displaying image 'nature_landscape.jpg'.
Time taken: 0 ms (Expected: 0 ms delay)

--- Displaying Image 2 for the first time ---
ProxyImage: First time display request. Instantiating RealImage for 'family_photo.png'...
RealImage: Loading image 'family_photo.png' from remote server...
RealImage: Image 'family_photo.png' loaded successfully.
RealImage: Displaying image 'family_photo.png'.
Time taken: 1505 ms

--- Displaying Image 2 for the second time ---
ProxyImage: Cache hit! Retaining already loaded RealImage for 'family_photo.png'...
RealImage: Displaying image 'family_photo.png'.
Time taken: 0 ms

Proxy Pattern demonstration completed.
```

### ObserverPatternExample
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ObserverPatternExample/StockMarket.cs(12,16): warning CS8618: Non-nullable field '_stockName' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/ObserverPatternExample/ObserverPatternExample.csproj]
========================================
Observer Pattern Example
========================================

Registering observers...
[StockMarket]: Registered observer 'iPhone Client'.
[StockMarket]: Registered observer 'Android Client'.
[StockMarket]: Registered observer 'Financial Web Portal'.

[StockMarket]: Stock 'GOOGL' changed to $175.40. Notifying observers...
[Mobile App - iPhone Client]: Push Notification - 'GOOGL' is now $175.40.
[Mobile App - Android Client]: Push Notification - 'GOOGL' is now $175.40.
[Web Portal - Financial Web Portal]: UI Dashboard updated - 'GOOGL' ticker shows $175.40.

[StockMarket]: Stock 'AAPL' changed to $189.95. Notifying observers...
[Mobile App - iPhone Client]: Push Notification - 'AAPL' is now $189.95.
[Mobile App - Android Client]: Push Notification - 'AAPL' is now $189.95.
[Web Portal - Financial Web Portal]: UI Dashboard updated - 'AAPL' ticker shows $189.95.

Deregistering Android Client...
[StockMarket]: Deregistered observer 'Android Client'.

[StockMarket]: Stock 'MSFT' changed to $420.10. Notifying observers...
[Mobile App - iPhone Client]: Push Notification - 'MSFT' is now $420.10.
[Web Portal - Financial Web Portal]: UI Dashboard updated - 'MSFT' ticker shows $420.10.

Observer Pattern demonstration completed.
```

### StrategyPatternExample
```text
========================================
Strategy Pattern Example
========================================

--- Setting Strategy: Credit Card ---
Paying order 1 ($250.00)...
Paid $250.00 using Credit Card (Holder: Souvik Sen, Card: XXXX-XXXX-XXXX-3456).

--- Swapping Strategy: PayPal ---
Paying order 2 ($89.95)...
Paid $89.95 using PayPal (Account Email: souvik.sen@example.com).

Strategy Pattern demonstration completed.
```

### CommandPatternExample
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/CommandPatternExample/RemoteControl.cs(7,26): warning CS8618: Non-nullable field '_command' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/CommandPatternExample/CommandPatternExample.csproj]
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/CommandPatternExample/Program.cs(35,31): warning CS8625: Cannot convert null literal to non-nullable reference type. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/CommandPatternExample/CommandPatternExample.csproj]
========================================
Command Pattern Example
========================================

--- Setting command: Light On ---
[Light - Living Room]: The light is ON.

--- Setting command: Light Off ---
[Light - Living Room]: The light is OFF.

--- Setting command to null ---
RemoteControl: No command is assigned to this slot.

Command Pattern demonstration completed.
```

### MVCPatternExample
```text
========================================
MVC Pattern Example
========================================
Initial details:

--- Student Records Display ---
  ID:    S101
  Name:  John Doe
  Grade: B
-------------------------------

Updating student name and grade...
Updated details:

--- Student Records Display ---
  ID:    S101
  Name:  Souvik Sen
  Grade: A+
-------------------------------

MVC Pattern demonstration completed.
```

### DependencyInjectionExample
```text
/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/DependencyInjectionExample/CustomerRepositoryImpl.cs(27,20): warning CS8603: Possible null reference return. [/Users/souvik/Desktop/MY_CODES/Cognizant/Week 1 Assignment/Design_Patterns/DependencyInjectionExample/DependencyInjectionExample.csproj]
========================================
Dependency Injection Example
========================================

Querying customer C001...
CustomerService: Customer found. ID: C001 | Name: Souvik Sen

Querying customer C003...
CustomerService: Customer found. ID: C003 | Name: John Doe

Querying non-existent customer C005...
CustomerService: Customer with ID C005 not found.

Dependency Injection demonstration completed.
```

