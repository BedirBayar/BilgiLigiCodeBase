import React from 'react'
import { useEffect, useState } from 'react'
import "../assets/css/competitions.css"
import CompetitionListItem from "../components/Competition/CompetitionListItem"

function Competitions() {
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
    let model = {
        image: "../../public/assets/images/competitions/bilgi-yarismasi.jpg",
        name: "En hizli yanit verme yarismasi",
        startDate: "8 Ekim 00:00",
        endDate: "14 Ekim 23:59",
        prizes: "Birinci: 45 puan Ikinci: 35 puan Ucuncu: 25 puan"
    }

    return (
        <div className="y-competition-container">
            <CompetitionListItem model={model}></CompetitionListItem>
            <CompetitionListItem model={model}></CompetitionListItem>
            <CompetitionListItem model={model}></CompetitionListItem>
        </div>
    )

}

export default Competitions