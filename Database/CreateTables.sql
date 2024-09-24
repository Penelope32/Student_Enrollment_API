

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Roles' )
BEGIN
        CREATE TABLE [dbo].Roles (
        RoleID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) ,
        RoleName varchar(50)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ContactDetails' )
BEGIN
        CREATE TABLE [dbo].ContactDetails (
            ContactID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
            UserID INT NOT NULL,
            Email VARCHAR(255) ,
            PhoneNumber VARCHAR(20),
            CONSTRAINT FK_UserContact FOREIGN KEY (UserID) REFERENCES Users(UserID)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users' )
BEGIN
        CREATE TABLE [dbo].Users (
            UserID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
            FirstName VARCHAR(255) NOT NULL,
            LastName VARCHAR(255) NOT NULL,
            RoleID INT NOT NULL,
            FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ethnicity' )
BEGIN
        CREATE TABLE [dbo].Ethnicity(
        EthnicityID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) ,
        Ethnicity VARCHAR(30)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Genders' )
BEGIN
        CREATE TABLE [dbo].Genders(
        GenderID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) ,
        Gender VARCHAR(10)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Departments' )
BEGIN
        CREATE TABLE [dbo].Departments(
        DepartmentID INT PRIMARY KEY CLUSTERED IDENTITY(1,1) ,
        DepartmentName varchar(50)
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students' )
BEGIN
        CREATE TABLE [dbo].Students(
            StudentID CHAR(13) PRIMARY KEY CLUSTERED, 
            UserID INT NOT NULL,
            DateOfBirth DATE NOT NULL,
            GenderID INT REFERENCES Genders(GenderID), 
            EthnicityID INT REFERENCES [dbo].Ethnicity(EthnicityID),
            DepartmentID INT REFERENCES [dbo].Departments(DepartmentID),
            CONSTRAINT FK_StudentUser FOREIGN KEY (UserID) REFERENCES Users(UserID),
            CONSTRAINT CHK_DateOfBirth CHECK (DateOfBirth <= SYSDATETIME())
        );
END;


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Course' )
BEGIN
        CREATE TABLE [dbo].Course(
            CourseID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
            CourseName VARCHAR(30),
            DepartmentID INT,
            FOREIGN KEY (DepartmentID) REFERENCES [dbo].Departments(DepartmentID)   
        );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Administrator' )
BEGIN
        CREATE TABLE [dbo].Administrator(
            AdminID INT PRIMARY KEY CLUSTERED IDENTITY(1,1),
            UserID INT NOT NULL,
            FOREIGN KEY (UserID) REFERENCES Users(UserID)
        )
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Enrollments' )
BEGIN
        CREATE TABLE Enrollments (
            enrollment_id INT PRIMARY KEY IDENTITY(1,1),
            student_id CHAR,
            course_id INT, 
            enrollment_date DATE, 
            FOREIGN KEY (student_id) REFERENCES Students(student_id),
            FOREIGN KEY (course_id) REFERENCES Courses(course_id)
        );
END;