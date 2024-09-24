using MyApiProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MyApiProject.Controllers{
    [ApiController]
    [Route("api/[controller]")]

    public class CourseController : ControllerBase
    {

        private readonly string _connectionString;


        public CourseController(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentModel>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAllCourses()
        {
            List<CourseModel> course = new List<CourseModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Course";
                                     
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        CourseModel student = new CourseModel
                        {
                            CourseID = reader.GetInt32(0),
                            CourseName = reader.GetString(1),
                            DepartmentID = reader.GetInt32(2),
                        };

                        course.Add(student);
                    }

                    reader.Close();

                    if (course.Count > 0)
                    {
                        return Ok(course);
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