using Leo.Guided.Buy.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leo.Guided.Buy.Api.Test.TestData
{
    public class QuickLinkControllerTestData
    {
        public static Quicklink quicklink = new Quicklink()
        {
            _schemaver = "aehfoL",
            _id = "1",
            ParentName = "mdnca",
            Bpc = 1,
            IsActive = true,
            ChildQuicklinks = new List<ChildQuickLink>()
            {
                new ChildQuickLink()
                {
                    Name = "sdoid",
                    Url = "www.gep.com",
                    DisplayName = "ladsfje",
                    IsActive = true,
                    FileId = "1"
                }
            },
            CreatedBy=new Person()
            {
                Name="mznscoia",
                ContactCode=1
            },
            ModifiedBy=new Person()
            {
                Name="lksajdoaw",
                ContactCode=1
            }


        };

        public static List<Quicklink> quicklinks = new List<Quicklink>()
        {
            quicklink
        };
    }
}
