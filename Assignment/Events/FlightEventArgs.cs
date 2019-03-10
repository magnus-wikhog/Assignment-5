///<summary>
/// Namn:       Magnus Wikhög
/// Projekt:    Assignment 5
/// Inlämnad:   2019-03-10
///</summary>
using System;

namespace Assignment.Events {

    /// <summary>
    /// Delegate som hanterar en "flyghändelse", t.ex. takeoff, landning och kursändring.
    /// </summary>
    public delegate void FlightEventDelegate(FlightEventArgs args);


    /// <summary>
    /// Klass som representerar en "flyghändelse" och innehåller information om flightnummer,
    /// meddelande (händelse) och tidpunkt för händelsen.
    /// </summary>
    public class FlightEventArgs : EventArgs{
        public string flightNr;
        public string message;
        public DateTime timestamp;

        /// <summary>
        /// Konstruktor som tar emot värden för flightnummer och meddelande/händelse.
        /// </summary>
        public FlightEventArgs(string flightNr, string message) {
            this.flightNr = flightNr;
            this.message = message;
            this.timestamp = DateTime.Now;
        }
    }

}
