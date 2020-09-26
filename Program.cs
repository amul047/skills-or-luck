using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillsOrLuck
{
    class Program
    {
        private static readonly Random _random = new Random();
        private static readonly int _numberToSelect = 1;
        private static readonly int _maximumNumberOfCandidates = 10000;
        private static readonly int _averageOfAveragesWindowSize = 10;
        private static readonly int _skillWeighting = 95;
        private static readonly int _luckWeighting = 5;

        static void Main(string[] args)
        {
            var numberOfCandidates = new List<double>();
            var averageLucks = new List<double>();
            var averageSkills = new List<double>();
            var numberOfCandidatesWindow = new List<double>();
            var averageLucksWindow = new List<double>();
            var averageSkillsWindow = new List<double>();

            for (int i = 1; i <= _maximumNumberOfCandidates; i++)
            {
                if (i % _averageOfAveragesWindowSize == 0)
                {
                    numberOfCandidates.Add(numberOfCandidatesWindow.Average());
                    averageLucks.Add(averageLucksWindow.Average());
                    averageSkills.Add(averageSkillsWindow.Average());

                    numberOfCandidatesWindow.Clear();
                    averageLucksWindow.Clear();
                    averageSkillsWindow.Clear();
                }
                else
                {
                    numberOfCandidatesWindow.Add(i);
                    averageLucksWindow.Add(GetAverageLuckOnSelectedCandidates(i));
                    averageSkillsWindow.Add(GetAverageSkillsOnSelectedCandidates(i));
                }

            }

            var plot = new ScottPlot.Plot();
            plot.PlotScatter(numberOfCandidates.ToArray(), averageLucks.ToArray(), label: "Luck");
            plot.PlotScatter(numberOfCandidates.ToArray(), averageSkills.ToArray(), label: "Skills");
            plot.Legend(enableLegend: true);
            plot.Title("Skills and luck of selected candidates by candidate pool size");
            plot.YLabel("Skills and luck percentage");
            plot.XLabel("Candidate pool size");
            plot.SaveFig("SkillAndLuckByCandidatePoolSize.png");

        }

        private static double GetAverageLuckOnSelectedCandidates(int numberOfNasaCandidates)
        {
            var nasaCandidates = new List<Candidate>();
            for (int i = 1; i <= numberOfNasaCandidates; i++)
            {
                var nasaCandidate = new Candidate { Luck = _random.Next(1, 100), Skills = _random.Next(1, 100) };
                nasaCandidates.Add(nasaCandidate);
            }

            return nasaCandidates.OrderByDescending(nc => nc.Luck * _luckWeighting + nc.Skills * _skillWeighting)
                .Take(_numberToSelect)
                .Average(sc => sc.Luck);
        }

        private static double GetAverageSkillsOnSelectedCandidates(int numberOfNasaCandidates)
        {
            var nasaCandidates = new List<Candidate>();
            for (int i = 1; i <= numberOfNasaCandidates; i++)
            {
                var nasaCandidate = new Candidate { Luck = _random.Next(1, 100), Skills = _random.Next(1, 100) };
                nasaCandidates.Add(nasaCandidate);
            }

            return nasaCandidates.OrderByDescending(nc => nc.Luck * _luckWeighting + nc.Skills * _skillWeighting)
                .Take(_numberToSelect)
                .Average(sc => sc.Skills);
        }
    }
}
