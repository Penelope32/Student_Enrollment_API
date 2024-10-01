import React, { useState, useEffect } from 'react';

const StudentList = () => {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    
    fetch('http://localhost:5022/api/Student') 
      .then(response => response.json())
      .then(data => setStudents(data))
      .catch(error => console.error('Error fetching students:', error));
  }, []);

  return (
    <div>
      <h2>Student List</h2>
      <ul>
        {students.map(student => (
          <li key={student.StudentID}>
            {student.FirstName} {student.LastName}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default StudentList;
