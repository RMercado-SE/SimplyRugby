SimplyRugby - Team Management Application

Overview

SimplyRugby is a team management application developed in C# using WPF (Windows Presentation Foundation). The application is designed to help rugby coaches and secretaries efficiently manage player information, squad selection, and track various rugby-related skills. The app allows different users to log in with distinct roles and access levels, enabling them to perform relevant tasks such as viewing player data and updating player skills.

This project showcases essential skills in object-oriented programming, WPF for UI design, and database interaction through a Data Access Layer. It is built with a focus on real-world application scenarios, combining user-friendly design and robust functionality to manage a sports team.

Features

User Authentication: Two user roles (coach and secretary) with password-protected logins.

Player Management: View and update individual player skills, including rugby-specific attributes like spin pass, punt kick, drop kick, and more.

Squad Selection: Display squads for different age groups (14, 16, 18, 20, and 21) with an easy-to-use interface for navigating between squads.

Database Integration: SQL-based data access layer to retrieve and store player information, ensuring persistence of data and smooth user experience.

UI Design: Clean and intuitive interface built using WPF, tailored to the specific needs of coaches and secretaries managing teams.

Project Structure

MainWindow.xaml.cs: Handles the login functionality and navigates users based on their role (coach or secretary).

CoachMainWindow.xaml.cs: Manages the squad selection and viewing of player information for coaches.

SecretaryMainWindow.xaml.cs: Allows secretaries to access and update player data, with specific options related to team administration.

PlayerInfo.cs: The class representing a player's information, including rugby skills, age, and other personal details.

DataAccess.cs: A class responsible for managing data connections, running SQL queries, and interacting with the database to retrieve or update player and squad information.

Technologies Used
C#: Core programming language used for all backend logic.

WPF (Windows Presentation Foundation): Framework used for creating the graphical user interface.

SQL: Database management system used to store and retrieve player data.

MVVM Design Pattern: Implemented to separate the business logic from the user interface, ensuring modularity and ease of maintenance.
