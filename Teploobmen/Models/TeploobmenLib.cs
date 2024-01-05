namespace Teploobmen.Models
{
    public class TeploobmenLib
    {
        public OutputResData Calc(InputData data)
        {
            var rows = new List<OutputData>();

            for (double i = 0; i <= data.H0; i += 0.5)
            {
                rows.Add(new OutputData(data, i));
            }

            var modelRes = new OutputResData();

            rows.ForEach(outputData =>
            {
                modelRes.Doublesy.Add(outputData.dobelsy);
                modelRes.param1.Add((double)outputData.t0);
                modelRes.param2.Add((double)outputData.T);
                modelRes.param3.Add((double)outputData.deltaT);
            });

            return modelRes;
        }
    }
}
