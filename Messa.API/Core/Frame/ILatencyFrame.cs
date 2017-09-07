namespace Messa.API.Core.Frame
{
    public interface ILatencyFrame
    {
        int Sequence { get; set; }

        void LowSend();

        void UpdateLatency();

        int GetLatencyAvg();

        int GetSamplesCount();

        int GetSamplesMax();
    }
}
