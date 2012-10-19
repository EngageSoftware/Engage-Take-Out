// <copyright file="ViewTakeOutViewModel.cs" company="Engage Software">
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

    /// <summary>The view model for the Take-Out, to be displayed by <see cref="IViewTakeOutView" /></summary>
    public class ViewTakeOutViewModel
    {
        /// <summary>Initializes a new instance of the <see cref="ViewTakeOutViewModel" /> class.</summary>
        public ViewTakeOutViewModel()
        {
            this.PortalSettings = new List<PortalSettingViewModel>(30);
        }

        /// <summary>Gets the portal settings.</summary>
        /// <value>The portal settings.</value>
        public IList<PortalSettingViewModel> PortalSettings { get; private set; }
    }
}