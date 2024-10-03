import React from 'react'
import "../assets/css/_dashboard.css"

function Dashboard() {
    var user = JSON.parse(localStorage.getItem('user'));
    return <div className="container dashboard-container">
         <div className="inner-palette">
            <div className="color1">{user.userName}</div>
            <div className="color2">{user.createdOn}</div>
            <div className="color3">{user.email}</div>
            <div className="color4"></div>
            <div className="color5"></div>
            <div className="color6"></div>
            <div className="color7"></div>
            <div className="color8">{user.id}</div>
        </div>
    </div>
}

export default Dashboard