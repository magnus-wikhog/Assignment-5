///<summary>
/// Namn:       Magnus Wikhög
/// Projekt:    Assignment 5
/// Inlämnad:   2019-03-10
///</summary>
using Assignment.Events;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Assignment {


    /// <summary>
    /// Fönster som låter användaren simulera takeoff, landning och kursändring av en flight.
    /// </summary>
    public partial class FlightWindow : Window {

        private string flightNr;
        public FlightEventDelegate flightEventDel;


        /// <summary>
        /// Konstruktor som tar emot värden för flightnummer och en FlightEventDelegate som
        /// kommer att anropas när användaren interagerar med fönstret.
        /// </summary>
        public FlightWindow(string flightNr, FlightEventDelegate flightEventDel) {
            this.flightNr = flightNr;
            this.flightEventDel = flightEventDel;

            InitializeComponent();
            Title = "Flight " + flightNr;

            // Försök hämta bild för flygbolaget baserat på flightnumret. Bilder finns
            // inlagda i img/ -katalogen för flightnummer som börjar på dd, dy och su.
            if (flightNr.Length > 1) {
                string iataCode = flightNr.Substring(0, 2);
                try { 
                    logoImage.Source = new BitmapImage(new Uri(@"pack://application:,,,/"
                         + Assembly.GetExecutingAssembly().GetName().Name
                         + ";component/"
                         + "img/" + iataCode + ".jpg", UriKind.Absolute));
                }
                catch(Exception e) {
                    // Bilden finns inte eller kunde inte läsas, gör inget.
                }
            }

            // Publicera att flyget är på väg till startbanan
            flightEventDel(new FlightEventArgs(flightNr, "Sent to runway"));
        }


        /// <summary>
        /// Publicerar att flyget har lyft.
        /// </summary>
        private void TakeoffBtn_Click(object sender, RoutedEventArgs e) {
            flightEventDel(new Events.FlightEventArgs(flightNr, "Takeoff"));

            takeoffBtn.IsEnabled = false;
            landingbtn.IsEnabled = true;
            actionComboBox.IsEnabled = true;
        }

        /// <summary>
        /// Publicerar att flyget har landat.
        /// </summary>
        private void Landingbtn_Click(object sender, RoutedEventArgs e) {
            flightEventDel(new Events.FlightEventArgs(flightNr, "Landing"));
            Close();
        }

        /// <summary>
        /// Publicerar att flyget har ändrat kurs.
        /// </summary>
        private void FlightAction_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            flightEventDel(new Events.FlightEventArgs(flightNr, actionComboBox.SelectedValue.ToString()));
        }
    }


}
