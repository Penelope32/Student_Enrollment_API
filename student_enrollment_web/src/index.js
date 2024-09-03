import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
// import './index.css'; // Import global CSS

// If using a router (React Router)
import { BrowserRouter } from 'react-router-dom';

// Create a root element and render the App component
const root = ReactDOM.createRoot(document.getElementById('root'));

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </React.StrictMode>
);
