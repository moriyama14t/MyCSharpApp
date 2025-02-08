using MyCSharpApp.AnimalPractice;
using MyCSharpApp.HumanPractice;

public class Program {
    public static void Main(string[] args) {
        Console.WriteLine("【AnimalPracticeのデモを実行します。】");
        AnimalProgram.Run();
        Console.WriteLine("【AnimalPracticeのデモを実行します。】");
        HumanProgram.Run();
    }
}