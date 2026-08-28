using fsimcockpit.serial_connector;
using Microsoft.FlightSimulator.SimConnect;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace MSFSSimConnectWpf
{
    public partial class MainWindow : Window
    {
        private SimConnect simconnect;
        private ArduinoConnector Connector;

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
            public double Heading;
            public double Pitch; 
            public double Bank; 
            public double TurnRate;
            public double SlipBall;
            public double VerticalSpeed;
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

                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "HEADING INDICATOR",
                    "degrees",
                    SIMCONNECT_DATATYPE.FLOAT64,
                    0,
                    SimConnect.SIMCONNECT_UNUSED);

                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "ATTITUDE INDICATOR PITCH DEGREES",
                    "degrees",
                    SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);

                // 5. Roll / Bank (Degrees: Right bank is positive, Left is negative)
                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "ATTITUDE INDICATOR BANK DEGREES",
                    "degrees",
                    SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);

                // 6. Turn Rate (Turn Coordinator aircraft indicator needle)
                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "TURN INDICATOR RATE",
                    "radians per second",
                    SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);

                // 7. Slip/Skid Ball Position (-1.0 full left, 0 center, +1.0 full right)
                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "TURN COORDINATOR BALL",
                    "position",
                    SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);

                // 8. Vertical Speed (Feet per minute)
                simconnect.AddToDataDefinition(
                    DEFINITIONS.AircraftData,
                    "VERTICAL SPEED",
                    "feet per minute",
                    SIMCONNECT_DATATYPE.FLOAT64, 0, SimConnect.SIMCONNECT_UNUSED);


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
                SIMCONNECT_PERIOD.SIM_FRAME,
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

                    HeadingText.Text = $"{aircraft.Heading} degr";

                    PitchText.Text = $"{aircraft.Pitch} degr";
                    BankText.Text = $"{aircraft.Bank} degr";
                    VerticalSpeedText.Text = $"{aircraft.VerticalSpeed} degr";

                    TurnText.Text = $"{aircraft.TurnRate}";
                    SlipText.Text = $"{aircraft.SlipBall}";
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

        private void RefreshSerialPortList(object sender, RoutedEventArgs e)
        {
            SerialPortSelector.Items.Clear();
            foreach (var serialPort in SerialClient.SerialPortList())
            { 
                SerialPortSelector.Items.Add(serialPort);
            }
        }

        private void SerialPortSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = SerialPortSelector.SelectedItem;
            string serialPort = null;
            if (selectedItem is ComboBoxItem)
            {
                serialPort = ((ComboBoxItem)selectedItem).Name;
            }
            else
            {
                serialPort = (string)selectedItem;
            }

            if (serialPort != null)
            {
                Connector = new ArduinoConnector(serialPort);
            }
        }

        private void SerialPortSelected(object sender, RoutedEventArgs e)
        {
            SerialPortSelector_SelectionChanged(sender, null);
        }
    }
}