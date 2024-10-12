import React from 'react'
import {useEffect, useState} from 'react'
import "../assets/css/dashboard.css"
import DashboardService from "../services/DashboardService"
import RankProgressBar from "../components/dashboard/RankProgressBar"

function Dashboard() {
    const { GetUserRating, GetUserRank, GetUserAwards, GetAllRanks } = DashboardService(); 
    var data = JSON.parse(localStorage.getItem('user'));
    data.createdOn = new Date(data.createdOn).toLocaleDateString();
    var [user, setUser] = useState(data);
    var [allRanks, setAllRanks] = useState([]);
    const [rankModalOpen, setRankModalOpen] = useState(false);


    // Function to open or close the popup
    const toggleRankPopup = () => {
        setRankModalOpen(!rankModalOpen);
    };
    var allR = [];
    var rank = {}
    var rating = 0;
    var awards = "";


   
    useEffect(() => {
        const fetchUserStats = async () => {
             rating = await GetUserRating(user.id);
            setUser( prev =>( { ...prev,rating: rating }));
             rank = await GetUserRank(user.id) 
            setUser(prev => ({ ...prev, rankNumber: rank.rankNumber }));
            setUser(prev => ({ ...prev, rankName: rank.rankName }));
             awards = await GetUserAwards(user.id)
            setUser(prev => ({ ...prev, awards: awards }));
            allR = await GetAllRanks();
            setAllRanks(allR);
            
        };

        fetchUserStats(); // Sayfa yüklendiðinde çaðýr
    }, []);

   

    return <div className="dashboard-square">
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item1" onClick={toggleRankPopup}>Rütbe: {user.rankName}</div>
            <div className="dashboard-item dashboard-item2">{user.userName}</div>
            <div className="dashboard-item dashboard-item3">{user.email}</div>
        </div>
        
        <div className="dashboard-line">
            <div className="dashboard-item dashboard-item4">Ödüller : {user.awards}</div>
            <div className="dashboard-item dashboard-item5 profile-picture">
            </div>
            <div className="dashboard-item dashboard-item6">Puan: {user.rating}</div>
        </div>                                              
                                                            
        <div className="dashboard-line">                    
            <div className="dashboard-item dashboard-item7">Takým: {user.team}</div>
            <div className="dashboard-item dashboard-item8">{user.createdOn} giriþli</div>
            <div className="dashboard-item dashboard-item9">Katký Puaný: 0</div>
        </div>


        {rankModalOpen && (
             <div className="popup">
            <div className="popup-inner">
                <h2>Terfi gecmisim</h2>

                    <RankProgressBar rank={user.rankNumber} allRanks={allRanks}></RankProgressBar>
                <button onClick={toggleRankPopup}>Geri</button>
            </div>
        </div>
        )}
    </div>
}

export default Dashboard