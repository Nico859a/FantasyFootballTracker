using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FantasyFootballTracker
{
    public class FootballPlayer
    {
        // Fields
        private string _name;
        private string _position;
        private int _gamesplayed;
        private double _pointspergame;
        private int _carries;
        private int _rushingYards;
        private int _totalTouchdowns;
        private int _receptions;
        private int _receivingYards;

        // Properties
        public string Name { get; set; }
        public string Position { get; set; }
        public int GamesPlayed { get; set; }
        public double PointsPerGame { get; set; }
        public int Carries { get; set; }
        public int RushingYards { get; set; }
        public int TotalTouchdowns { get; set; }
        public int Receptions { get; set; }
        public int ReceivingYards { get; set; }

        // Constructor
        public FootballPlayer(string name, string position, int gamesPlayed, double pointsPerGame, int carries, int rushingYards, int totalTouchdowns, int receptions, int receivingYards)
        {
            this.Name = name;
            this.Position = position;
            this.GamesPlayed = gamesPlayed;
            this.PointsPerGame = pointsPerGame;
            this.Carries = carries;
            this.RushingYards = rushingYards;
            this.TotalTouchdowns = totalTouchdowns;
            this.Receptions = receptions;
            this.ReceivingYards = receivingYards;
        }
    }
}
