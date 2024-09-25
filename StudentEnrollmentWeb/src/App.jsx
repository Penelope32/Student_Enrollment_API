import { useState } from 'react'
import React from 'react';
import { BrowserRouter as Router, Routes, Route , Link} from 'react-router-dom';
import StudentList from './components/students/StudentList';
import StudentForm from './components/students/StudentForm';
import CourseList from './components/courses/CourseList';
import Home from './components/Home';

import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
    <Router>
      <div>
        <nav>
          <Link to="/students">Student List</Link>
          <Link to="/add-student">Add Student</Link>
          <Link to="/courses">Course List</Link>
        </nav>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/students" element={<StudentList />} />
          <Route path="/add-student" element={<StudentForm />} />
          <Route path="/courses" element={<CourseList />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App
