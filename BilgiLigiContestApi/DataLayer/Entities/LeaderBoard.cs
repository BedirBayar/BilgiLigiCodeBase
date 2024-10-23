﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataAccess.Entities
{
    public class LeaderBoard : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("IsComplete")]
        public bool IsComplete { get; set; }
        [Column("CompletedOn")]
        public DateTime CompletedOn { get; set; }
        [Column("IsRunning")]
        public bool IsRunning { get; set; }
        [Column("IsTeamLeaderBoard")]
        public bool IsTeamLeaderBoard { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }
    }
}
