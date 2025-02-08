using System;

namespace MyCsharpApp.AnimalPractice {

    // 【abstract】（抽象クラス）
    // ・abstract キーワードを付けると、このクラスは抽象クラスになり、直接インスタンス化(new)できない
    // ・共通のプロパティやメソッドの規約を定義し、派生クラスで必ず実装（override）させる抽象メソッドを持つことができる。
    public abstract class Animal {
        // 名前のプロパティ（自動実装プロパティ）
        public string Name { get; set; }
        
        // コンストラクタ：Animalクラスの派生時に名前を設定する
        public Animal(string name) {
            Name = name;
        }
        
        // 【abstract メソッド】
        // ・抽象メソッドは実装を持たず、派生クラスで必ず実装しないと「コンパイルエラー」になる！！！
        public abstract void MakeSound();
        
        // 【virtual】（仮想メソッド）
        // ・virtual キーワードを付けると、このメソッドは派生クラスでオーバーライド（override）可能になる。
        // ・基本的な自己紹介の処理を定義しておき、必要に応じて派生クラスで拡張できます。
        public virtual void Introduce() {
            Console.WriteLine($"私は動物です。私の名前は {Name} です。");
        }
    }

    // 【interface】（インターフェース）
    // ・interface はクラスが実装すべきメソッドなどを定義
    // ・複数のインターフェースを実装できるため、多重継承的な使い方が可能
    public interface IWalkable {
        // IWalkableを実装するクラスは、Walk()メソッドを実装する必要が出る。
        void Walk();
    }

    // Dog クラス：Animalを継承し、IWalkableインターフェースを実装
    public class Dog : Animal, IWalkable {
        public Dog(string name) : base(name) { }
        
        // 【override】（オーバーライド）
        // ・override キーワードは、基底クラスのabstractまたはvirtualメソッドの実装を
        //   派生クラスで上書きすることを示します。
        public override void MakeSound() {
            Console.WriteLine($"{Name} は吠えます：ワンワン！");
        }
        
        public override void Introduce() {
            // 基底クラスのIntroduce()の処理を呼び出す場合は、baseを使用します。
            base.Introduce();
            Console.WriteLine("私は犬です。");
        }
        
        // IWalkableインターフェースの実装
        public void Walk() {
            Console.WriteLine($"{Name} は楽しそうに歩いています。");
        }
    }

    // Cat クラス：Animalを継承
    public class Cat : Animal {
        public Cat(string name) : base(name) { }
        
        public override void MakeSound() {
            Console.WriteLine($"{Name} は鳴きます：ニャー！");
        }
        
        // CatはIWalkableを実装していないので、Walk()は定義しない。
        // Introduce()は基底クラスのまま
    }

    // エントリーポイント
    class AnimalProgram {
         public static void Run() {
            // Animal型としてDogとCatのインスタンスを生成
            Animal dog = new Dog("ハチ");
            Animal cat = new Cat("タマ");
            
            // 犬の自己紹介と鳴き声
            dog.Introduce();
            dog.MakeSound();
            // IWalkableインターフェースの実装なのでキャストしてWalk()を呼び出す
            // dog.walk();だと'Animal' に 'walk' の定義が含まれておらず、でエラーになる
            if (dog is IWalkable walker) {
                walker.Walk();
            }
            
            // 猫の自己紹介と鳴き声
            cat.Introduce();
            cat.MakeSound();

            // プロパティの値を変更(get; set; があるので変更可能)
            cat.Name = "ミケ";
            Console.WriteLine(cat.Name);
        }
    }
}
