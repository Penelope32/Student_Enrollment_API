
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

                    var sql = "INSERT INTO Student (StudentID, FirstName, LastName, DateOfBirth, Email, PhoneNumber ) VALUES (@StudentID, @FirstName, @LastName, @DateOfBirth, @Email, @PhoneNumber)";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@StudentID", StudentModel.StudentID);
                        command.Parameters.AddWithValue("@FirstName", StudentModel.FirstName);
                        command.Parameters.AddWithValue("@LastName", StudentModel.LastName);
                        command.Parameters.AddWithValue("@DateOfBirth", StudentModel.DateOfBirth);
                        command.Parameters.AddWithValue("@Email", StudentModel.Email);
                        command.Parameters.AddWithValue("@PhoneNumber", StudentModel.PhoneNumber);
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
        
    
        // Search for contact details by UserID
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
                command.Parameters.AddWithValue("@StudentId", StudentId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            
                            FirstName = reader.GetString(0),
                            LastName = reader.GetString(1),
                            DateOfBirth = reader.GetString(2),
                            Email = reader.GetString(3),
                            PhoneNumber = reader.GetString(4)
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
