///<summary>
/// Namn:       Magnus Wikhög
/// Projekt:    Assignment 5
/// Inlämnad:   2019-03-10
///</summary>
using Assignment.Events;
using System.Windows;

namespace Assignment {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private InAirCounter inAirCounter;


        /// <summary>
        /// Konstruktor för MainWindow
        /// </summary>
        public MainWindow() {
            InitializeComponent();

            // Skapa en instans av InAirCounter som använder OnInAirCounter som "subscriber" 
            // för dess InAirCounterDelegate -händelser.
            inAirCounter = new InAirCounter(OnInAirCounter);
        }


        /// <summary>
        /// Denna metod har samma signatur som FlightEventDelegate och anropas av 
        /// de "publishers" som vi lyssnar på, dvs. av FlightWindow.
        /// Metoden skapar ett nytt FlightEventItem och lägger till det i vår ListView.
        /// </summary>
        public void OnFlightEvent(FlightEventArgs args) {
            flightList.Items.Add( new FlightEventItem(args) );
        }

        /// <summary>
        /// Denna metod har samma signatur som InAirCounterDelegate och anropas av
        /// inAirCounter när dess räknare ändras. 
        /// Metoden uppdaterar räknaren som visar antalet flyg i luften.
        /// </summary>
        public void OnInAirCounter(int value) {
            flightCounterLabel.Content = value;
        }


        /// <summary>
        /// Öppnar ett nytt fönster med en ny flight.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e) {
            if (flightNrEdit.Text.Length < 2) {
                MessageBox.Show("Ett flightnummer måste bestå av minst två tecken.");
                return;
            }

            // Dessa delegates kommer att anropas av flight - fönstret när användaren klickar
            // på Takeoff eller Landing, eller väljer en ny kurs i dropdownlistan.
            FlightEventDelegate controlTowerDel = OnFlightEvent;
            FlightEventDelegate counterDel = inAirCounter.OnFlightEvent;

            // Skapa ett nytt flightfönster och ange båda ovanstående delegates som mottagare
            // för händelser.
            FlightWindow flightWindow = new FlightWindow(flightNrEdit.Text, controlTowerDel + counterDel);
            flightWindow.Show();
        }

    }


    /// <summary>
    /// Klass som representerar en rad i vår ListView och kan skapas direkt från en
    /// FlightEventArgs-instans.
    /// </summary>
    public class FlightEventItem {
        public string FlightNr { get; set; }
        public string Action { get; set; }
        public string Time { get; set; }

        /// <summary>
        /// Konstruktor som "omvandlar" en FlightEventArgs-instans till en ny 
        /// FlightEventItem-instans.
        /// </summary>
        public FlightEventItem(FlightEventArgs args) {
            FlightNr = args.flightNr;
            Action = args.message;
            Time = args.timestamp.ToLongTimeString();
        }
    }

}
