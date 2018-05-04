using System;
using System.IO;
using Xunit;

namespace test
{
    using ElephantsSolver = RecruitmentTask.ElephantsSolver;
    public class MovingElephantsTests
    {
        [Fact]
        public void slo1()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo1.in");
            long solution = ParseSolution("slo_tests/slo1.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo1ocen()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo1.in");
            long solution = ParseSolution("slo_tests/slo1.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo2()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo2.in");
            long solution = ParseSolution("slo_tests/slo2.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo2ocen()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo2ocen.in");
            long solution = ParseSolution("slo_tests/slo2ocen.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo3()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo3.in");
            long solution = ParseSolution("slo_tests/slo3.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo3ocen()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo3ocen.in");
            long solution = ParseSolution("slo_tests/slo3ocen.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo4()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo4.in");
            long solution = ParseSolution("slo_tests/slo4.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo4ocen()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo4ocen.in");
            long solution = ParseSolution("slo_tests/slo4ocen.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo5()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo5.in");
            long solution = ParseSolution("slo_tests/slo5.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo6()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo6.in");
            long solution = ParseSolution("slo_tests/slo6.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo7()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo7.in");
            long solution = ParseSolution("slo_tests/slo7.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo8a()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo8a.in");
            long solution = ParseSolution("slo_tests/slo8a.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo8b()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo8b.in");
            long solution = ParseSolution("slo_tests/slo8b.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo9a()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo9a.in");
            long solution = ParseSolution("slo_tests/slo9a.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo9b()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo9b.in");
            long solution = ParseSolution("slo_tests/slo9b.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo10a()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo10a.in");
            long solution = ParseSolution("slo_tests/slo10a.out");
            Assert.Equal(solution, calculatedSolution);
        }

        [Fact]
        public void slo10b()
        {
            long calculatedSolution = CalculateSolution("slo_tests/slo10b.in");
            long solution = ParseSolution("slo_tests/slo10b.out");
            Assert.Equal(solution, calculatedSolution);
        }

        public static long CalculateSolution(String pathToFile)
        {
            var solver = new ElephantsSolver(pathToFile);
            solver.ParseInputData();
            solver.PartitionIntoCycles();
            solver.SolveCycles();
            return solver.ResultWeight;
        }

        public static long ParseSolution(String pathToFile)
        {
            var file = new StreamReader(pathToFile);
            String textLine = null;
            try
            {
                textLine = file.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return ParseNumber(textLine);
        }

        private static long ParseNumber(String number)
        {
            long parsedNumber;
            bool success = long.TryParse(number, out parsedNumber);
            if (success)
            {
                return parsedNumber;
            }
            else
            {
                Console.WriteLine("Attempted conversion of '{0}' failed.",
                    number == null ? "<null>" : number);
                throw new InvalidProgramException("Exception thrown while parsing solution data.");
            }
        }
    }
}
