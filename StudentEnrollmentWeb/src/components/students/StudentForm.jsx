import React, { useState } from 'react';

const StudentForm = () => {
  const [studentData, setStudentData] = useState({
    firstName: '',
    lastName: '',
    dateOfBirth: '',
    gender: '',
    ethnicity: '',
    department: ''
  });

  const handleChange = (e) => {
    setStudentData({
      ...studentData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // POST request to register a new student
    fetch('/api/students', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(studentData),
    })
      .then(response => response.json())
      .then(data => console.log('Student added:', data))
      .catch(error => console.error('Error adding student:', error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Enroll a New Student</h2>
      <input
        type="text"
        name="firstName"
        placeholder="First Name"
        value={studentData.firstName}
        onChange={handleChange}
      />
      <input
        type="text"
        name="lastName"
        placeholder="Last Name"
        value={studentData.lastName}
        onChange={handleChange}
      />
      <input
        type="date"
        name="dateOfBirth"
        value={studentData.dateOfBirth}
        onChange={handleChange}
      />
      <input
        type="text"
        name="gender"
        placeholder="Gender"
        value={studentData.gender}
        onChange={handleChange}
      />
      <input
        type="text"
        name="ethnicity"
        placeholder="Ethnicity"
        value={studentData.ethnicity}
        onChange={handleChange}
      />
      <input
        type="text"
        name="department"
        placeholder="Department"
        value={studentData.department}
        onChange={handleChange}
      />
      <button type="submit">Enroll Student</button>
    </form>
  );
};

export default StudentForm;
