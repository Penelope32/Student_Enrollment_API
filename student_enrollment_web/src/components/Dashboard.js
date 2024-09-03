import React from 'react';
import './styles/Dashboard.css';

function Dashboard() {
  return (
    <div className="dashboard">
      <h2>Dashboard</h2>
      <div className="dashboard-content">
        <p><strong>Important Info:</strong></p>
        <ul>
          <li>Home</li>
          <li>Students</li>
          <li>Departments</li>
          <li>Lectures</li>
        </ul>
      </div>
      <button>Logout</button>
    </div>
    
  );
}

export default Dashboard;
