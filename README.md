# Quiz System in .NET 8.0.11 MVC

## Overview
The **Quiz System** is a web-based application built using **.NET 8.0.11** and follows the **3-Tier Architecture** in an **MVC** pattern. This system allows **Admins** to create and manage quizzes with questions that may include images or text. **Students** can take quizzes, view their results, and see the top-scoring students. The application is fully **responsive**, ensuring a seamless experience across devices.

---

## Features

### Admin Features
1. **Create Quizzes**  
   - Add quizzes with titles, descriptions, and categories.  
   - Include questions with optional images or text.  
   - Support for multiple question types (e.g., Multiple Choice, True/False).  

2. **Manage Quizzes**  
   - Edit or delete quizzes and questions.  
   - Set time limits and scoring rules for quizzes.  

3. **View Reports**  
   - Analyze quiz performance and student results.  

### Student Features
1. **Take Quizzes**  
   - Browse available quizzes and start them.  
   - Interactive interface for answering questions.  

2. **View Results**  
   - See scores and correct/incorrect answers after completing a quiz.  

3. **Leaderboard**  
   - View the top-scoring students for each quiz.  

### General Features
- **Responsive Design**: Works seamlessly on desktops, tablets, and mobile devices.  
- **Secure Authentication**: Role-based access control for Admins and Students.  
- **Image Support**: Questions can include images for better engagement.  

---

## Technologies Used
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5, Razor Views  
- **Backend**: C#, .NET 8.0.11, ASP.NET Core MVC  
- **Database**: Entity Framework Core, SQL Server  
- **Authentication**: ASP.NET Identity  
- **Architecture**: 3-Tier Architecture (Presentation, Business Logic, Data Access)  
- **Tools**: Visual Studio 2022, Git for version control  

---

## Project Structure (3-Tier Architecture)

### 1. **Presentation Layer (MVC)**  
   - **Controllers**: Handle user requests (e.g., `QuizController`, `AccountController`).  
   - **Views**: Razor views for rendering the UI (e.g., quiz creation, quiz taking, results).  
   - **Models**: ViewModels for data binding between views and controllers.  

### 2. **Business Logic Layer (Services)**  
   - Contains the core logic for quiz creation, scoring, and reporting.  
   - Interfaces and implementations for modularity and testability.  

### 3. **Data Access Layer (Repositories)**  
   - Handles database operations using Entity Framework Core.  
   - Includes repositories for quizzes, questions, users, and results.  

---

## Database Design
The database includes the following tables:  
1. **Users**: Stores user information (Admins and Students).  
2. **Quizzes**: Contains quiz details (title, description, category).  
3. **Questions**: Stores questions with optional images and correct answers.  
4. **Answers**: Stores possible answers for each question (for multiple-choice questions).  
5. **Results**: Tracks student quiz results.  
---

## How to Run the Project

### Prerequisites
- .NET 8.0.11 SDK  
- Visual Studio 2022  
- SQL Server  

### Steps
1. Clone the repository:  
   ```bash
   git clone https://github.com/Ammar-Yasser8/Quiz_System-.git 
   
Open the solution in Visual Studio 2022.

Update the connection string in appsettings.json to point to your SQL Server instance.

Run the following command in the Package Manager Console to apply migrations:

      Update-Database

Build and run the project.

## Screenshots

1. **Admin Dashboard**: Create and manage quizzes.  
2. **Quiz Interface**: Students take quizzes with optional images.  
3. **Results Page**: View scores and correct/incorrect answers.
4. **Leaderboard**: Top-scoring students for each quiz.

## Conclusion
The Quiz System is a robust, scalable, and user-friendly application built using .NET 8.0.11 and MVC architecture. It provides a comprehensive solution for quiz creation, management, and assessment, making it ideal for educational institutions, corporate training, or any scenario requiring interactive quizzes. 

## Contact

For questions or feedback, please contact:  
**Ammar Yasser**  
**Email**: [ammar.yasser8920@gmail.com](mailto:ammar.yasser8920@gmail.com)  
**LinkedIn**: [https://www.linkedin.com/in/ammar-yasser-a01772250/](https://www.linkedin.com/in/ammar-yasser-a01772250/)  
**GitHub**: [https://github.com/Ammar-Yasser8](https://github.com/Ammar-Yasser8)  
