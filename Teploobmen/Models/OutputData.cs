using static System.Math;

namespace Teploobmen.Models
{
    public class OutputData
    {        
        public InputData InputData_;

        public OutputData(InputData parent, double y)
        {
            InputData_ = parent;
            dobelsy = y;
        }

        public double dobelsy { get; set; }
        private double? Y => (InputData_.av * dobelsy) / (InputData_.wg * InputData_.Cg * 1000);
        private double? A0 => (1 - Exp((double)((InputData_.m - 1) * Y / InputData_.m)));
        private double? A1 => (1 - InputData_.m * Exp((double)((InputData_.m - 1) * Y / InputData_.m)));
        private double? A2 => 1 - InputData_.m * Exp((double)((InputData_.m - 1) * InputData_.Y0 / InputData_.m));
        private double? Q0 => A0 / A2;
        private double? Q1 => A1 / A2;
        public int? t0 => (int?)(InputData_.t0_ + (InputData_.T_ - InputData_.t0_) * Q0);
        public int? T => (int?)(InputData_.t0_ + (InputData_.T_ - InputData_.t0_) * Q1);
        public int? deltaT => t0 - T;
    }
}
