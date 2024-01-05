using static System.Math;

namespace Teploobmen.Models;

public class InputData
{
    public string?  Name { get; set; }
    public double H0 { get; set; }
    public double t0_ { get; set; }
    public double T_ { get; set; }
    public double wg { get; set; }
    public double Cg { get; set; }
    public double av { get; set; }
    public double Cm { get; set; }
    public double Gm { get; set; }
    public double r { get; set; }

    public double m => (Gm * Cm) / (wg * Cg * PI * r * r);
    public double Y0 => (av * H0) / (wg * Cg * 1000);

}
