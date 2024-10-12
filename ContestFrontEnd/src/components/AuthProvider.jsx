// components/AuthProvider.jsx

import {  useEffect, createContext } from 'react';

const AuthContext = createContext();

const AuthProvider = ({ children }) => {

    useEffect(() => {
        var expiresOn = new Date(localStorage.getItem('expiresOn'));
        if (expiresOn < new Date() && window.location.pathname != '/login') {
            logout();
        }
    }, []);

    const login = async (credentials) => {
        var fullCredentials = getFullCredentials(credentials);
        try {
            const response = await fetch('https://localhost:44312/api/identity/login', {
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
            localStorage.setItem('expiresOn', data.data.expiresOn)
            return true; // Ba�ar�l� oldu�unu belirten bir de�er d�nd�r
        } catch (err) {
            console.error(err);
            return false; // Ba�ar�s�zl�k durumunu d�nd�r
        }
        //var user = {
        //    userName: "Yasemin",
        //    id: 4,
        //    rating: 9.44,
        //    rank: "Bilge",
        //    rankDegree:4,
        //    email: "email@example.com",
        //    createdOn: new Date(),
        //    awards: "�ok �d�l Alma �d�l�",
        //    team:"Beyin Tak�m�"
        //}
        //localStorage.setItem('user', JSON.stringify(user)); // Save the token in localStorage
        //localStorage.setItem('expiresOn', new Date('10/10/2024'));
        //debugger;
        //return true;
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
        localStorage.removeItem('user'); // Remove the token from localStorage
        localStorage.removeItem('expiresOn'); // Remove the token from localStorage
        window.location.href = '/login'; // Redirect to login
    };

    return (
        <AuthContext.Provider value={{  login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthProvider;
export { AuthContext };
