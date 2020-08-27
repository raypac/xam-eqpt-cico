using System;
using System.Collections.Generic;
using System.Text;

namespace xam_eqpt_cico.Models
{
    /// <summary>
    /// Base class for Equiptment History collections
    /// </summary>
    public class EquiptmentHistory
    {
        /// <summary>
        ///     The Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The Equipment Id.
        /// </summary>
        public string EquipmentId { get; set; }

        /// <summary>
        ///     The Check Out Date.
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        ///     The Check Out By.
        /// </summary>
        public string CheckOutBy { get; set; }

        /// <summary>
        ///     The Check Id Date.
        /// </summary>
        public DateTime CheckIdDate { get; set; }

        /// <summary>
        ///     The Check In By.
        /// </summary>
        public string CheckInBy { get; set; }
    }
}
