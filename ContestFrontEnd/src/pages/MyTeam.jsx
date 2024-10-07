import React from 'react'
import { useEffect, useState } from 'react'
import "../assets/css/myteam.css"

function MyTeam() {
    //var data = JSON.parse(localStorage.getItem('user'));
    //data.createdOn = new Date(data.createdOn).toLocaleDateString();
    //var [user, setUser] = useState(data);

    //const { GetUserRating, GetUserRank, GetUserAwards } = myteamService(); // Servisi �a��r
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
    let team = {
        rank:"�ok Kuvvetli",
        name:"Beyin Takimi",
        rating: 144.12,
        leader: "Yasemin",
        awards: "Agustos Ligi Sampiyonluk Kupasi, MediaMarkt �r�n Yar��mas� Birincilik �d�l�",
        createdOn: new Date().toLocaleString() 
    }

    return (
      <div className="y-myteam-square">
        <div className="y-myteam-line">
            <div className="y-myteam-item ">R�tbe: {team.rank}</div>
            <div className="y-myteam-item ">{team.name}</div>
                <div className="y-myteam-item ">Puan: {team.rating}</div>
        </div>

        <div className="y-myteam-line">
            <div className="y-myteam-item">�d�ller : {team.awards}</div>
            <div className="y-myteam-item team-logo">
            </div>
            <div className="y-myteam-item ">Lider: {team.leader}</div>
        </div>

        <div className="y-myteam-line">
            <div className="y-myteam-item "></div>
            <div className="y-myteam-item ">Kurulu� : {team.createdOn}</div>
            <div className="y-myteam-item ">Sicil : Temiz</div>
        </div>
    </div>
    )
}

export default MyTeam