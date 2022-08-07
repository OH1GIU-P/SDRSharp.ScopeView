using SDRSharp.Radio;
using SDRSharp.Common;

namespace SDRSharp.ScopeView
{
    public class ScopeViewProcess : IRealProcessor, IStreamProcessor, IBaseProcessor
    {
        private ScopeViewPanel _scopeViewPanel;
        private bool _enabled = true;
        private double _sampleRate;
        private bool _bypass = false;
        public int GoertzelFreq;

        public ScopeViewProcess(ScopeViewPanel control)
        {
            _scopeViewPanel = control;
        }
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        public bool Bypass
        {
            get { return _bypass; }
            set { _bypass = value; }
        }

        public double SampleRate
        {
            get { return _sampleRate; }
            set { _sampleRate = value; }
        }

        public unsafe void Process(float* audioBuffer, int length)
        {
            if (!_bypass)
            {
                _scopeViewPanel.Render(audioBuffer, length);
            }
        }

    }
}
