import React, { useState } from 'react';
import axios from 'axios';

function StudentForm() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    axios.post('/api/students', { firstName, lastName })
      .then(response => console.log('Student added:', response))
      .catch(error => console.error(error));
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="First Name"
        value={firstName}
        onChange={(e) => setFirstName(e.target.value)}
      />
      <input
        type="text"
        placeholder="Last Name"
        value={lastName}
        onChange={(e) => setLastName(e.target.value)}
      />
      <button type="submit">Add Student</button>
    </form>
  );
}

export default StudentForm;
