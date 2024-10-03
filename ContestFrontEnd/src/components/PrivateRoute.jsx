// components/PrivateRoute.jsx

import React, { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom';
import { AuthContext } from './AuthProvider'; // AuthContext'i import ediyoruz

function PrivateRoute() {
    const { isAuthenticated } = useContext(AuthContext); // AuthContext'ten isAuthenticated de�erini �ekiyoruz
    return isAuthenticated ? <Outlet /> : <Navigate to="/login" />; // E�er kullan�c� authenticated de�ilse login sayfas�na y�nlendiriyoruz
}

export default PrivateRoute;
