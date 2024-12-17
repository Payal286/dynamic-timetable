# Dynamic Time-Table Generator

## Description

The **Dynamic Time-Table Generator** is a .NET MVC/.NET Core-based web application that accepts user inputs and generates a dynamic time-table based on the given criteria. This application calculates the total weekly hours, distributes subject hours, and generates a time-table dynamically.

---

## Features

1. **User Inputs**:
   - Number of working days (1-7).
   - Number of subjects per day (maximum 8).
   - Total number of subjects.

2. **Auto Calculation**:
   - Total weekly hours: `No of Working Days × No of Subjects per Day`.

3. **Dynamic Subject Hours**:
   - Accept subject-wise total hours, ensuring the total matches the weekly hours.

4. **Timetable Generation**:
   - A grid-based time-table is generated dynamically based on the entered subject hours.

---

## Example Workflow

1. **User Input**:
   - Number of working days: `5`
   - Subjects per day: `4`
   - Total subjects: `4`

2. **Auto-Generated Total Hours**:
   - Total weekly hours = `5 × 4 = 20`

3. **Input Hours for Subjects**:
   ```
   Subject   | Hours
   -------------------
   Gujarati  | 3
   English   | 4
   Science   | 6
   Maths     | 7
   ```

4. **Generated Time-Table**:
   ```
   Mon       | Tue       | Wed       | Thu       | Fri
   --------------------------------------------------------
   Gujarati  | Maths     | Science   | Science   | Gujarati
   English   | Maths     | Maths     | Maths     | English
   Science   | Gujarati  | English   | English   | Science
   Maths     | Science   | Maths     | Science   | Maths
   ```

---

## Technologies Used

- **.NET MVC / .NET Core** for application development.
- **C#** for back-end logic.

---

## Installation Instructions

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the project in **Visual Studio**.
3. Restore the NuGet packages:
   ```bash
   dotnet restore
   ```
4. Run the project:
   ```bash
   dotnet run
   ```
5. Access the application on `http://localhost:<port>`.

---

## Usage

1. Enter:
   - Working days.
   - Subjects per day.
   - Total number of subjects.
2. Input hours for each subject.
3. Generate the timetable.
4. View and export the timetable as needed.

---

## Constraints

- **Number of Working Days**: Must be between 1 and 7.
- **Subjects Per Day**: Cannot exceed 8.
- **Total Subject Hours**: Must match the weekly total hours.

---

## Author

**Payal Parmar**  
  

---
