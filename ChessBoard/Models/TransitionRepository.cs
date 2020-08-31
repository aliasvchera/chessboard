using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessBoard.Models
{
    public static class TransitionRepository
    {
        /*public static List<Transition> Transitions = new List<Transition>()
        {
            { new Transition(("dac_rip_01", "dac_rip_02"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("dac_rip_03", "dac_rip_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_rip_03", "dac_bar_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_02", "dac_bar_01"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_rip_03", "dac_rip_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_rip_04", "dac_rip_05"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("dac_rip_04", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_rip_03", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_rip_04", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_01", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_02", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_03", "dac_rip_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_02", "moe_inf_01"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_02", "moe_inf_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_02", "moe_inf_05"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_05", "moe_inf_06"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("moe_inf_03", "moe_inf_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_05", "moe_inf_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_08", "moe_inf_07"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_10", "moe_inf_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_10", "moe_inf_07"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_10", "scy_min_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_10", "moe_inf_09"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_10", "moe_inf_11"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_11", "moe_inf_12"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("moe_inf_09", "scy_min_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_11", "scy_min_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_09", "scy_min_01"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("scy_min_02", "scy_min_01"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("scy_min_02", "dac_bar_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("scy_min_02", "dac_bar_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_09", "dac_bar_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_07", "dac_bar_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_07", "dac_bar_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_01", "dac_bar_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("moe_inf_01", "dac_bar_02"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_02", "dac_bar_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_04", "dac_bar_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_06", "dac_bar_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_08", "dac_bar_07"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("dac_bar_07", "dac_bar_05"), new string[]{ "Gothi" }, 0F) },
            { new Transition(("dac_bar_05", "dac_bar_08"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_05", "dac_bar_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_05", "dac_bar_03"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_03", "dac_bar_06"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_03", "dac_bar_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_03", "dac_bar_01"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) },
            { new Transition(("dac_bar_01", "dac_bar_04"), new string[]{ "MM_per_Thracias", "Gothi" }, 0F) }
        };*/
    }
}
