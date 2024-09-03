import React, { useState, useEffect } from 'react';
import axios from 'axios';

function StudentList() {
  const [students, setStudents] = useState([]);

  useEffect(() => {
    axios.get('/api/students')
      .then(response => setStudents(response.data))
      .catch(error => console.error(error));
  }, []);

  return (
    <div>
      <h2>Students</h2>
      <ul>
        {students.map(student => (
          <li key={student.id}>{student.firstName} {student.lastName}</li>
        ))}
      </ul>
    </div>
  );
}

export default StudentList;
