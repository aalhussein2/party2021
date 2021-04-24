﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace party
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // this code hide admin menu from all other users
            if (!Roles.IsUserInRole("admin"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Admin")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }
            if (!Roles.IsUserInRole("intern"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Interns")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }
            if (!Roles.IsUserInRole("supervisor")) // roles are case sensitive
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Supervisor")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }

            //111
            if (!Roles.IsUserInRole("finance"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Finance")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }

            if (!Roles.IsUserInRole("marketing"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Marketing")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }

            if (!Roles.IsUserInRole("sales"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Sales")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }


            if (!Roles.IsUserInRole("sales"))
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "KFMC")// to hide specific menu put  the name here ... Warning, case sensitive 
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }
        }

        protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}