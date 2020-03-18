using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            string[] main_chessmans = {"Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook"};
            string[] pawn_chessmans = {"Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"};
            ChessmanFactory factory = new ChessmanFactory();
            
            //white_player
            bool state = true;
            foreach (string chman in main_chessmans) {
                Chessman character = factory.GetCharacter(chman);
                character.Display(state);
            }
            Console.WriteLine("");

            foreach (string chman in pawn_chessmans) {
                Chessman character = factory.GetCharacter(chman);
                character.Display(state);
            }
            Console.WriteLine("\n\n\n\n");

            //black_player
            state = false;
            foreach (string chman in pawn_chessmans) {
                Chessman character = factory.GetCharacter(chman);
                character.Display(state);
            }
            Console.WriteLine("");
            foreach (string chman in main_chessmans) {
                Chessman character = factory.GetCharacter(chman);
                character.Display(state);
            }
            Console.WriteLine("");
            
            Console.ReadKey();
        }
    }

    class ChessmanFactory   // The 'FlyweightFactory' class
    {
        private Dictionary<string, Chessman> _chessmans = new Dictionary<string, Chessman>();
        public Chessman GetCharacter(string key)
        {
            // Uses "lazy initialization"
            Chessman chessman = null;
            if (_chessmans.ContainsKey(key)) {
                chessman = _chessmans[key];
            } else {
                switch (key)
                {
                    case "King": chessman = new ChessmanKing(); break;
                    case "Queen": chessman = new ChessmanQueen(); break;
                    case "Rook": chessman = new ChessmanRook(); break;
                    case "Bishop": chessman = new ChessmanBishop(); break;
                    case "Knight": chessman = new ChessmanKnight(); break;
                    case "Pawn": chessman = new ChessmanPawn(); break;                    
                }
                _chessmans.Add(key, chessman);
            }
            return chessman;
        }
    }
    // The 'Flyweight' abstract class
    abstract class Chessman
    {
        protected string white_symbol;
        protected string black_symbol;
        // protected bool state; // true - white, false - black
        public abstract void Display(bool state);
    }

    // A 'ConcreteFlyweight' class
    class ChessmanKing : Chessman
    {
        public ChessmanKing()
        {
            this.white_symbol = "\x2654";
            this.black_symbol = "\x265A";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }
    /// A 'ConcreteFlyweight' class
    class ChessmanQueen : Chessman
    {
        public ChessmanQueen()
        {
            this.white_symbol = "\x2655";
            this.black_symbol = "\x265B";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }
    
    // A 'ConcreteFlyweight' classes
    class ChessmanRook : Chessman
    {        
        public ChessmanRook()
        {
            this.white_symbol = "\x2656";
            this.black_symbol = "\x265C";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }

    class ChessmanBishop  : Chessman
    {
        public ChessmanBishop ()
        {
            this.white_symbol = "\x2657";
            this.black_symbol = "\x265D";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }

    class ChessmanKnight  : Chessman
    {
        public ChessmanKnight ()
        {
            this.white_symbol = "\x2658";
            this.black_symbol = "\x265E";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }
    class ChessmanPawn  : Chessman
    {
        public ChessmanPawn ()
        {
            this.white_symbol = "\x2659";
            this.black_symbol = "\x265F";
        }
        public override void Display(bool state)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            if (state) {
                Console.Write(this.white_symbol + '\t');
            } else {
                Console.Write(this.black_symbol + '\t');
            }
        }
    }
}