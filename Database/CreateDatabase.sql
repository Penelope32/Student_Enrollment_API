IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Student_Enrollment_System_DB')
BEGIN
    CREATE DATABASE Student_Enrollment_System_DB;
END;