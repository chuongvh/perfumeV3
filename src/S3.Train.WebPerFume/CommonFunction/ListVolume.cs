using S3.Train.WebPerFume.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S3.Train.WebPerFume.CommonFunction
{
    public static class ListVolume
    {
        public static List<VolumeCheckBoxModel> GetVolumeCheckBoxes()
        {
            var list = new List<VolumeCheckBoxModel>
            {
                new VolumeCheckBoxModel{id = 1, Volume = "25ml"},
                new VolumeCheckBoxModel{id = 1, Volume = "50ml"},
                new VolumeCheckBoxModel{id = 1, Volume = "100ml"},
                new VolumeCheckBoxModel{id = 1, Volume = "150ml"},
                new VolumeCheckBoxModel{id = 1, Volume = "200ml"}
            };

            return list;
        }
    }
}