// components/PrivateRoute.jsx

import React, { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { AuthContext } from './AuthProvider'; // AuthContext'i import ediyoruz

function PrivateRoute() {
    const { isAuthenticated } = useContext(AuthContext); // AuthContext'ten isAuthenticated deðerini çekiyoruz
    return isAuthenticated ? <Outlet /> : <Navigate to="/login" />; // Eðer kullanýcý authenticated deðilse login sayfasýna yönlendiriyoruz
}

export default PrivateRoute;
