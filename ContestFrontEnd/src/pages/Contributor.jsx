import React from 'react'
import { useEffect, useState } from 'react'
import "../assets/css/contributor.css"

function Contributor() {
    //var data = JSON.parse(localStorage.getItem('user'));
    //data.createdOn = new Date(data.createdOn).toLocaleDateString();
    //var [user, setUser] = useState(data);

    //const { GetUserRating, GetUserRank, GetUserAwards } = DashboardService(); // Servisi �a��r
    //var rating = 0;
    //var rank = "";
    //var awards = [];
    //useEffect(() => {
    //    const fetchUserStats = async () => {
    //        rating = await GetUserRating(user.id);
    //        setUser(prev => ({ ...prev, rating: rating }));
    //        rank = await GetUserRank(user.id)
    //        setUser(prev => ({ ...prev, rank: rank }));
    //        awards = await GetUserAwards(user.id)
    //        setUser(prev => ({ ...prev, awards: awards }));
    //    };

    //    fetchUserStats(); // Sayfa y�klendi�inde �a��r
    //}, []);

    //console.log(user);

    return <div className="y-contributor-container">
        <div className="y-contributor-menu-box"><span className="y-contributor-menu-text">Katk� Puan�m : 117.8</span></div>
        <div className="y-contributor-menu-box"><span className="y-contributor-menu-text">Sorular�m</span></div>
        <div className="y-contributor-menu-box"><span className="y-contributor-menu-text"> Kalite De�erlendirmelerim</span> </div>
        <div className="y-contributor-menu-box"><span className="y-contributor-menu-text"> Zorluk De�erlendirmelerim</span> </div>

    </div>
}

export default Contributor