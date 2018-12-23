using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    enum StatisticFigureType
    {
        Mean, Variance, StandardDeviation, Covariance, CorrelationCoefficient
    }
    struct StatisticFigure
    {
        public StatisticFigureType type;
        public string[] parameters;
        public double value;
        public override string ToString()
        {
            return "Statistic Type: " + type + "  Params: " + string.Join(" ", parameters);
        }
    }
    class StatisticalReport:ISavable
    {
        private string title;
        private DateTime timeStamp;
        private StatisticFigure[] stats;
        public void Save()
        {

        }
    }
}
