import React from 'react'
import "../assets/css/dashboard.css"

function Dashboard() {
    var user = JSON.parse(localStorage.getItem('user'));
    user.createdOn = new Date(user.createdOn).toLocaleDateString();
    return <div className="dashboard-tepsi">
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item1">Rütbe: acemi</div>
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
            <div className="dashboard-item dashboard-item7">Takým: Shaatrin</div>
            <div className="dashboard-item dashboard-item8">{user.createdOn} giriþli</div>
            <div className="dashboard-item dashboard-item9">Katký Puaný: 0</div>
        </div>

    </div>
}

export default Dashboard