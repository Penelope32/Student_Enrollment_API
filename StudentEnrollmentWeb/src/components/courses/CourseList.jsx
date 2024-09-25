import React, { useState, useEffect } from 'react';

const CourseList = () => {
  const [courses, setCourses] = useState([]);

  useEffect(() => {
    fetch('/api/courses') 
      .then(response => response.json())
      .then(data => setCourses(data))
      .catch(error => console.error('Error fetching courses:', error));
  }, []);

  return (
    <div>
      <h2>Course List</h2>
      <ul>
        {courses.map(course => (
          <li key={course.CourseID}>{course.CourseName}</li>
        ))}
      </ul>
    </div>
  );
};

export default CourseList;
