import React from 'react'
import "../assets/css/dashboard.css"

function Dashboard() {
    var user = JSON.parse(localStorage.getItem('user'));
    user.createdOn = new Date(user.createdOn).toLocaleDateString();
    return <div className="dashboard-tepsi">
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item1">R�tbe: acemi</div>
            <div className="dashboard-item dashboard-item2">{user.userName}</div>
            <div className="dashboard-item dashboard-item3">{user.email}</div>
        </div>
        
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item4">{user.id}</div>
            <div className="dashboard-item dashboard-item5">
                <img className="profile-picture" src="../../public/vite.svg"></img>
            </div>
            <div className="dashboard-item dashboard-item6">Puan: 147</div>
        </div>                                              
                                                            
        <div className="dashboard-line">                    
            <div className="dashboard-item dashboard-item7">Tak�m: Shaatrin</div>
            <div className="dashboard-item dashboard-item8">{user.createdOn} giri�li</div>
            <div className="dashboard-item dashboard-item9">Katk� Puan�: 0</div>
        </div>

    </div>
}

export default Dashboard