// <copyright file="ModuleSettingsService.cs" company="Engage Software">
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

    using DotNetNuke.Entities.Modules;

    /// <summary>Provides access to the settings for a module</summary>
    public class ModuleSettingsService : IModuleSettingsService
    {
        /// <summary>The module ID</summary>
        private readonly int moduleId;

        /// <summary>The module controller</summary>
        private readonly ModuleController moduleController = new ModuleController();

        /// <summary>Initializes a new instance of the <see cref="ModuleSettingsService" /> class.</summary>
        /// <param name="moduleId">The ID of the module</param>
        public ModuleSettingsService(int moduleId)
        {
            this.moduleId = moduleId;
        }

        /// <summary>Updates the module setting.</summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="settingValue">The setting value.</param>
        public void UpdateModuleSetting(string settingName, string settingValue)
        {
            this.moduleController.UpdateModuleSetting(this.moduleId, settingName, settingValue);
        }
    }
}