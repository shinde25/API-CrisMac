
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrisMAcAPI.Areas.UPGRADATION.Models.Repository
{
    public interface IAxisUpgradationRepository 
    {
        List<object> TldlRepaySchSelectRepo(string ParaStr);
        //List<object> TldlDetailSelectRepo(string ParaStr);
        List<object> BillDetailSelectRepo(string ParaStr);
        List<object> CcodDetailSelectRepo(string ParaStr);
        List<object> UpgradationParameterSelectRepo(string ParaStr);
        List<object> UpgradeAuthSelect(string ParaStr);
        object UpgradeAuthInsertUpdate(string ParaStr);
        object UpgradationParameterInsertUpdateRepo(string ParaStr);

        object MarkInsertUpdateData(string jsonData);

        List<object> MarkUpgradationcycleSelectRepo(string ParaStr);

    }
}
