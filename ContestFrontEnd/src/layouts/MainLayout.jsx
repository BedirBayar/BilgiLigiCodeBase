
import React from 'react';
import Navbar from '../components/Navbar'
import Footer from '../components/Footer'

function MainLayout({ children }) {
    return (
        <div className="d-flex flex-row">
            <Navbar></Navbar>
            <main>{children}</main>
            <Footer></Footer>
        </div>
    );
}

export default MainLayout;