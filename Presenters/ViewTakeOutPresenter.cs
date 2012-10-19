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

    using DotNetNuke.Web.Mvp;

    using WebFormsMvp;

    /// <summary>Acts as a presenter for <see cref="IViewTakeOutView" /></summary>
    public sealed class ViewTakeOutPresenter : ModulePresenter<IViewTakeOutView, ViewTakeOutViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="ViewTakeOutPresenter" /> class.</summary>
        /// <param name="view">The view.</param>
        public ViewTakeOutPresenter(IViewTakeOutView view)
            : base(view)
        {
            this.View.Initialize += this.View_Initialize;
        }

        /// <summary>Handles the <see cref="IModuleViewBase.Initialize" /> event of the <see cref="Presenter{TView}.View" />.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void View_Initialize(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exc)
            {
                this.ProcessModuleLoadException(exc);
            }
        }
    }
}
