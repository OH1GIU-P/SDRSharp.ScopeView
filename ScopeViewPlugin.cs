using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDRSharp.Common;
using System.Windows.Forms;
using System.Threading;
using SDRSharp.Radio;

namespace SDRSharp.ScopeView
{
    public class ScopeViewPlugin : ISharpPlugin
    {
        private const string _displayName = "Scope View";
        private ISharpControl _control;
        private ScopeViewPanel _scopeViewPanel;

        public UserControl Gui
        {
            get { return _scopeViewPanel; }
        }

        public bool HasGui
        {
            get { return true; }
        }

        //public UserControl GuiControl
        //{
        //    get { return _scopeViewPanel; }
        //}

        public bool HasData
        {
            get { return false; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public void Close()
        {
        }

        public void Initialize(ISharpControl control)
        {
            _control = control;
            _scopeViewPanel = new ScopeViewPanel(_control);
            ScopeViewProcess _scopeViewProcess = new ScopeViewProcess(_scopeViewPanel);
            _control.RegisterStreamHook(_scopeViewProcess, ProcessorType.FilteredAudioOutput);
        }

    }
}
