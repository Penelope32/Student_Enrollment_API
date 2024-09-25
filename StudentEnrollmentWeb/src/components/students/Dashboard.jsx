import React from 'react';
import ProfileCard from './ProfileCard';


const Dashboard = () => {
  return (
    <div className="dashboard">
      <div className="profile-section">
        <ProfileCard />
      </div>
      <div className="buttons-section">
        <button className="info-button">School Leaving Information</button>
        <button className="info-button">Residence Information</button>
        <button className="info-button">Financial Information</button>
      </div>
    </div>
  );
};

export default Dashboard;
