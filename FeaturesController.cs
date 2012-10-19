// <copyright file="FeaturesController.cs" company="Engage Software">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    using DotNetNuke.Entities.Modules;

    /// <summary>Contains basic information about the module and exposes which DNN integration points the module implements</summary>
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Justification = "DNN instantiates this class via reflection, so it needs an accessible constructor")]
    public class FeaturesController : IPortable
    {
        /// <summary>Backing field for <see cref="GetPortalSettingsService"/></summary>
        private IPortalSettingsService portalSettingsService;

        /// <summary>Backing field for <see cref="GetModuleSettingsService"/></summary>
        private IModuleSettingsService moduleSettingsService;

        /// <summary>Initializes a new instance of the <see cref="FeaturesController" /> class.</summary>
        public FeaturesController()
            : this(null, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="FeaturesController" /> class.</summary>
        /// <param name="portalSettingsService">The portal settings service, or <c>null</c>.</param>
        /// <param name="moduleSettingsService">The module settings service, or <c>null</c>.</param>
        internal FeaturesController(IPortalSettingsService portalSettingsService, IModuleSettingsService moduleSettingsService)
        {
            this.portalSettingsService = portalSettingsService;
            this.moduleSettingsService = moduleSettingsService;
        }

        /// <summary>Exports the select portal settings.</summary>
        /// <param name="moduleId">The module ID.</param>
        /// <returns>A <see cref="string" /> representing the settings.</returns>
        public string ExportModule(int moduleId)
        {
            var moduleSettings = this.GetModuleSettingsService(moduleId).GetSettings();
            var portalSettings = this.GetPortalSettingsService(moduleId).GetSettings().Where(ps => ShouldExport(moduleSettings, ps));

            var portalSettingElements = portalSettings.Select(ps => new XElement("PortalSetting", new XAttribute("name", ps.Key), new XAttribute("value", ps.Value)));
            return new XElement("PortalSettings", portalSettingElements).ToString();
        }

        /// <summary>Imports the module.</summary>
        /// <param name="moduleId">The module ID.</param>
        /// <param name="content">The content.</param>
        /// <param name="version">The version.</param>
        /// <param name="userId">The user ID.</param>
        public void ImportModule(int moduleId, string content, string version, int userId)
        {
            var portalService = this.GetPortalSettingsService(moduleId);
            var moduleService = this.GetModuleSettingsService(moduleId);
            foreach (var portalSetting in XElement.Parse(content).Descendants("PortalSetting"))
            {
                var settingName = portalSetting.Attribute("name").Value;
                var settingValue = portalSetting.Attribute("value").Value;
                portalService.UpdateSetting(settingName, settingValue);
                moduleService.UpdateModuleSetting(settingName, true.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>Indicates whether the given portal setting should be exported.</summary>
        /// <param name="moduleSettings">The module settings.</param>
        /// <param name="portalSetting">The portal setting <see cref="KeyValuePair{TKey,TValue}"/>.</param>
        /// <returns><c>true</c> if the setting should be included in the export, <c>false</c> otherwise</returns>
        private static bool ShouldExport(IDictionary<string, string> moduleSettings, KeyValuePair<string, string> portalSetting)
        {
            string settingValue;
            bool selected;
            return moduleSettings.TryGetValue(portalSetting.Key, out settingValue) && bool.TryParse(settingValue, out selected) && selected;
        }

        /// <summary>Gets the portal settings service.</summary>
        /// <param name="moduleId">The portal ID.</param>
        /// <returns>A <see cref="IPortalSettingsService" /> instance.</returns>
        private IPortalSettingsService GetPortalSettingsService(int moduleId)
        {
            if (this.portalSettingsService == null)
            {
                this.portalSettingsService = new PortalSettingsService(new ModuleController().GetModule(moduleId).PortalID);
            }

            return this.portalSettingsService;
        }

        /// <summary>Gets the portal settings service.</summary>
        /// <param name="moduleId">The portal ID.</param>
        /// <returns>A <see cref="IPortalSettingsService" /> instance.</returns>
        private IModuleSettingsService GetModuleSettingsService(int moduleId)
        {
            if (this.moduleSettingsService == null)
            {
                this.moduleSettingsService = new ModuleSettingsService(moduleId);
            }

            return this.moduleSettingsService;
        }
    }
}
