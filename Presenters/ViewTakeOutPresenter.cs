// <copyright file="ViewTakeOutPresenter.cs" company="Engage Software">
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
    using System.Globalization;
    using System.Linq;

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IViewTakeOutView" /></summary>
    public sealed class ViewTakeOutPresenter : ModulePresenter<IViewTakeOutView, ViewTakeOutViewModel>
    {
        /// <summary>The portal settings service</summary>
        private readonly IPortalSettingsService portalSettingsService;

        /// <summary>The module settings service</summary>
        private readonly IModuleSettingsService moduleSettingsService;

        /// <summary>Initializes a new instance of the <see cref="ViewTakeOutPresenter" /> class.</summary>
        /// <param name="view">The view.</param>
        public ViewTakeOutPresenter(IViewTakeOutView view)
            : this(view, null, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ViewTakeOutPresenter" /> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="portalSettingsService">The portal settings service, or <c>null</c>.</param>
        /// <param name="moduleSettingsService">The module settings service, or <c>null</c>.</param>
        internal ViewTakeOutPresenter(IViewTakeOutView view, IPortalSettingsService portalSettingsService, IModuleSettingsService moduleSettingsService)
            : base(view)
        {
            // NOTE: PortalId and ModuleId properties aren't setup yet, have to go through ModuleContext to get the right values
            this.portalSettingsService = portalSettingsService ?? new PortalSettingsService(this.ModuleContext.PortalId);
            this.moduleSettingsService = moduleSettingsService ?? new ModuleSettingsService(this.ModuleContext.ModuleId);

            this.View.Initialize += this.View_Initialize;
            this.View.OrderPlaced += this.View_OrderPlaced;
        }

        /// <summary>Converts the given value to a <see cref="bool"/>.</summary>
        /// <param name="textValue">The value to convert, as a <see cref="string"/>.</param>
        /// <param name="defaultValue">The default value, if <paramref name="textValue"/> cannot be parsed as a <see cref="bool"/>.</param>
        /// <returns>The <see cref="bool"/> representation of <paramref name="textValue"/>, or <paramref name="defaultValue"/></returns>
        private static bool ConvertToBoolean(string textValue, bool defaultValue)
        {
            bool parsedValue;
            return bool.TryParse(textValue, out parsedValue) ? parsedValue : defaultValue;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize" /> event of the <see cref="Presenter{TView}.View" />.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            try
            {
                foreach (var setting in from settingName in this.portalSettingsService.GetSettings().Keys
                                        join setting in this.Settings on settingName equals setting.Key into settings
                                        from setting in settings.DefaultIfEmpty()
                                        select new PortalSettingViewModel(settingName, ConvertToBoolean(setting.Value, false)))
                {
                    this.View.Model.PortalSettings.Add(setting);
                }
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }

        /// <summary>Handles the <see cref="IViewTakeOutView.OrderPlaced"/> event of the <see cref="Presenter{TView}.View"/>.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="OrderPlacedEventArgs" /> instance containing the event data.</param>
        private void View_OrderPlaced(object sender, OrderPlacedEventArgs e)
        {
            try
            {
                this.View.Model.PortalSettings.Clear();
                foreach (var setting in e.PortalSettings)
                {
                    this.moduleSettingsService.UpdateModuleSetting(setting.SettingName, setting.Selected.ToString(CultureInfo.InvariantCulture));
                    this.View.Model.PortalSettings.Add(setting);
                }

                this.View.Model.ShowSuccessMessage = true;
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }
    }
}