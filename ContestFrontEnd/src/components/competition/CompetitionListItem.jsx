import React from "react"

function CompetitionListItem({ model }) {
    return (
        <div className="y-competition-banner" style={{ backgroundImage: `url(${model.image})` }}>
            <span className="y-competition-name">{model.name}</span>
            <span className="y-competition-dates">{model.startDate} - {model.endDate}</span>
            <span className="y-competition-prizes">{model.prizes}</span>
        </div>
    )
}

export default CompetitionListItem