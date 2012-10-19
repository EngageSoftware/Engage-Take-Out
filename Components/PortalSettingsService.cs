// <copyright file="PortalSettingsService.cs" company="Engage Software">
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
    using System.Collections.Generic;

    using DotNetNuke.Entities.Portals;

    /// <summary>Provides access to DNN portal settings</summary>
    public class PortalSettingsService : IPortalSettingsService
    {
        /// <summary>The portal ID</summary>
        private readonly int portalId;

        /// <summary>Initializes a new instance of the <see cref="PortalSettingsService" /> class.</summary>
        /// <param name="portalId">The portal ID.</param>
        public PortalSettingsService(int portalId)
        {
            this.portalId = portalId;
        }

        /// <summary>Gets the portal's settings.</summary>
        /// <returns>A <see cref="IDictionary{TKey,TValue}" /> instance</returns>
        public IDictionary<string, string> GetSettings()
        {
            return PortalController.GetPortalSettingsDictionary(this.portalId);
        }

        /// <summary>Updates the portal setting.</summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="settingValue">The setting value.</param>
        public void UpdateSetting(string settingName, string settingValue)
        {
            PortalController.UpdatePortalSetting(this.portalId, settingName, settingValue);
        }
    }
}