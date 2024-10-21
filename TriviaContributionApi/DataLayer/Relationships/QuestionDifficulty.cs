﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TriviaContributionApi.DataLayer.Entities;

namespace TriviaContributionApi.DataLayer.Relationships
{
    [Table("QuestionDifficulty")]
    public class QuestionDifficulty:BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
        [Column("DifficultyPoint")]
        public int DifficultyPoint { get; set; }
    }
}
