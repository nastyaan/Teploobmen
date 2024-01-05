namespace Teploobmen.Data
{
    public class InData
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public double H0 { get; set; }
        public double t0_ { get; set; }
        public double T_ { get; set; }
        public double wg { get; set; }
        public double Cg { get; set; }
        public double av { get; set; }
        public double Cm { get; set; }
        public double Gm { get; set; }
        public double r { get; set; }
        public int? UserId { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
