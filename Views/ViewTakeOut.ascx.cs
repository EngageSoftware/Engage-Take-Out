// <copyright file="ViewTakeOut.ascx.cs" company="Engage Software">
// Engage: Take-Out
// Copyright (c) 2004-2012
// by Engage Software ( http://www.engagesoftware.com )
// </copyright>
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

namespace Engage.Dnn.TakeOut
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Allows admins to choose which settings are included in export</summary>
    [PresenterBinding(typeof(ViewTakeOutPresenter))]
    public partial class ViewTakeOut : ModuleView<ViewTakeOutViewModel>, IViewTakeOutView
    {
        /// <summary>Backing field for <see cref="FormNamePrefix"/></summary>
        private readonly Lazy<string> formNamePrefix;

        /// <summary>Initializes a new instance of the <see cref="ViewTakeOut" /> class.</summary>
        protected ViewTakeOut()
        {
            this.formNamePrefix = new Lazy<string>(() => this.SettingsRepeater.ClientID + this.ClientIDSeparator);
        }

        /// <summary>Occurs when an order is placed (i.e. when a list of settings to include in the export are submitted).</summary>
        public event EventHandler<OrderPlacedEventArgs> OrderPlaced = (_, __) => { };

        /// <summary>Gets the prefix for names in the form.</summary>
        /// <value>The form name prefix.</value>
        protected string FormNamePrefix
        {
            get { return this.formNamePrefix.Value; }
        }

        /// <summary>Handles the <see cref="Button.Click"/> event of the <c>PlaceOrderButton</c> control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            var checkedSettings = (from key in this.Request.Form.AllKeys
                                   where key.StartsWith(this.FormNamePrefix, StringComparison.Ordinal)
                                   let settingName = key.Substring(this.FormNamePrefix.Length)
                                   select new PortalSettingViewModel(settingName, true)).ToArray();

            var uncheckedSettings = from setting in this.Model.PortalSettings.Except(checkedSettings)
                                    select new PortalSettingViewModel(setting.SettingName, false);
            
            this.OrderPlaced(this, new OrderPlacedEventArgs(checkedSettings.Concat(uncheckedSettings)));
        }
    }
}