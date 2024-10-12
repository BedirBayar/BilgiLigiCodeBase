import React from 'react'

function RankProgressBar({ rank, allRanks }) {
    var progressUnit=Math.floor(100/allRanks.length) +'%'

    return (

        <div className="rank-progress progress" style={{ height: '25px' }}>

            {allRanks.map((r, index) => {
                if (index <= rank - 1) {
                   return( <div className="progress-bar bg-success" role="progressbar" style={{ width: progressUnit }} aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">{r.rankName}</div>)
                }
                else {

                    return (<div className="progress-bar bg-secondary" role="progressbar" style={{ width: progressUnit }} aria-valuenow="10" aria-valuemin="0" aria-valuemax="100">{r.rankName}</div>)
                }
            })}
               
        </div>
       
    )
}
export default RankProgressBar
