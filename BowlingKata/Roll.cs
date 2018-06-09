namespace BowlingKata
{
    public class Roll
    {
        public static Roll New(int pinsKnockedDown)
        {
            return new Roll
            {
                PinsKnockedDown = pinsKnockedDown
            };
        }

        public static Roll NewSpare(int pinsKnockedDown)
        {
            return new Roll
            {
                PinsKnockedDown = pinsKnockedDown,
                IsSpare = true
            };
        }

        public static Roll NewStrike()
        {
            return new Roll
            {
                PinsKnockedDown = 10,
                IsStrike = true
            };
        }

        public int PinsKnockedDown { get; private set; }

        public bool IsStrike { get; private set; }

        public bool IsSpare { get; private set; }
    }
}