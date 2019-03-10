///<summary>
/// Namn:       Magnus Wikhög
/// Projekt:    Assignment 5
/// Inlämnad:   2019-03-10
///</summary>
using Assignment.Events;

namespace Assignment {
    /// <summary>
    /// Klass som sköter uppräkning och nerräkning av antalet flyg i luften.
    /// </summary>
    class InAirCounter{

        /// <summary>
        /// Delegate som anropas när räknaren ändras.
        /// </summary>
        public delegate void InAirCounterDelegate(int value);

        // Räknaren
        private int _inAirCounter = 0;
        public int Count {
            get => _inAirCounter;
            set {
                _inAirCounter = value;
                OnInAirCounter(Count);
            }
        }    

        // Delegate som vi kommer publicera till när räknaren ändras.
        public InAirCounterDelegate OnInAirCounter;



        /// <summary>
        /// Konstruktor som tar emot en InAirCounterDelegate som sedan anropas när 
        /// räknaren ändras.
        /// </summary>
        public InAirCounter(InAirCounterDelegate OnInAirCounter) {
            this.OnInAirCounter = OnInAirCounter;
        }


        /// <summary>
        /// FlightEventDelegate som ändrar räknaren beroende på vilken typ av 
        /// händelse som togs emot.
        /// </summary>
        public void OnFlightEvent(FlightEventArgs args) {
            switch (args.message) {
                case "Takeoff": Count++; break;
                case "Landing": Count--; break;
            }            
        }
    }
}
