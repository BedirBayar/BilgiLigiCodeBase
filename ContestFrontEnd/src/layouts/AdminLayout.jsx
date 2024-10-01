import React from 'react';

function AdminLayout({ children }) {
    return (
        <div>
            <header>AdminNavbar</header>
            <main>{children}</main>
            <footer>Footer</footer>
        </div>
    );
}

export default AdminLayout;