﻿using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess
{
    public interface IContestDbContext
    {
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ContestAward> ContestAwards { get; set; }
        public DbSet<ContestType> ContestTypes { get; set; }
        public DbSet<ContestRule> ContestRules { get; set; }
        public DbSet<ContestTeam> ContestTeams { get; set; }
        public DbSet<LeaderBoardTeam> LeaderBoardTeams { get; set; }
        public DbSet<LeaderBoardUser> LeaderBoardUsers { get; set; }
        public DbSet<MatchQuestion> MatchQuestions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
