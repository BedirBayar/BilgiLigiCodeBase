import React from 'react'
import '../assets/css/navbar.css'

function Navbar() {
    return (
        <div className="y-menu">
            <ul className="y-menu-list">
                 <li className="y-menu-item">
                     <a className="y-menu-link active" href="/dashboard">Profilim</a>
                 </li>
                <li className="y-menu-item">
                    <a className="y-menu-link" href="/competitions">Yarismalar</a>
                 </li>
                <li className="y-menu-item">
                    <a className="y-menu-link" href="/leagues">Ligler</a>
                 </li>
                <li className="y-menu-item">
                    <a className="y-menu-link" href="/myteam">Takimim</a>
                 </li>
                <li className="y-menu-item">
                    <a className="y-menu-link" href="/contributor">Katkilarim</a>
                 </li>
             </ul>
        </div>
      
    )
}

export default Navbar