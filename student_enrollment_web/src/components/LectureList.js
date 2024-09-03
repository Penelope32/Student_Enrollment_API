import React, { useState, useEffect } from 'react';
import { fetchStudents } from './services/apI';

function StudentList() {
  const [students, setStudents] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetchStudents()
      .then(response => setStudents(response.data))
      .catch(error => setError(error));
  }, []);

  if (error) return <div>Error: {error.message}</div>;

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
