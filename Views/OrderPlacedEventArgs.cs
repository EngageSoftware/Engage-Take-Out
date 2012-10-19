// <copyright file="OrderPlacedEventArgs.cs" company="Engage Software">
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
    using System.Linq;

    /// <summary>Contains information about the <see cref="IViewTakeOutView.OrderPlaced"/> event</summary>
    public class OrderPlacedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="OrderPlacedEventArgs" /> class.</summary>
        /// <param name="portalSettings">The settings.</param>
        public OrderPlacedEventArgs(IEnumerable<PortalSettingViewModel> portalSettings)
        {
            this.PortalSettings = portalSettings.ToArray();
        }

        /// <summary>Gets the settings.</summary>
        /// <value>The settings.</value>
        public IEnumerable<PortalSettingViewModel> PortalSettings { get; private set; }
    }
}