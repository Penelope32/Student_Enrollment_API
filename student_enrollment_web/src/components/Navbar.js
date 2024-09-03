import React from 'react';
import { Link } from 'react-router-dom';

function Navbar() {
  return (
    <nav>
      <Link to="/">Home</Link>
      <Link to="/students">Students</Link>
      <Link to="/departments">Departments</Link>
      <Link to="/lectures">Lectures</Link>
    </nav>
  );
}

export default Navbar;
