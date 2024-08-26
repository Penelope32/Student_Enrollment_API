
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Student')
BEGIN

    CREATE TABLE [dbo].[Student] (
        [StudentID] INT PRIMARY KEY,
        [FirstName] VARCHAR(50),
        [LastName] VARCHAR(50),
        [DateOfBirth] Date,
        [Email] VARCHAR(255),
        [PhoneNumber] VARCHAR(15),
    );

END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Course' )
BEGIN
    CREATE TABLE [dbo].[Course](
        [CourseID] INT PRIMARY KEY,
        [CourseName] VARCHAR(255),
        [DepartmentID] INT REFERENCES Department(DepartmentID)

    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Grade' )
BEGIN
    CREATE TABLE [dbo].[Grade](
        [GradeID] INT PRIMARY KEY,
        [Grade] INT,
        [EnrollmentID] INT REFERENCES Enrollment(EnrollmentID)

    );
END;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'User' )
BEGIN
    CREATE TABLE [dbo].[User](
        [UserID] INT PRIMARY KEY,
        [UserName] VARCHAR(255),
        [PassWord]  VARCHAR(255),

    );
END;


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Department' )
BEGIN
    CREATE TABLE [dbo].[Department](
        [DepartmentID] INT PRIMARY KEY,
        [DepartmentName] VARCHAR(255),
        [DepartmentHead]  VARCHAR(255),

    );
END;


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Enrollment' )
BEGIN
    CREATE TABLE [dbo].[Enrollment](
        [EnrollmentID] INT PRIMARY KEY,
        [Status] VARCHAR(255),
        [StudentID] INT REFERENCES Student(StudentID),
        [CourseID] INT REFERENCES Course(CourseID)

    );
END;