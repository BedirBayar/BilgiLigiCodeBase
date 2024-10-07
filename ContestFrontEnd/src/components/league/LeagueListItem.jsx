import React from "react"

function LeagueListItem({ model }) {
    return (
        <div className="y-league-banner" style={{ backgroundImage: `url(${model.image})` }}>
            <span className="y-league-name">{model.name}</span>
        </div>
    )
}

export default LeagueListItem