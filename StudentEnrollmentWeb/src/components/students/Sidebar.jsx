import React from 'react';

import '../Styles/Student.css'
const Sidebar = () => {
  return (
    <div className="sidebar">
      <div className="logo">
        {/* <img src="path_to_logo" alt="University Logo" /> */}
      </div>
      <div className="nav-links">
        <p>Student Web</p>
        <ul>
          <li>Academic Record</li>
          <li>E-mail Transcript</li>
          <li>Update Contact Details</li>
          <li>Registration</li>
          <li>Changes to Registration</li>
          <li>Cheque and Credit Card Payment</li>
          <li>Proforma Statement</li>
          <li>Bursary Allowances</li>
          <li>Fee Statement</li>
          <li>Online Refund</li>
          <li>Student Finance</li>
          <li>Logout</li>
        </ul>
      </div>
    </div>
  );
};

export default Sidebar;
