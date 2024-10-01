// src/components/AuthProvider.jsx
import React, { createContext, useContext, useState, useEffect } from 'react';

// AuthContext'i oluþtur
const AuthContext = createContext();

// AuthProvider bileþeni
const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    // Kullanýcý doðrulamasýný yönetmek için örnek bir iþlev
    const login = () => {
        setIsAuthenticated(true);
        // Token alma ve diðer login iþlemleri burada yapýlabilir
    };

    const logout = () => {
        setIsAuthenticated(false);
        // Çýkýþ iþlemleri burada yapýlabilir
    };

    // Kullanýcý doðrulama durumu deðiþtiðinde yerel depolamadan kontrol edebilirsiniz
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

// AuthContext'i kullanmak için özel bir hook
const useAuth = () => {
    return useContext(AuthContext);
};

// Export default AuthProvider ve named export useAuth
export default AuthProvider;
export { useAuth };