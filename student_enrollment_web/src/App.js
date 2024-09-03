import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

import Home from './pages/Home';
import Students from './pages/Students';
import Departments from './pages/Departments';
import Lectures from './pages/Lectures';
import Navbar from './components/Navbar';
import Sidebar from './components/Sidebar';

function App() {
  return (
    <div>
      <div>
        <Navbar />
        <Sidebar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/students" element={<Students />} />
          <Route path="/departments" element={<Departments />} />
          <Route path="/lectures" element={<Lectures />} />
        </Routes>
      </div>
    </div>
  );
}

export default App;
