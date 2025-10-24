# 🏭 Production Planner

A comprehensive ASP.NET Core web application for optimizing production planning with intelligent distribution algorithms. This project helps manufacturing companies create balanced production schedules across workdays.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-6.0-purple)
![MySQL](https://img.shields.io/badge/MySQL-Database-orange)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.0-blue)

## 📋 Project Overview

Production Planner solves the problem of uneven daily production schedules by implementing smart distribution algorithms that maintain total production while creating balanced daily outputs.

### 🎯 Features

- **Task 1**: 5-day work week production planning (Monday-Friday)
- **Task 2**: 7-day production planning with weekend support
- **Database Integration**: MySQL database for storing production plans
- **Test Automation**: 10 pre-defined test cases for validation
- **Responsive Design**: Bootstrap-based modern UI

## 🚀 Quick Start

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (XAMPP recommended)
- [Git](https://git-scm.com/)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/tumbur1999/Production-Planner.git
   cd Production-Planner
   ```

2. **Configure Database**

   - Start MySQL server (XAMPP)
   - Create database: `production_planner`
   - Update connection string in `appsettings.json`

3. **Install Dependencies**

   ```bash
   dotnet restore
   ```

4. **Database Migration**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. **Run Application**
   ```bash
   dotnet run
   ```
   Access: [http://localhost:5137](http://localhost:5137) or any default <i>URL from running command</i>

## 📊 Application Structure

- **🏠 Home & Navigation**

  - Home (/) - Redirects to Task 2
  - Task 1 (/Task1) - 5-day production planning
  - Task 2 (/Task2) - 7-day production planning with database
  - Test Cases (/Test/Task2) - Automated testing suite
  - View All Data (/ViewAllData) - Database records

- **🔧 Core Features**

  - **Task 1: 5-Day Production Planning**: Balances Monday-Friday schedules without database.
  - **Task 2: 7-Day Production Planning**: Handles full week, supports holidays, optional database storage.

- **🧪 Testing Suite**: 10 predefined test cases for Task 2.

- **🗃️ Database Schema**: `ProductionPlans` table with columns for original and improved daily production, total production, working days, plan type.

## 🎨 Technology Stack

- **Backend**: ASP.NET Core 6.0, Entity Framework Core, Pomelo MySQL provider, MVC pattern
- **Frontend**: Bootstrap 5, Razor Pages, Responsive UI, Font Awesome
- **Database**: MySQL, EF Core Migrations

## 🔄 Algorithm Logic

- Count working days (production > 0)
- Compute target: Total / Working Days
- Distribute remainder +1 to highest original production days
- Keep holidays unchanged

**Example Input:** `[4,5,1,7,6,4,0]` → **Output:** `[5,5,4,5,5,4,0]`

## 📝 API Endpoints

| Method | Endpoint               | Description                |
| ------ | ---------------------- | -------------------------- |
| GET    | /                      | Home (redirects to Task 2) |
| GET    | /Task1                 | 5-day production form      |
| GET    | /Task2                 | 7-day production form      |
| POST   | /ProcessTask1          | Process 5-day plan         |
| POST   | /ProcessTask2          | Process 7-day plan         |
| GET    | /ViewAllData           | View database records      |
| GET    | /Test/Task2            | Test cases list            |
| POST   | /Test/RunTask2Test     | Run single test            |
| POST   | /Test/RunAllTask2Tests | Run all tests              |

## 🤝 Contributing

1. Fork the repo
2. Create feature branch: `git checkout -b feature/AmazingFeature`
3. Commit changes: `git commit -m 'Add AmazingFeature'`
4. Push to branch: `git push origin feature/AmazingFeature`
5. Open Pull Request

## 📄 License

MIT License

## 👥 Authors

- [Tumbur](https://github.com/tumbur1999)

## 🙏 Acknowledgments

- ASP.NET Core team
- Bootstrap team
- MySQL for database management

<div align="center">
⭐ Star this repo if you find it helpful!<br>
<a href="https://github.com/tumbur1999/Production-Planner/issues">Report Bug</a> · <a href="https://github.com/tumbur1999/Production-Planner/issues">Request Feature</a>
</div>
