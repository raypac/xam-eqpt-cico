using System;
using System.Collections.Generic;
using System.Text;

namespace xam_eqpt_cico.Models
{
    public enum MenuItemType
    {
        Equipment,
        CheckIn,
        CheckOut,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
