import React from 'react'
import { useEffect, useState } from 'react'
import "../assets/css/leagues.css"
import LeagueListItem from "../components/league/LeagueListItem"

function Leagues() {
    //var data = JSON.parse(localStorage.getItem('user'));
    //data.createdOn = new Date(data.createdOn).toLocaleDateString();
    //var [user, setUser] = useState(data);

    //const { GetUserRating, GetUserRank, GetUserAwards } = DashboardService(); // Servisi çaðýr
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

    //    fetchUserStats(); // Sayfa yüklendiðinde çaðýr
    //}, []);

    //console.log(user);
    let model = [{
        image: "../../public/assets/images/league.png",
        name: "Sampiyonlar Ligi"
    },{
        image: "../../public/assets/images/league.png",
        name: "Ekim Super Ligi"
    },{
        image: "../../public/assets/images/league.png",
        name: "Ekim Teknoloji Ligi"
    }
    ]

    return (
        <div className="y-league-container">
            {model.map((league) => (
                <LeagueListItem key={league.name} model={league}></LeagueListItem>
            ))}
        </div>
    )
}

export default Leagues