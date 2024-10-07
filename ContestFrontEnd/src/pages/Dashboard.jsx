import React from 'react'
import {useEffect, useState} from 'react'
import "../assets/css/dashboard.css"
import DashboardService from "../services/DashboardService"

function Dashboard() {
    var data = JSON.parse(localStorage.getItem('user'));
    data.createdOn = new Date(data.createdOn).toLocaleDateString();
    var [user, setUser] = useState(data);

    const { GetUserRating, GetUserRank, GetUserAwards } = DashboardService(); // Servisi �a��r
    var rating = 0;
    var rank = "";
    var awards = [];
    useEffect(() => {
        const fetchUserStats = async () => {
            rating = await GetUserRating(user.id);
            setUser( prev =>( { ...prev,rating: rating }));
            rank = await GetUserRank(user.id) 
            setUser(prev => ({ ...prev, rank: rank }));
            awards = await GetUserAwards(user.id)
            setUser(prev => ({ ...prev, awards: awards }));
        };

        fetchUserStats(); // Sayfa y�klendi�inde �a��r
    }, []);

    console.log(user);

    return <div className="dashboard-square">
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item1">R�tbe: {user.rank}</div>
            <div className="dashboard-item dashboard-item2">{user.userName}</div>
            <div className="dashboard-item dashboard-item3">{user.email}</div>
        </div>
        
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item4">�d�ller : {user.awards}</div>
            <div className="dashboard-item dashboard-item5 profile-picture">
            </div>
            <div className="dashboard-item dashboard-item6">Puan: {user.rating}</div>
        </div>                                              
                                                            
        <div className="dashboard-line">                    
            <div className="dashboard-item dashboard-item7">Tak�m: {user.team}</div>
            <div className="dashboard-item dashboard-item8">{user.createdOn} giri�li</div>
            <div className="dashboard-item dashboard-item9">Katk� Puan�: 0</div>
        </div>

    </div>
}

export default Dashboard