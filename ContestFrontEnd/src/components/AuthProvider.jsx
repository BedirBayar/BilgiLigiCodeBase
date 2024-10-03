// components/AuthProvider.jsx

import { useState, useEffect, createContext } from 'react';

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        // Check localStorage for a token when the app loads
        const token = localStorage.getItem('token');
        if (token) {
            setIsAuthenticated(true);
        }
    }, []);

    const login = async (credentials) => {
        var fullCredentials = getFullCredentials(credentials);
        try {
            const response = await fetch('https://localhost:44313/api/identity/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(fullCredentials),
            });

            if (!response.ok) {
                throw new Error('Login failed');
            }
            const data = await response.json();
            localStorage.setItem('token', data.data.token); // Save the token in localStorage
            localStorage.setItem('user', JSON.stringify(data.data.user)); // Save the token in localStorage
            setIsAuthenticated(true); // Update the authentication state
            return true; // Baþarýlý olduðunu belirten bir deðer döndür
        } catch (err) {
            console.error(err);
            return false; // Baþarýsýzlýk durumunu döndür
        }
    };
    function getFullCredentials(credentials) {
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (regex.test(credentials.owner))
            return {
                email: credentials.owner,
                username: "",
                password: credentials.password
            }
        else return {
            email: "",
            userName: credentials.owner,
            password: credentials.password
        }
    }

    const logout = () => {
        localStorage.removeItem('token'); // Remove the token from localStorage
        setIsAuthenticated(false); // Update the authentication state
        window.location.href = '/login'; // Redirect to login
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
export { AuthContext };
