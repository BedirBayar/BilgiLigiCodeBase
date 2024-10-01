// src/components/AuthProvider.jsx
import React, { createContext, useContext, useState, useEffect } from 'react';

// AuthContext'i olu�tur
const AuthContext = createContext();

// AuthProvider bile�eni
const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    // Kullan�c� do�rulamas�n� y�netmek i�in �rnek bir i�lev
    const login = () => {
        setIsAuthenticated(true);
        // Token alma ve di�er login i�lemleri burada yap�labilir
    };

    const logout = () => {
        setIsAuthenticated(false);
        // ��k�� i�lemleri burada yap�labilir
    };

    // Kullan�c� do�rulama durumu de�i�ti�inde yerel depolamadan kontrol edebilirsiniz
    useEffect(() => {
        const token = localStorage.getItem('token');
        if (token) {
            setIsAuthenticated(true);
        }
    }, []);

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

// AuthContext'i kullanmak i�in �zel bir hook
const useAuth = () => {
    return useContext(AuthContext);
};

// Export default AuthProvider ve named export useAuth
export default AuthProvider;
export { useAuth };