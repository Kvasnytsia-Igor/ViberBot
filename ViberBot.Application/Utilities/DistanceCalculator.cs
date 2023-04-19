namespace Application.Utilities
{
    public static class DistanceCalculator
    {
        public static decimal Distance(decimal lat1, decimal lon1, decimal lat2, decimal lon2)
        {
            const decimal R = 6371; // radius of the Earth in kilometers
            decimal phi1 = lat1 * (decimal)Math.PI / 180;
            decimal phi2 = lat2 * (decimal)Math.PI / 180;
            decimal delta_phi = (lat2 - lat1) * (decimal)Math.PI / 180;
            decimal delta_lambda = (lon2 - lon1) * (decimal)Math.PI / 180;

            decimal a = (decimal)Math.Sin((double)(delta_phi / 2)) * (decimal)Math.Sin((double)(delta_phi / 2)) +
                       (decimal)Math.Cos((double)phi1) * (decimal)Math.Cos((double)phi2) *
                       (decimal)Math.Sin((double)(delta_lambda / 2)) * (decimal)Math.Sin((double)(delta_lambda / 2));
            decimal c = 2 * (decimal)Math.Atan2((double)Math.Sqrt((double)a), (double)Math.Sqrt((double)(1 - a)));

            decimal distance = R * c;
            return distance;
        }
    }
}
