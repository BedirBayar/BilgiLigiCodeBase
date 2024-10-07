// components/PrivateRoute.jsx

import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

function PrivateRoute() {
    
   var expiresOn = new Date(localStorage.getItem('expiresOn'));
   var isAuthenticated= expiresOn > new Date()
     
    return isAuthenticated ? <Outlet /> : <Navigate to="/login" />; // E�er kullan�c� authenticated de�ilse login sayfas�na y�nlendiriyoruz
}

export default PrivateRoute;
