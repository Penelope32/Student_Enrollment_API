
using MyApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MyApiProject.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController : ControllerBase
    {

        private readonly string _connectionString;


        public StudentController(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] StudentModel StudentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var userSql = "SELECT UserID FROM Users WHERE FirstName = @FirstName AND LastName = @LastName";
                    var userCommand = new SqlCommand(userSql, connection);
                    userCommand.Parameters.AddWithValue("@FirstName", StudentModel.FirstName);
                    userCommand.Parameters.AddWithValue("@LastName", StudentModel.LastName);
                    var userId = (int)await userCommand.ExecuteScalarAsync();

                    var genderSql = "SELECT GenderID FROM Genders WHERE Gender = @Gender";
                    var genderCommand = new SqlCommand(genderSql, connection);
                    genderCommand.Parameters.AddWithValue("@Gender", StudentModel.Gender);
                    var genderId = (int)await genderCommand.ExecuteScalarAsync();

                    var ethnicitySql = "SELECT EthnicityID FROM Ethnicity WHERE Ethnicity = @Ethnicity";
                    var ethnicityCommand = new SqlCommand(ethnicitySql, connection);
                    ethnicityCommand.Parameters.AddWithValue("@Ethnicity", StudentModel.Ethnicity);
                    var ethnicityId = (int)await ethnicityCommand.ExecuteScalarAsync();

                    var departmentSql = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @Department";
                    var departmentCommand = new SqlCommand(departmentSql, connection);
                    departmentCommand.Parameters.AddWithValue("@Department", StudentModel.Department);
                    var departmentId = (int)await departmentCommand.ExecuteScalarAsync();

                    var sql = "INSERT INTO Student (StudentID, UserID, DateOfBirth, GenderID, EthnicityID, DepartmentID ) VALUES (@StudentID, @UserID, @DateOfBirth, @GenderID, @EthnicityID, @DepartmentID)";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", StudentModel.StudentID);
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@DateOfBirth", StudentModel.DateOfBirth);
                        command.Parameters.AddWithValue("@GenderID", genderId);
                        command.Parameters.AddWithValue("@EthnicityID", ethnicityId);
                        command.Parameters.AddWithValue("@DepartmentID",departmentId );
                        await command.ExecuteNonQueryAsync();
                    }
                }

                return Ok("User successfully registered");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
    
        [HttpGet("{StudentId}")]
        [ProducesResponseType(typeof(IEnumerable<StudentModel>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetStudentById(int StudentId)
        {
            List<StudentModel> students = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT  FirstName, LastName, DateOfBirth, Email, PhoneNumber FROM Student WHERE StudentID = @StudentID,";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", StudentId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            StudentID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            DateOfBirth = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                            Ethnicity = reader.GetString(5),
                            Department = reader.GetString(6)
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    if (students.Count > 0)
                    {
                        return Ok(students);
                    }
                    else
                    {
                        return NotFound(); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, "An error occurred while processing the request.");
                }
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentModel>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAllStudent()
        {
            List<StudentModel> students = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @" SELECT 
                                s.StudentID,
                                u.FirstName,
                                u.LastName,
                                c.Email,
                                c.PhoneNumber,
                                g.Gender,
                                e.Ethnicity,
                                d.DepartmentName, 
                                s.DateOfBirth
                                FROM 
                                    Students s
                                JOIN 
                                    Users u ON s.UserID = u.UserID
                                JOIN 
                                    ContactDetails c ON u.UserID = c.UserID
                                JOIN 
                                    Genders g ON s.GenderID = g.GenderID
                                JOIN 
                                    Ethnicity e ON s.EthnicityID = e.EthnicityID
                                JOIN 
                                    Departments d ON s.DepartmentID = d.DepartmentID,"
                                     ;
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            StudentID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            DateOfBirth = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                            Ethnicity = reader.GetString(5),
                            Department = reader.GetString(6)
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    if (students.Count > 0)
                    {
                        return Ok(students);
                    }
                    else
                    {
                        return NotFound(); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, "An error occurred while processing the request.");
                }
            }
        }

        [HttpGet("{CourseName}")]
        [ProducesResponseType(typeof(IEnumerable<StudentModel>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetStudentInCourse(int CourseName)
        {
            List<StudentModel> students = new List<StudentModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"  SELECT 
                                    s.StudentID, 
                                    u.FirstName, 
                                    u.LastName, 
                                    COUNT(*) OVER () AS TotalCount
                                FROM 
                                    Enrollments e
                                INNER JOIN Students s ON e.student_id = s.StudentID
                                INNER JOIN Users u ON s.UserID = u.UserID
                                INNER JOIN Courses c ON e.course_id = c.CourseID
                                WHERE 
                                    c.CourseName = @CourseName;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseName", CourseName);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            StudentID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2)
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    if (students.Count > 0)
                    {
                        return Ok(students);
                    }
                    else
                    {
                        return NotFound(); 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, "An error occurred while processing the request.");
                }
            }
        }


    }
}




