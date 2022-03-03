using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class OnlineVotingDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<PartyList> PartyLists { get; set; }
        public DbSet<PartyListMember> PartyListMembers { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<SamplePerson> SamplePersons { get; set; }
    }
}