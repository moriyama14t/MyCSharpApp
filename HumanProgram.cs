using MyCSharpApp.AnimalPractice;

namespace MyCSharpApp.HumanPractice {

    public abstract class Human: Animal {

        public int Age { get; }
        
        // 引数 name が継承元の Animal クラスのコンストラクタに渡される。
        public Human(string name, int age) : base(name) {
            Age = age;
        }
        public override void Introduce() {
            Console.WriteLine($"私は人間です。私の名前は {Name} ,年齢は{Age}歳です。");
        }
    }

    public enum Sport {
        Soccer = 1,
        Baseball = 2,
        Basketball = 3,
        Tennis = 4
}

    public abstract class SportsPlayer: Human {

        public Sport Sport { get; }
        public SportsPlayer(string name, int age, Sport sport) : base(name, age) {
            Sport = sport;
        }
    }

    public class SoccerPlayer: SportsPlayer {
        public SoccerPlayer(string name, int age) : base(name, age, Sport.Soccer) { }
        public override void Introduce() {
            Console.WriteLine($"私はサッカー選手です。私の名前は {Name} ,年齢は{Age}歳です。");
        }
    }



    public class BaseballPlayer : SportsPlayer{

    public enum BaseballPosition{
        Pitcher,
        Batter,
    }

        private BaseballPosition Position {get;}
        public BaseballPlayer(string name, int age, BaseballPosition position): base(name,age,Sport.Baseball){
            Position = position;
        }
    } 

    class HumanProgram {
        public static void Run() {
            Console.WriteLine("HumanPracticeのデモを実行します。");
            SoccerPlayer soccerPlayer = new SoccerPlayer("田中", 25);
            soccerPlayer.Introduce();
            
            BaseballPlayer baseballPlayer = new BaseballPlayer("佐藤",20, BaseballPlayer.BaseballPosition.Pitcher);
            baseballPlayer.Introduce();

            // Positionはprivateにしているため、アクセスできない保護レベル
            //baseballPlayer.Position
            
        }
    }
}
