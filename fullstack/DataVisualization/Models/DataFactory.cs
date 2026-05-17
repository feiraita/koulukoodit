using DataVisualisation.Models;
using DataVisualization.Models;
using System;
using System.Collections.Generic;

namespace DataVisualisation.Models {
    public static class StatsFactory {
        public static List<Stats> CreateData(DateTime startDate, DateTime endDate, int dataPoints) {
            if (dataPoints <= 0)
                throw new ArgumentException("dataPoints must be greater than 0");

            if (endDate <= startDate)
                throw new ArgumentException("endDate must be greater than startDate");

            var random = new Random();
            var result = new List<Stats>(dataPoints);

            long rangeTicks = (endDate - startDate).Ticks;

            for (int i = 0; i < dataPoints; i++) {
                // Random timestamp within range
                long randomTicks = (long)(random.NextDouble() * rangeTicks);
                DateTime date = startDate.AddTicks(randomTicks);

                // Score generation (still nice-looking)
                double baseValue = random.NextDouble() * 10;

                // Optional: seasonal effect (month-based variation)
                double seasonal = Math.Sin((date.Month / 12.0) * 2 * Math.PI) * 3;

                // Noise
                double noise = (random.NextDouble() - 0.5) * 2;

                double score = baseValue + seasonal + noise;

                result.Add(new Stats(score, date));
            }

            // Important: sort by time for visualization
            return result.OrderBy(s => s.TimeStamp).ToList();
        }
    }
}