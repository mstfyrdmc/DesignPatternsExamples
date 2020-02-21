using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //3
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mens");
            algorithm = new MenScoringAlgorithm();
            Console.WriteLine(algorithm.GenarateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenarateScore(10, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildScoringAlgorithm();
            Console.WriteLine(algorithm.GenarateScore(10, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
            //
        }
    }
    //1
    abstract class ScoringAlgorithm
    {
        public int GenarateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);

    }
    //

    //2 -Implament class
    class MenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

       
    }
    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }

    class ChildScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
    }
    //
}
