// <copyright file="IModuleSettingsService.cs" company="Engage Software">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Specifies the ability to set module settings</summary>
    public interface IModuleSettingsService
    {
        /// <summary>Gets the module's settings.</summary>
        /// <returns>A <see cref="IDictionary{TKey,TValue}" /> instance</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Potentially queries database")]
        IDictionary<string, string> GetSettings();

        /// <summary>Updates the module setting.</summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="settingValue">The setting value.</param>
        void UpdateModuleSetting(string settingName, string settingValue);
    }
}