// components/PrivateRoute.jsx

import React from 'react';
import { Navigate, Outlet } from 'react-router-dom';

function PrivateRoute() {
    
   var expiresOn = new Date(localStorage.getItem('expiresOn'));
   var isAuthenticated= expiresOn > new Date()
     
    return isAuthenticated ? <Outlet /> : <Navigate to="/login" />; // Eðer kullanýcý authenticated deðilse login sayfasýna yönlendiriyoruz
}

export default PrivateRoute;
