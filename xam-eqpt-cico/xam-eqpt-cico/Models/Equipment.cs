using System;
using System.Collections.Generic;

namespace xam_eqpt_cico.Models
{
    /// <summary>
    /// Base class for Equipment collections
    /// </summary>
    public class Equipment
    {
        /// <summary>
        ///     The Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     The Location Code.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        ///     The Tooling Type.
        /// </summary>
        public string ToolingType { get; set; }

        /// <summary>
        ///     The Asset Number.
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        ///     The Serial Number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     The Tooling Name.
        /// </summary>
        public string ToolingName { get; set; }

        /// <summary>
        ///     Is Damaged.
        /// </summary>
        public bool IsDamaged { get; set; }

        /// <summary>
        ///     Is In Use.
        /// </summary>
        public bool IsInUse { get; set; }

        /// <summary>
        ///     Is In User Where.
        /// </summary>
        public string IsInUseWhere { get; set; }

        /// <summary>
        ///     ImageObj in Base64
        /// </summary>
        public string ImageObj { get; set; }

        /// <summary>
        ///     The List of Equipment History.
        /// </summary>
        public List<EquipmentHistory> EquipmentHistory { get; set; }

        /// <summary>
        ///     The Text.
        /// </summary>
        public string Text
        {
            get
            {
                return $"{ToolingName}";
            }
        }

        /// <summary>
        ///     The Description.
        /// </summary>
        public string Description
        {
            get
            {
                var itemAvailable = IsInUse ? "Not Available" : "Available";
                return $"Location: {Location}, Equipment is {itemAvailable}";
            }
        }
    }
}
