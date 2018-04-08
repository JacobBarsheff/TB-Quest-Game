using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible Prospector actions
    /// </summary>
    public enum ProspectorAction
    {
        None,
        EditAccount,
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        ProspectorInfo,
        ProspectorInventory,
        ProspectorTreasure,
        ProspectorLocationsVisited,
        ListDestinations,
        ListItems,
        ListTreasures,
        Shop,
        AdminMenu,
        ReturnToMainMenu,
        Exit
    }
}
