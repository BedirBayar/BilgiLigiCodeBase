import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { useAuth } from './AuthProvider';

function PrivateRoute({ component: Component, ...rest }) {
    const { isAuthenticated } = useAuth(); // Giriþ yapýldý mý kontrol ediliyor

    return (
        <Route
            {...rest}
            render={(props) =>
                isAuthenticated ? (
                    <Component {...props} />
                ) : (
                        <Navigate to="/login" /> // Eðer giriþ yapýlmadýysa login sayfasýna yönlendir
                )
            }
        />
    );
}

export default PrivateRoute;