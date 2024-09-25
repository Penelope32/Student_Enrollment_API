import React from 'react';


const ProfileCard = () => {
  return (
    <div className="profile-card">
      <img src="path_to_profile_picture" alt="Student" className="profile-pic" />
      <h2>Lindokuhle, MAAKE</h2>
      <div className="profile-info">
        <p><strong>Student Nbr:</strong> 330033</p>
        <p><strong>Gender:</strong> Female</p>
        <p><strong>Birthdate:</strong> 11-Jan-2003</p>
        <p><strong>ID Nbr:</strong> 23123234323442</p>
        <p><strong>Marital Status:</strong> Single</p>
        <p><strong>Home Lang:</strong> English</p>
        <p><strong>Citizenship:</strong> South Africa</p>
        <p><strong>Email Address:</strong> penelopemaake@gmail.com</p>
        <p><strong>Cellphone:</strong> 0760363597</p>
        <p><strong>Postal Address:</strong> 133 Malema street Pretoria Gauteng</p>
      </div>
    </div>
  );
};

export default ProfileCard;
