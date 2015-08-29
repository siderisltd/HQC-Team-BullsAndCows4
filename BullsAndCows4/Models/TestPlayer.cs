namespace BullsAndCowsGame.Models
{
    public class TestPlayer : Player
    {
        public TestPlayer(string name, int attempts) 
            : base(name)
        {
            this.Attempts = attempts;
        }

        public override string Name { get; set; }
        public override int Attempts { get; set; }
    }
}
