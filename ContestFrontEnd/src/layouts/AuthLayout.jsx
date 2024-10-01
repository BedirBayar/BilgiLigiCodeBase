// layouts/MainLayout.js
import React from 'react';

function AuthLayout({ children }) {
    return (
        <div>
            <main>{children}</main>
            <footer>Footer</footer>
        </div>
    );
}

export default AuthLayout;