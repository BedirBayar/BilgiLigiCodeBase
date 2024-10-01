import React from 'react';
import { Route, Navigate } from 'react-router-dom';
import { useAuth } from './AuthProvider';

function PrivateRoute({ component: Component, ...rest }) {
    const { isAuthenticated } = useAuth(); // Giri� yap�ld� m� kontrol ediliyor

    return (
        <Route
            {...rest}
            render={(props) =>
                isAuthenticated ? (
                    <Component {...props} />
                ) : (
                        <Navigate to="/login" /> // E�er giri� yap�lmad�ysa login sayfas�na y�nlendir
                )
            }
        />
    );
}

export default PrivateRoute;