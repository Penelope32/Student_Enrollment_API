
import React from 'react';
import { Link } from 'react-router-dom';
import './styles/Navbar.css'; 

function Navbar() {
  return (
    <nav className="navbar">
      <ul>
        <li><Link to="/">Home</Link></li>
        <li><Link to="/students">Students</Link></li>
        <li><Link to="/departments">Departments</Link></li>
        <li><Link to="/lectures">Lectures</Link></li>
      </ul>
    </nav>
  );
}

export default Navbar;

