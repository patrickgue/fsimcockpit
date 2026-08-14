using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Microsoft.FlightSimulator.SimConnect;

namespace MSFSSimConnectWpf
{
    public partial class MainWindow : Window
    {
        private SimConnect simconnect;

        private const int WM_USER_SIMCONNECT = 0x0402;

        enum DEFINITIONS
        {
            AircraftData
        }

        enum REQUESTS
        {
            AircraftData
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct AircraftData
        {
            public double Altitude;
            public double Speed;
        }


        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            Closed += MainWindow_Closed;

        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var helper = new WindowInteropHelper(this);
            var hwnd = helper.Handle;

            var source = HwndSource.FromHwnd(hwnd);

            source.AddHook(WndProc);

            Connect();
        }


        private void Connect()
        {
            try
            {
                simconnect = new SimConnect(
                    "WPF MSFS Client",
                    new WindowInteropHelper(this).Handle,
                    WM_USER_SIMCONNECT,
                    null,
                    0);

                simconnect.OnRecvOpen += Simconnect_OnRecvOpen;
                simconnect.OnRecvSimobjectData += Simconnect_OnRecvSimobjectData;
                simconnect.OnRecvQuit += Simconnect_OnRecvQuit;


                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "PLANE ALTITUDE",
                    "feet",
                    SIMCONNECT_DATATYPE.FLOAT64,
                    0,
                    SimConnect.SIMCONNECT_UNUSED);


                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "AIRSPEED INDICATED",
                    "knots",
                    SIMCONNECT_DATATYPE.FLOAT64,
                    0,
                    SimConnect.SIMCONNECT_UNUSED);


                simconnect.RegisterDataDefineStruct<AircraftData>(
                    DEFINITIONS.AircraftData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Simconnect_OnRecvOpen(
            SimConnect sender,
            SIMCONNECT_RECV_OPEN data)
        {
            simconnect.RequestDataOnSimObject(
                REQUESTS.AircraftData,
                DEFINITIONS.AircraftData,
                SimConnect.SIMCONNECT_OBJECT_ID_USER,
                SIMCONNECT_PERIOD.SECOND,
                SIMCONNECT_DATA_REQUEST_FLAG.DEFAULT,
                0,
                0,
                0);
        }


        private void Simconnect_OnRecvSimobjectData(
            SimConnect sender,
            SIMCONNECT_RECV_SIMOBJECT_DATA data)
        {
            if ((REQUESTS)data.dwRequestID == REQUESTS.AircraftData)
            {
                AircraftData aircraft =
                    (AircraftData)data.dwData[0];

                Dispatcher.Invoke(() =>
                {
                    AltitudeText.Text =
                        $"{aircraft.Altitude:0} ft";

                    SpeedText.Text =
                        $"{aircraft.Speed:0} kt";
                });
            }
        }


        private void Simconnect_OnRecvQuit(
            SimConnect sender,
            SIMCONNECT_RECV data)
        {
            MessageBox.Show("MSFS SimConnect quit received");
            //Close();
        }


        private IntPtr WndProc(
            IntPtr hwnd,
            int msg,
            IntPtr wParam,
            IntPtr lParam,
            ref bool handled)
        {
            if (msg == WM_USER_SIMCONNECT)
            {
                simconnect?.ReceiveMessage();
                handled = true;
            }

            return IntPtr.Zero;
        }


        private void MainWindow_Closed(
            object sender,
            EventArgs e)
        {
            Console.WriteLine("Closed");
            simconnect?.Dispose();
        }

        private void AppQuit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}